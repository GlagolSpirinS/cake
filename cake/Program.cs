using cake;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System.Security.Authentication.ExtendedProtection;
using static System.Formats.Asn1.AsnWriter;

namespace Application
{
    class Program
    {
        public static int price = 0;
        public static int pos = 0;
        static void Main(string[] args)
        {

            Class1 forma1 = new Class1("  Квадрат",50);
            Class1 forma2 = new Class1("  Круг",100);
            Class1 forma3 = new Class1("  Конус", 150);
            Class1 forma4 = new Class1("  Пирамида", 200);

            Class1 color1 = new Class1("  Красный", 50);
            Class1 color2 = new Class1("  Синий", 100);
            Class1 color3 = new Class1("  Зелёный", 150);
            Class1 color4 = new Class1("  Белый", 200);

            Class1 size1 = new Class1("  Маленький", 50);
            Class1 size2 = new Class1("  Средний", 100);
            Class1 size3 = new Class1("  Большой", 150);

            Class1 shugar1 = new Class1("  Без сахара", 0);
            Class1 shugar2 = new Class1("  Среднее количество сахара", 100);
            Class1 shugar3 = new Class1("  Большое количество сахара", 150);

            Class1 glaz1 = new Class1("  Без глазури", 0);
            Class1 glaz2 = new Class1("  С глазурью", 100);

            Menu forma = new();
            forma.Class1 = new List<Class1>()
            {
                forma1,
                forma2,
                forma3,
                forma4,
            };
            forma.Name = "  Формы";

            Menu color = new();
            color.Class1 = new List<Class1>()
            {
                color1,
                color2,
                color3,
                color4,
            };
            color.Name = "  Цвет";

            Menu size = new();
            size.Class1 = new List<Class1>()
            {
               size1,
               size2,
               size3,
            };
            size.Name = "  Размер";

            Menu shugar = new();
            shugar.Class1 = new List<Class1>()
            {
               shugar1,
               shugar2,
               shugar3,
            };
            shugar.Name = "  Сахар";

            Menu glaz = new();
            glaz.Class1 = new List<Class1>()
            {
                glaz1,
                glaz2,
            };
            glaz.Name = "  Глазурь";


            List<Menu> allMenus = new List<Menu>()
                {
                    color,
                    forma,
                    size,
                    shugar,
                    glaz,
            };
            while (true)
            {
                foreach (Menu item in allMenus)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Цена торта: "+price);
                Console.WriteLine("Для завершения заказа нажмите Backspace(стереть)");
                int pos = strelka();
                Console.Clear();
                foreach (Class1 podPunkt in allMenus[pos].Class1)
                {
                    Console.WriteLine(podPunkt.Name);
                }
                int posPodPunkt = strelka();
                Zakaz(allMenus[pos].Class1[posPodPunkt]);
                Console.Clear();

            }

            static int strelka()
            {
                var key = Console.ReadKey();
                while (key.Key != ConsoleKey.Enter)
                {
                    ClearArrows();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            pos--;
                            if (pos < 0)
                            {
                                pos++;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            pos++;
                            break;
                        case ConsoleKey.Backspace:
                            VivodFile();
                            break;
                    }
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
                return pos;
            }

            static void Zakaz(Class1 punkt)
            {
                price += punkt.Price;
            }

            static void ClearArrows()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine("  ");
                }
            }

            static void VivodFile()
            {
                Console.Clear();
                pos++;
                Console.WriteLine("Ваш заказ сохранён на рабочем столе");

                string file = "Заказ от " + DateTime.Now + "\n\t Заказ: Торт" + "\n\t Цена: " + Program.price + "\n";
                File.AppendAllText("C:\\Users\\root\\Desktop\\zakazi\\Zakaz.txt", file);
            }
        }
    }
}