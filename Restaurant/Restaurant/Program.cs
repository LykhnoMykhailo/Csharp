using System.Security.Cryptography.X509Certificates;

namespace Restaurant
{
    internal class Program
    {
        static void RunConsoleMenu(Menu menu, Restaurant restaurant)
        {
            bool working = true;
            while (working)
            {
                Console.WriteLine("\n================== +++++++++++++ ==================");
                Console.WriteLine("Оберіть дію:");
                Console.WriteLine("1. Створити нове замовлення");
                Console.WriteLine("2. Показати всі активні замовлення");
                Console.WriteLine("3. Додати страву до замовлення");
                Console.WriteLine("4. Видалити страву із замовлення");
                Console.WriteLine("5. Змінити статус замовлення (Наступна фаза)");
                Console.WriteLine("6. Закрити (видалити) замовлення");
                Console.WriteLine("7. Показати повне меню");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("=====================================================");

                Console.Write("Ваш вибір: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            restaurant.Create_Order();
                            break;
                        case 2:
                            restaurant.Show_Orders();
                            break;
                        case 3:
                            restaurant.Show_Orders();
                            Console.Write("Введіть ID замовлення: ");

                            if (int.TryParse(Console.ReadLine(), out int orderIdAdd) && orderIdAdd > 0)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    Order order = restaurant.return_order(orderIdAdd);
                                    if (order != null)
                                    {
                                        Console.WriteLine($"{order.return_id()},  {orderIdAdd}");
                                        if (order.return_id() == orderIdAdd)
                                        {
                                            menu.Show_Menu();
                                            Console.WriteLine("");

                                            Console.Write("Введіть ID страви з меню: ");

                                            if (int.TryParse(Console.ReadLine(), out int dishIdAdd) && dishIdAdd > 0)
                                            {
                                               

                                                Dish dish = menu.GetDishById(dishIdAdd);
                                                if (order != null)
                                                {
                                                    if (order.return_id() == orderIdAdd && dish != null)
                                                    {
                                                        order.ADDUpdate(dish);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("[ПОМИЛКА] Неправильний ID замовлення, або страви.");
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("[ПОМИЛКА] Неправильний ID замовлення.");
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                            break;
                        case 4:
                            restaurant.Show_Orders();
                            Console.Write("Введіть ID замовлення: ");
                            if (int.TryParse(Console.ReadLine(), out int orderIdRemove) && orderIdRemove > 0)
                            {
                                Order order = restaurant.return_order(orderIdRemove);
                                order.show_order();
                                Console.Write("Введіть ID страви, яку потрібно видалити: ");
                                if (int.TryParse(Console.ReadLine(), out int dishIdAdd) && dishIdAdd > 0)
                                {
                                    

                                    Dish dish = menu.GetDishById(dishIdAdd);
                                    if (order != null && dish != null)
                                    {
                                        order.DELETEUpdate(dish);
                                    }
                                    else
                                    {
                                        Console.WriteLine("[ПОМИЛКА] Неправильний ID замовлення або страви.");
                                    }
                                }
                            }
                            break;
                        case 5:
                            restaurant.Show_Orders();
                            Console.Write("Введіть ID замовлення для зміни статусу: ");
                            if (int.TryParse(Console.ReadLine(), out int orderIdNext) && orderIdNext > 0)
                            {
                                Order order = restaurant.return_order(orderIdNext);
                                order?.NextPhase();
                            }
                            break;
                        case 6:
                            restaurant.Show_Orders();
                            Console.Write("Введіть ID замовлення для закриття: ");
                            if (int.TryParse(Console.ReadLine(), out int orderIdClose) && orderIdClose > 0)
                            {
                                restaurant.Remove_Order(orderIdClose);
                            }
                            break;
                        case 7:
                            menu.Show_Menu();
                            break;
                        case 0:
                            working = false;
                            Console.WriteLine("Програма завершена.");
                            break;
                        default:
                            Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Будь ласка, введіть число.");
                }
            }

        }
        static void Main(string[] args)
        {
            Drink Coffee = new Drink("Coffe", 40, 0.5f);
            Drink Tea_black = new Drink("Black Tea", 25, 0.55f);
            Drink Tea_green = new Drink("Green Tea", 27, 0.55f);
            Drink Water = new Drink("Water", 10, 1f);
            Drink Juice = new Drink("Juice", 34, 1.2f);
            Food Duck = new Food("Duck", 70);
            Food Rice = new Food("Rice", 40);
            Food Meatballs = new Food("Meatballs", 76);
            Food Paste = new Food("Paste", 50);
            Food Soup = new Food("Soup", 105);
            Menu Menu1 = new Menu();
            Menu1.Add(Coffee);
            Menu1.Add(Tea_black);
            Menu1.Add(Tea_green);
            Menu1.Add(Water);
            Menu1.Add(Juice);
            Menu1.Add(Duck);
            Menu1.Add(Rice);
            Menu1.Add(Meatballs);
            Menu1.Add(Paste);
            Menu1.Add(Soup);

            
            Restaurant New_restaurant = new Restaurant();
            IRestaurant restauratn = New_restaurant;

            RunConsoleMenu(Menu1, New_restaurant);

        }
    }
}
