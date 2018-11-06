using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Heinzman.WpfControls.SelectionSync
{
    public static class MultiSelectorBehaviours
    {
        public static readonly DependencyProperty SynchronizedSelectedItems = DependencyProperty.RegisterAttached(
            "SynchronizedSelectedItems", typeof(IList), typeof(MultiSelectorBehaviours), new PropertyMetadata(null, OnSynchronizedSelectedItemsChanged));
        
        private static readonly DependencyProperty SynchronizationManagerProperty = DependencyProperty.RegisterAttached(
            "SynchronizationManager", typeof(SynchronizationManager), typeof(MultiSelectorBehaviours), new PropertyMetadata(null));

        public static IList GetSynchronizedSelectedItems(DependencyObject dependencyObject)
        {
            return (IList) dependencyObject.GetValue(SynchronizedSelectedItems);
        }

        public static void SetSynchronizedSelectedItems(DependencyObject dependencyObject, IList value)
        {
            dependencyObject.SetValue(SynchronizedSelectedItems, value);
        }

        private static SynchronizationManager GetSynchronizationManager(DependencyObject dependencyObject)
        {
            return (SynchronizationManager) dependencyObject.GetValue(SynchronizationManagerProperty);
        }

        private static void SetSynchronizationManager(DependencyObject dependencyObject, SynchronizationManager value)
        {
            dependencyObject.SetValue(SynchronizationManagerProperty, value);
        }

        private static void OnSynchronizedSelectedItemsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                SynchronizationManager synchronizer = GetSynchronizationManager(dependencyObject);
                synchronizer.StopSynchronizing();
                SetSynchronizationManager(dependencyObject, null);
            }

            IList list = e.NewValue as IList;
            Selector selector = dependencyObject as Selector;

            if (list != null && selector != null)
            {
                SynchronizationManager synchronizer = GetSynchronizationManager(dependencyObject);
                if (synchronizer == null)
                {
                    synchronizer = new SynchronizationManager(selector);
                    SetSynchronizationManager(dependencyObject, synchronizer);
                }
                synchronizer.StartSynchronizingList();
            }
        }

        private class SynchronizationManager
        {
            private readonly Selector _multiSelector;
            private TwoListSynchronizer _synchronizer;

            internal SynchronizationManager(Selector selector)
            {
                _multiSelector = selector;
            }

            public void StartSynchronizingList()
            {
                IList list = GetSynchronizedSelectedItems(_multiSelector);

                if (list != null)
                {
                    _synchronizer = new TwoListSynchronizer(GetSelectedItemsCollection(_multiSelector), list);
                    _synchronizer.StartSynchronizing();
                }
            }

            public void StopSynchronizing()
            {
                _synchronizer.StopSynchronizing();
            }

            public static IList GetSelectedItemsCollection(Selector selector)
            {
                if (selector is MultiSelector)
                    return (selector as MultiSelector).SelectedItems;
                else if (selector is ListBox)
                    return (selector as ListBox).SelectedItems;
                else
                    throw new InvalidOperationException("Target object has no SelectedItems property to bind.");
            }

        }
    }
}
