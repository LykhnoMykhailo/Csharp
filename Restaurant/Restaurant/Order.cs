using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum Phase
    {
        New, // 0
        InProgress, // 1
        Ready, // 2
        Paid  // 3
    }
    public class Order : IOrders
    {
        private readonly int _id;
        private readonly int _table;
        private decimal _price;

        private Phase _currentPhase;

        public int Id => _id;
        public int Table => _table;
        public decimal Price => _price;
        public List<Dish> OrderItems { get; private set; }

        public string PhaseStatus => _currentPhase.ToString();

        public Order(int id, int table)
        {
            _id = id;
            _price = 0;
            _table = table;

            _currentPhase = Phase.New;

            OrderItems = new List<Dish>();
        }

        public void ADDUpdate(Dish dish)
        {
            decimal cost = dish.return_value();
            OrderItems.Add(dish);

            _currentPhase = Phase.InProgress;

            _price += cost;
            Console.WriteLine($"До замовлення {Id} Додано {dish.return_name()}");
            Console.WriteLine($"Статус замовлення {Id} змінено на {PhaseStatus}");
        }

        public void DELETEUpdate(Dish dish)
        {
            Dish itemToRemove = OrderItems.FirstOrDefault(item => item == dish);

            if (itemToRemove != null)
            {
                decimal cost = itemToRemove.return_value();
                _price -= cost;
                OrderItems.Remove(itemToRemove);
                Console.WriteLine($"Із замовлення {Id} Видалено {itemToRemove.return_name()}");

                if (!OrderItems.Any())
                {
                    _currentPhase = Phase.New;
                    Console.WriteLine($"Замовлення {Id} стало порожнім. Статус: {PhaseStatus}");
                }
            }
        }

        public void NextPhase()
        {
            int currentPhaseIndex = (int)_currentPhase;

            if (currentPhaseIndex < (int)Phase.Paid)
            {
                int nextPhaseIndex = currentPhaseIndex + 1;

                _currentPhase = (Phase)nextPhaseIndex;

                Console.WriteLine($"Статус замовлення {Id} змінено на {PhaseStatus}");
            }
            else
            {
                Console.WriteLine($"Замовлення {Id} вже знаходиться у кінцевій фазі: {PhaseStatus}");
            }
        }
        public int return_id()
        {
            return _id;
        }
        public int return_table()
        {
            return _table;
        }
        public string return_phase()
        {
            return PhaseStatus;
        }
        public decimal return_price()
        {
            return _price;
        }
        public List<Dish> return_dish() {
            return OrderItems;
                }
        public void show_order()
        {
            Console.WriteLine($"{return_id()} Столик - {return_table()}, Ціна - {return_price()}, Статус - {return_phase()}");
            if (return_dish().Count != 0)
            {
                Console.WriteLine("  Замовлення: ");
                int time_count = 0;
                foreach (Dish dish in return_dish())
                {
                    time_count++;
                    Console.WriteLine($"  {time_count}\\ ");
                    if (dish is Drink drinkItem)
                    {
                        drinkItem.show_info_order();
                    }
                    else if (dish is Food foodItem)
                    {
                        foodItem.show_info_order();
                    }
                }
            }
        }

    }
    }

