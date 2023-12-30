using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch06_Dictionary
{
    public class DictTest
    {
        public void Test()
        {
        }

        private void init()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("green", 1);
            dict.Add("yellow", 2);
            dict.Add("red", 3);
            dict.Add("blue", 4);
            dict.Remove("blue");
            Console.WriteLine($"{dict["red"]}"); // 3
        }

        class PointsDictionary
        {
            public Dictionary<string, int> _points;
            public PointsDictionary()
            {
                _points = new Dictionary<string, int>();
            }

            private int UpdateCustomerPoints(string customerName, int points)
            {
                if(CustomerExists(customerName))
                {
                    _points[customerName] += points;
                    return _points[customerName];
                }
                return 0;
            }

            public void RegisterCustomer(string customerName)
            {
                RegisterCustomer(customerName, 0);
            }

            public void RegisterCustomer(string customerName, int previousBalance)
            {
                _points.Add(customerName, previousBalance);
            }

            public int GetCustomerPoints(string customerName)
            {
                _points.TryGetValue(customerName, out int points);
                return points;
            }

            public int AddCustomerPoints(string customerName, int points)
            {
                return UpdateCustomerPoints(customerName, points);
            }

            public int RemoveCustomerPoints(string customerName, int points) 
            {
                return UpdateCustomerPoints(customerName, -points);
            }

            public int RedeemCustomerPoints(string customerName, int points)
            {
                // any possible operation
                return UpdateCustomerPoints(customerName, -points);
            }

            public int CustomerCheckout(string customerName)
            {
                int points = GetCustomerPoints(customerName);
                _points.Remove(customerName);
                return points;
            }

            public bool CustomerExists(string customerName)
            {
                return _points.ContainsKey(customerName);
            }

            public int CustomerOnPremises()
            {
                return _points.Count;
            }

            public void ClosingTime()
            {
                _points.Clear();
            }
        }
    }
}
