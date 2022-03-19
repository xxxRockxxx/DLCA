using System;

namespace DLCA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите радиус глобулы в клетках: "); //Не мешало бы пояснение)
            int Radius = int.Parse(Console.ReadLine());
            Dlca dlca = new Dlca(Radius);

        }
    }
}
