using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Food : Dish
    {
        public Food(string name, decimal value) : base(name, value)
        {
        }
        public void show_info_menu()
        {
            Console.WriteLine($"-- {Id}   {Name} Ціна -> {Value}");
        }
        public void show_info_order()
        {
            Console.WriteLine($"   {Name} Ціна -> {Value}");
        }
    }
}
