namespace task2
{
    class Shop : IDisposable
    {
        private string name;
        private string address;
        private string type_shope;

        public Shop()
        {
            name = "-";
            address = "-";
            type_shope = "-";
        }

        public void Show_shop()
        {
            Console.WriteLine($"\t___Shop___" +
                              $"\nName: {name}" +
                              $"\nAddress: {address}" +
                              $"\nType_shope: {type_shope}");
        }

        public void New_shop()
        {
            bool FLAG = true;

            while (FLAG)
            {
                Console.WriteLine("Создание магазина");
                Console.WriteLine("1. Создать магазин");
                Console.WriteLine("2. Показать магазин");
                Console.WriteLine("3. Выход");
                Console.Write("Введите ваш выбор: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Введите название магазина: ");
                    name = Console.ReadLine();
                    Console.Write("Введите адрес магазина: ");
                    address = Console.ReadLine();
                    Console.WriteLine("Выбери тип магазина:" +
                                      "\n1. Продовольственный" +
                                      "\n2. Хозяйственный" +
                                      "\n3. Одежда" +
                                      "\n4. Обувь" +
                                      "\n5. Выход");
                    Console.Write("Введите ваш выбор: ");
                    int choice_shop = Int32.Parse(Console.ReadLine());
                    switch(choice_shop)
                    {
                        case 1:
                            type_shope = "Продовольственный";
                            Console.WriteLine($"\nТип выбран: {type_shope}");
                            break;
                        case 2:
                            type_shope = "Хозяйственный";
                            Console.WriteLine($"\nТип выбран: {type_shope}");
                            break;
                        case 3:
                            type_shope = "Одежда";
                            Console.WriteLine($"\nТип выбран: {type_shope}");
                            break;
                        case 4:
                            type_shope = "Обувь";
                            Console.WriteLine($"\nТип выбран: {type_shope}");
                            break;
                        case 5:
                            Console.WriteLine("Спасибо за выбор!");
                            Show_shop();
                            break;
                        default:
                            Console.WriteLine("Ошибка выбора: введите корректно");
                            break;

                    }
                }
                else if (choice == "2")
                {
                    Show_shop();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Новый магазин был создан!");
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильный выбор.");
                }
            }
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose");
            name = null;
            address = null;
            type_shope = null;
        }

        ~Shop()
        {
            Console.WriteLine("Деструктор");
            Dispose();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shop _shop = new Shop();
            _shop.New_shop();
            _shop.Dispose();
            Console.Read();
        }
    }
}