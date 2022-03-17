using System.Collections.ObjectModel;

namespace UnoTryOuts.ViewModels
{
    public class BasketViewModel : DispatchedBindableBase
    {

        private int _id;
        private string _title;
        private ObservableCollection<ProductViewModel> _products;

        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<ProductViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

    }
}
