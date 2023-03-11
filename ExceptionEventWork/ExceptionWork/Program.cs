using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var exception = new Exception[] {new ArgumentException(), new MyException("Число больше 40"),
                new DivideByZeroException(), new TimeoutException(),
                new  IndexOutOfRangeException()};

            var massiv = new int[] { 600, 550, 800, 900, 600, 160, 140 };
            foreach (var i in massiv)
            {
                Console.Write(i+",");
            }
            Console.WriteLine();
            try
            {
                Console.WriteLine("Выберете числитель из списка чисел, указав номер числа");
                var num1 = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Введите знаменатель(целое число) и не больше 40");
                var num2 = int.Parse(Console.ReadLine());

                if (num2 > 40) throw  exception[1];

                var result = massiv[num1] / num2;
                Console.WriteLine("Ответ: " + result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MyException ex)
            {             
                Console.WriteLine(ex.Message);               
            }
            finally
            {
                Console.WriteLine("Программа закончила свою работу");
            }


        }
    }

    public class MyException : Exception
    {

        public MyException()
        { }

        public MyException(string message)
            : base(message)
        { }


    }
}
