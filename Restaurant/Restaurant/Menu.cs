using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Menu
    {
        int all_id = 0;
        private List<Dish> MenuItems { get; set; }
        public Menu()
        {

            MenuItems = new List<Dish>();

        }

        public void Add(Dish dish)
        {
            if (!MenuItems.Contains(dish))
            {
                all_id += 1;
                if (dish is Drink drinkItem)
                {
                    drinkItem.set_id(all_id);
                }
                else if (dish is Food foodItem)
                {
                    foodItem.set_id(all_id);
                }
                MenuItems.Add(dish);
            }
        }
        public Dish GetDishById(int id)
        {
            foreach (Dish dish in MenuItems) { 
            if (dish.return_id() == id)
                {
                    return dish;
                  
                }
            }
            return null;
        }
        public void Show_Menu()
        {
            Console.WriteLine(" ==== Меню ====");
            foreach (Dish dish in MenuItems)
            {
                if (dish is Drink drinkItem)
                {
                    drinkItem.show_info_menu();
                }
                else if (dish is Food foodItem)
                {
                    foodItem.show_info_menu();
                }
            }
            Console.WriteLine(" ==== ==== ==== ");
        }
    }
}
