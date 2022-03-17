using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnoTryOuts.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UnoTryOuts
{
    public sealed partial class ProductListView : UserControl, INotifyPropertyChanged
    {
        public static DependencyProperty ProductsProperty =
           DependencyProperty.Register("Products", typeof(List<ProductViewModel>), typeof(ProductListView), null)
         ;

        public static DependencyProperty SelectedProductsProperty =
           DependencyProperty.Register("SelectedProducts", typeof(ObservableCollection<ProductViewModel>), typeof(ProductListView), new PropertyMetadata(null, OnSelectedProductsSourceChanged));

        public ProductListView()
        {
            this.InitializeComponent();

        }

        public ObservableCollection<ProductViewModel> Products
        {
            get => (ObservableCollection<ProductViewModel>)GetValue(ProductsProperty);
            set => SetValue(ProductsProperty, value);
        }

        public ObservableCollection<ProductViewModel> SelectedProducts
        {
            get => (ObservableCollection<ProductViewModel>)GetValue(SelectedProductsProperty);
            set => SetValue(SelectedProductsProperty, value);
        }

        private void OnSelectionChanged(object _, SelectionChangedEventArgs e)
        {
            foreach (ProductViewModel product in e.AddedItems)
            {
                if (SelectedProducts.Contains(product) == false)
                {
                    SelectedProducts.Add(product);
                }
            }

            foreach (var product in e.RemovedItems)
            {
                SelectedProducts.Remove((ProductViewModel)product);
            }
        }


        private static void OnSelectedProductsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ProductListView)d).SetSelected();
        }

        public void SetSelected()
        {
            foreach (var item in lstProducts.Items)
            {
                var listitem = (ListViewItem)lstProducts.ContainerFromItem(item);
                listitem.IsSelected = SelectedProducts.Contains((ProductViewModel)item);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
