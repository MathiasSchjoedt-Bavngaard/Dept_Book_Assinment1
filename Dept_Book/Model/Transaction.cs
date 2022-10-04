using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions.Behaviors;

namespace Debt_Book.Model
{
    public class Transaction : BindableBase
    {
        public Transaction()
        {
            Value = 0;
            Date = DateTime.Now;
        }
        public Transaction(double value)
        {
            Value = value;
            Date = DateTime.Now;
        }

        #region Properties
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                SetProperty(ref _date, value);
            }

        }

        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != 0)
                    _value = value;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Value} {Date}";
        }
        #endregion
    }
}
