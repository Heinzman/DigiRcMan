using System.ComponentModel;

namespace WpfEvalApp2
{
    public class Entity : INotifyPropertyChanged
    {
        private int _width;
        private int _height;
        private int _y;
        private int _x;

        public event PropertyChangedEventHandler PropertyChanged;

        public Entity(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("X"));
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                _y = value; 
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Y"));
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value; 
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Width"));
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                _height = value; 
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Height"));
            }
        }
    }
}