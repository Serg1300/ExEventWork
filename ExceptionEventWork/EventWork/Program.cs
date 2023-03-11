using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fullName = new List<string>() {"Иванов","Сидоров","Филатов","Якушев","Сапунов" };
            EnterNumber enterNumber = new EnterNumber();
            enterNumber.EnterNumEvent += SortName;
            try
            {
                enterNumber.NumberRead(fullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void SortName ( List<string>name, int index)
        {
            if(index == 1) { name.Sort(); }
            else if(index == 2) 
            {
                name.Sort();
                name.Reverse();
            }
            foreach (var item in name)
            {
                Console.WriteLine(item);
            }
        }

    }
    class EnterNumber
    {
        public delegate void EnterNumDeleg(List<string> name, int index);
        public event EnterNumDeleg EnterNumEvent;

        public void NumberRead(List<string> name)
        {
            Console.WriteLine("Введите номер сортировки: 1(А-Я) или 2(Я-А)");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index != 1 && index != 2) throw new MyFormatException("Ошибка ввода числа, введите 1 или 2");

            NumberEnter(name, index);
        }

        protected virtual void NumberEnter(List<string> name, int index)
        {
            EnterNumEvent?.Invoke(name, index);
        }

    }

    public class MyFormatException: FormatException
    {
        public MyFormatException() { }
        public MyFormatException(string messege):base(messege) { }
    }

}
