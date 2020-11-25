using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using POS_Demo.Domain.Model;
using POS_Demo.Domain.Repositories;
using POS_Demo.Services;

namespace POS_Demo.OrderWindow
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly CategoriesRepo _categoriesRepo;

        public ICommand AddProductCommand { get; set; }
        public ICommand IncreaseQtyCommand { get; set; }
        public ICommand DecreaseQtyCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        #region Property for Data binding
        private double _totalPrice = 0;
        private ObservableCollection<Categories> _categoriesList;
        private ObservableCollection<OrderedProductModel> _orderedProducts;

        public double TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        public ObservableCollection<Categories> CategoriesList { 
            get { return _categoriesList; } 
            set { 
                _categoriesList = value;
                OnPropertyChanged("CategoriesList");
            }
        }
        public ObservableCollection<OrderedProductModel> OrderedProducts {
            get { return _orderedProducts; }
            set { 
                _orderedProducts = value;
                OnPropertyChanged("OrderedProducts");
            }
        }
        #endregion

        public OrderViewModel(CategoriesRepo categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
            OrderedProducts = new ObservableCollection<OrderedProductModel>();
            CategoriesList = new ObservableCollection<Categories>();

            AddProductCommand = new RelayCommand((parameter) => AddProductToOrder(parameter));
            IncreaseQtyCommand = new RelayCommand((parameter) => IncreaseQty(parameter));
            DecreaseQtyCommand = new RelayCommand((parameter) => DecreaseQty(parameter));

            LoadCategory();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return "Is binding";
        }


        public async void LoadCategory()
        {
            var categoriesData = await _categoriesRepo.GetAllCategories();
            CategoriesList = new ObservableCollection<Categories>(categoriesData);            
        }

        private void AddProductToOrder(object parameter)
        {
            var product = parameter as Products;
            var newOrderProduct = new OrderedProductModel();

            //if(product.ProductVariants.Count() > 1)
            //{
            //    // pop up other window let it select
            //}
            //else
            //{
            newOrderProduct.ProductVariant = product.ProductVariants[0];
            newOrderProduct.ProductVariantId = product.ProductVariants[0].ProductVariantId;
            //}

            if (OrderedProducts.Any(x => x.ProductVariantId == newOrderProduct.ProductVariantId))
            {
                // If add existing item

                newOrderProduct = OrderedProducts.Where(x => x.ProductVariantId == newOrderProduct.ProductVariantId).FirstOrDefault();
                newOrderProduct.Quantity++;
                newOrderProduct.ProductPrice = CalculateProductPrice(newOrderProduct);
            }
            else
            {
                // If add new item
                newOrderProduct.Quantity = 1;
                newOrderProduct.ProductPrice = CalculateProductPrice(newOrderProduct);

                OrderedProducts.Add(newOrderProduct);
            }

            UpdateTotalPrice();
        }

        private void IncreaseQty(object Parameter)
        {
            var orderedProduct = Parameter as OrderedProductModel;
            orderedProduct.Quantity++;
        }

        private void DecreaseQty(object Parameter)
        {
            var orderedProduct = Parameter as OrderedProductModel;

            if(orderedProduct.Quantity > 1)
                orderedProduct.Quantity--;
            else            
                OrderedProducts.Remove(orderedProduct);            
        }


        #region Helper function
        private double CalculateProductPrice(OrderedProductModel Product)
        {
            return Product.ProductVariant.ProductPrice * Product.Quantity;
        }

        private void UpdateTotalPrice()
        {
            TotalPrice = OrderedProducts.Sum(x => x.ProductPrice);
        }
        #endregion
    }
}
