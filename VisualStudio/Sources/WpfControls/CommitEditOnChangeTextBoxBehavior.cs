using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace Heinzman.WpfControls
{
    public class CommitEditOnChangeTextBoxBehavior : Behavior<TextBox>
    {
        public static readonly DependencyProperty CommitEditOnChangeProperty =
            DependencyProperty.RegisterAttached(
                "CommitEditOnChange",
                typeof (bool),
                typeof(CommitEditOnChangeTextBoxBehavior),
                new UIPropertyMetadata(false, OnCommitEditOnChangeChanged));

        public static bool GetCommitEditOnChange(TextBox textBox)
        {
            return (bool)textBox.GetValue(CommitEditOnChangeProperty);
        }

        public static void SetCommitEditOnChange(TextBox textBox, bool value)
        {
            textBox.SetValue(CommitEditOnChangeProperty, value);
        }

        private static void OnCommitEditOnChangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox != null && e.NewValue is bool)
            {
                if ((bool) e.NewValue)
                {
                    textBox.TextChanged += TextChanged;
                }
                else
                {
                    textBox.TextChanged -= TextChanged;
                }
            }
        }

        private static void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                BindingExpression bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
                if (bindingExpression != null) 
                    bindingExpression.UpdateSource();
            }
        }

    }
}
