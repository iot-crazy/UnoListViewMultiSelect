using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UnoTryOuts.ViewModels
{
    internal class MainPageViewModel : DispatchedBindableBase
    {
        private ObservableCollection<ProductViewModel> _products;
        private ObservableCollection<BasketViewModel> _baskets;


        public MainPageViewModel()
        {
            Products = GetProducts();
            Baskets = GetBaskets();
        }


        public ObservableCollection<ProductViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ObservableCollection<BasketViewModel> Baskets
        {
            get => _baskets;
            set => SetProperty(ref _baskets, value);
        }


        private ObservableCollection<ProductViewModel> GetProducts()
        {
            var products = new List<ProductViewModel>
            {
                new ProductViewModel() { ID = 1, Name = "Apple"  },
                new ProductViewModel() { ID = 2, Name = "Pear"  },
                new ProductViewModel() { ID = 3, Name = "Banana" },
                new ProductViewModel() { ID = 4, Name = "Plum" },
                new ProductViewModel() { ID = 5, Name = "Carrot" },
                new ProductViewModel() { ID = 6, Name = "Potato" },
                new ProductViewModel() { ID = 7, Name = "Avocado" },
                new ProductViewModel() { ID = 8, Name = "Strawberry" },
                new ProductViewModel() { ID = 9, Name = "Lemon" },
                new ProductViewModel() { ID = 10, Name = "Parsnip" }
            };

            return new ObservableCollection<ProductViewModel>(products);
        }

        private ObservableCollection<BasketViewModel> GetBaskets()
        {
            var baskets = new List<BasketViewModel>
            {
                new BasketViewModel() { ID = 1, Title = "Basket 1", Products = GetProductsForBasket(new int[] {1,2,3,4 }) },
                new BasketViewModel() { ID = 2, Title = "Basket 2", Products = GetProductsForBasket(new int[] {10,9,8,7,6,5 } )},
                new BasketViewModel() { ID = 3, Title = "Basket 3", Products = GetProductsForBasket(new int[] {4,5,6 }) },
                new BasketViewModel() { ID = 4, Title = "Basket 4", Products = GetProductsForBasket(new int[] {7 }) }
            };

            return new ObservableCollection<BasketViewModel>(baskets);
        }

        private ObservableCollection<ProductViewModel> GetProductsForBasket(int[] ids)
        {
            return new ObservableCollection<ProductViewModel>(_products.Where(x => ids.Contains(x.ID)));
        }
    }
}
