using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Drink : Dish
    {
        protected float Volume { get; set; }
        public Drink (string name, decimal value, float volume) : base(name,value)
        {
            Volume = volume;
        }
        public void show_info_menu()
        {
            Console.WriteLine($"-- {Id}   {Name} Ціна -> {Value} / {Volume}Л");
        }
        public void show_info_order()
        {
            Console.WriteLine($"   {Name} Ціна -> {Value} / {Volume}Л");
        }
    }
}
