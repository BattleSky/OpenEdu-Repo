using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double _price;
        private int _nightsCount;
        private double _discount;
        private double _total;

        private double GetPrice(double discount)
        { return _price * _nightsCount * (1 - discount / 100); }

        private double GetDiscount(double total)
        { return ((_price * _nightsCount - total) * 100) / (_price * _nightsCount); }

        public double Price
        {
            get { return _price;}
            set
            {
                if (value < 0) throw new ArgumentException();
                _price = value;
                _total = GetPrice(_discount);
                Notify(nameof(Price));
                Notify(nameof(Total));
            } 
        }

        public int NightsCount
        {
            get { return _nightsCount; }
            set
            {
                if (value <= 0) throw new ArgumentException();
                _nightsCount = value;
                _total = GetPrice(_discount);
                Notify(nameof(NightsCount));
                Notify(nameof(Total));
            }
        }

        public double Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                _total = GetPrice(value);
                if (_total < 0) throw new ArgumentException();
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                _total = value;
                _discount = GetDiscount(value);
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }
    }
}