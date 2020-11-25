using POS_Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Demo.OrderWindow
{
    public class OrderedProductModel : INotifyPropertyChanged
    {
        private int _quantity;
        private double _productPrice;

        public int ProductVariantId { get; set; }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisedOnPropertyChanged("Quantity");
            }
        }
        public double ProductPrice
        {
            get { return _productPrice; }
            set
            {
                _productPrice = value;
                RaisedOnPropertyChanged("ProductPrice");
            }
        }
        public float Discount { get; set; }
        public string Remark { get; set; }


        public virtual ProductVariant ProductVariant { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}
