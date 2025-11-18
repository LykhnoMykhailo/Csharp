using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Dish
    {
        protected string Name { get; set; }
        protected decimal Value { get; set; }
        protected int Id = 0;
        protected Dish(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        protected void show_info_menu()
        {
            Console.WriteLine($"Позиція в меню {Id} має назву {Name} та ціну {Value}");
        }
        public int return_id()
        {
            return Id;
        }
        public string return_name()
        {
            return Name;
        }
        public decimal return_value()
        {
            return Value;
        }
        public void set_id(int id)
        {
            Id = id;
        }
    }
}
