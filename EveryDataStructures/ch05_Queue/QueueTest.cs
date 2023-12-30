using System.Collections.Generic;

namespace ch05_Queue
{
    public class QueueTest
    {
        public void Test()
        {
        }

        private void init()
        {
            Queue<Customer> customers= new Queue<Customer>();
            customers.Enqueue(new Customer());
            customers.Dequeue();
        }

        class CustomerQueue
        {
            Queue<Customer> _customers;
            int _cap;
            public CustomerQueue(int cap)
            {
                _customers = new Queue<Customer>();
                _cap = cap;
            }

            private bool CanCheckinCustomer()
            {
                return _customers.Count < _cap;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <param name="customer"></param>
            public void CustomerCheckin(Customer customer)
            {
                if (CanCheckinCustomer())
                {
                    _customers.Enqueue(customer);
                }
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public Customer CustomerConsultation()
            {
                return _customers.Peek();
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public void CustomerCheckout()
            {
                _customers.Dequeue();
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public void ClearCustomers()
            {
                _customers.Clear();
            }

            /// <summary>
            /// O(n)
            /// </summary>
            /// <returns></returns>
            public void CustomerCancel(Customer c)
            {
                Queue<Customer> tempQueue = new Queue<Customer>();
                foreach (var cust in _customers)
                {
                    if (cust.Equals(c))
                        continue;
                    tempQueue.Enqueue(c);
                }

                _customers = tempQueue;
            }

            /// <summary>
            /// O(2n)
            /// contains: O(n)
            /// foreach: O(n)
            /// 实际项目中，一般会根据业务进行优化，以提高性能，降低计算代价
            /// </summary>
            /// <returns></returns>
            public int CustomerPosition(Customer c)
            {
                if (_customers.Contains(c))
                {
                    int i = 0;
                    foreach (var cust in _customers)
                    {
                        if (cust.Equals(c))
                            return i;
                        i++;
                    }
                }
                return -1;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public int CustomerInline()
            {
                return _customers.Count;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public bool IslineEmpty()
            {
                return _customers.Count == 0;
            }

            /// <summary>
            /// O(1)
            /// </summary>
            /// <returns></returns>
            public bool IslineFull()
            {
                return _customers.Count == _cap;
            }

        }

        class Customer
        {
            public string Name { get; set; }
        }
    }
}
