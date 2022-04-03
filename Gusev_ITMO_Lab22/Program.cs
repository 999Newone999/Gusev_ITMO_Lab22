using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusev_ITMO_Lab22
{
    class Program
    {
        /*  Сформировать массив случайных целых чисел (размер  задается пользователем).
         * Вычислить сумму чисел массива и максимальное число в массиве.  
         * Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.*/

        static int massiveSize = 0;
        static int[] massiveRandom;

        static void MakeRandomArray()
        {
            Random rnd = new Random();

            Console.WriteLine("Массив: ");

            for (int i = 0; i < massiveSize; i++)
            {
                massiveRandom[i] = rnd.Next(0,1000);
                Console.WriteLine("{0}: {1}", i+1, massiveRandom[i]);
            }
        }

        static void SummArray(Task task)
        {
            int sum=0;
            for (int i = 0; i < massiveSize; i++)
            {
                sum += massiveRandom[i];
            }
            Console.WriteLine("Сумма чисел массива: {0}", sum);
        }

        static void MaxArray(Task task)
        {
            int max = 0;
            for (int i = 0; i < massiveSize; i++)
            {
                if (max < massiveRandom[i])
                {
                    max = massiveRandom[i];
                }
            }
            Console.WriteLine("Наибольшее число в массиве: {0}", max);
        }

        static void Main(string[] args)
        {
            bool inputOk=true;
            do
            {
                inputOk = true;
                Console.Write("Введите размер массива случаных целых чисел: ");
                try 
                {
                    massiveSize = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputOk = false;
                }
            }while(!inputOk);

            massiveRandom = new int[massiveSize];

            Action action1 = new Action(MakeRandomArray);
            Task task1 = new Task(action1);
            task1.Start();

            Action<Task> action2 = new Action<Task>(SummArray);
            Task task2 = task1.ContinueWith(action2);

            Action<Task> action3 = new Action<Task>(MaxArray);
            Task task3 = task1.ContinueWith(action3);

            Console.ReadKey();
        }
    }
}
