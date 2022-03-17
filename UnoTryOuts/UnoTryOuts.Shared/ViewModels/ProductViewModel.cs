namespace UnoTryOuts.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private bool _isSelected;

        public int ID
        {
            get => _id;
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
