using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Restaurant : IRestaurant
    {
        private decimal _price;
        private int _id_order;
        
        private List<int> _tables = new List<int> { 001,002,003,004 };
        private List<Order> _orders = new List<Order>();

        public Restaurant()
        {
            _orders = new List<Order>();
            _id_order = 1;
        }
        private Order create_order(int id, int table)
        {

            return new Order(id, table);
        }
        public void Create_Order()
        {
            if (_tables.Count != 0)
            {
                Console.WriteLine($"Створено замовлення {_id_order}");
                _orders.Add(create_order(_id_order, _tables[0]));
                _tables.Remove(_tables[0]);
                _id_order += 1;
            }
            else { Console.WriteLine("Нажаль вільних місць немає"); }
        }
        public void Remove_Order(int id)
        {
            Order order_time = null;
            foreach (Order order in _orders)
            {
                if (order.return_id() == id)
                {
                    Console.WriteLine($"Завершено замовлення {order.return_id()}");
                    order_time = order;
                    _orders.Remove(order_time);
                    _tables.Add(order_time.return_table());
                    break;

                }
            }

        }
        public void Show_Orders()
        {
            Console.WriteLine("\n=================== Замовлення ======================\n");
            foreach (Order order in _orders)
            {
                order.show_order();
            }
            Console.WriteLine("\n=====================================================\n");
        }
        public Order return_order(int id)
        {
            if (_orders.Count >= id)
            {
                return _orders[id-1];
            }
            else
            {
                return null;
            }
        }

    }
}
