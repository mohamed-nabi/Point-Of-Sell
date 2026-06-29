using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPOS_Models
{
    public class clsBasketItem : INotifyPropertyChanged
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value)
                    return;

                _quantity = value;

                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(Total));
            }
        }

        [Browsable(false)]
        public int ProductID { get; set; }
        public decimal Total => Quantity * UnitPrice;
        public int InvUnitID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        public clsBasketItem(int productID, int invUnitID,
            string productName, decimal unitPrice, int quantity)
        {
            ProductID = productID;
            InvUnitID = invUnitID;
            ProductName = productName;
            UnitPrice = unitPrice;
            _quantity = quantity;
        }
    }
}
