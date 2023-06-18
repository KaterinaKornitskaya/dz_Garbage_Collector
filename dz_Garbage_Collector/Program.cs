namespace dz_Garbage_Collector
{
    // Задание 1.
    // Создайте класс Пьеса. Класс должен хранить: - название пьесы,
    // - ФИО автора, - жанр, -год выпуска. Реализуйте методы и свойства.
    // Добавьте в класс деструктор. Напишите код для для вызова
    // деструктора.
    // Задание 3.
    // Добавьте у 1му заданию реализацтю интерфейса IDisposable.
    internal class Program
    {
        static void Main(string[] args)
        {

            Play p1 = new Play("Дети Ванюшина", "Сергей Найденов", "-", 1901);
            Play p2 = new Play("На дне", "Максим Горький", "-", 1902);
            Play p3 = new Play("Четырнадцатое июля", "Ромен Роллан", "-", 1902);
            Play p4 = new Play("Вишневый сад", "Антон Чехов", "-", 1903);
            Play p5 = new Play("Чудо святого Антония", "Морис Метерлинк", "-", 1903);
            Play p6 = new Play("Мораль пани Дульской", "Габриеля Запольская", "-", 1906);
            Play p7 = new Play("Соната призраков", "Август Стриндберг", "-", 1907);
            Play p8 = new Play("Жизнь человека", "Леонид Андреев", "-", 1907);
            Play p9 = new Play("Игра интересов", "Хасинто Бенавенте-и-Мартинес", "-", 1907);
            
            Play[] p_arr = { p1, p2, p3, p4, p5, p6, p7, p8, p9 };

            foreach (Play item in p_arr)
            {
                Console.WriteLine(item.ToString());
            }

            foreach (Play item in p_arr)
            {
                item.Dispose();
            }
           
            Console.WriteLine($"Поколение объекта: {GC.GetGeneration(p_arr)}");          
            Console.WriteLine($"Занято памяти (байт): {GC.GetTotalMemory(false)}");
            
            GC.Collect();

            Console.WriteLine($"Поколение объекта: {GC.GetGeneration(p_arr)}");
            Console.WriteLine($"Занято памяти (байт): {GC.GetTotalMemory(false)}");
        }
    }

    class Play : IDisposable
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Play(string title, string authorName, string genre, int year)
        {
            Title=title;
            AuthorName=authorName;
            Genre=genre;
            Year=year;
        }

        public override string ToString()
        {
            return $"Play title\t {Title} \nAuthor name\t {AuthorName}" +
                $"\nPlay genre\t {Genre} \nYear of edition\t {Year}\n";
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose.");
            Title = null;
            AuthorName = null;
            Genre  =null;
            Year = 0;
        }
        ~Play()
        {
            Console.WriteLine("Play - Деструктор вызван.");
            Dispose();
        }
    }
}