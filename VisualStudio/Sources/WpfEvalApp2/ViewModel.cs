using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfEvalApp2
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ObservableCollection<Entity> _entities = new ObservableCollection<Entity>();

        public ViewModel()
        {
            Entities.Add(new Entity(10, 10, 10, 10));
            Entities.Add(new Entity(50, 20, 25, 25));
        }

        public ObservableCollection<Entity> Entities
        {
            get { return _entities; }
        }

        public void MoveEntitiesToRight()
        {
            foreach (var entity in Entities)
            {
                entity.X++;
            }
        }
    }
}
