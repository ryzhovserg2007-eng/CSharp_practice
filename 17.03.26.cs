using System.Globalization;
using System.Numerics;

namespace _17._03._26.практика
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Animal abstract
            Cat cat1 = new Cat(1);
            cat1.Method1(); cat1.Method2(); cat1.Method3();
            Animal cat2 = new Cat(2);
            cat2.Method1(); cat2.Method2(); cat2.Method3();
            Dog dog1 = new Dog(3);
            dog1.Method1(); dog1.Method2(); dog1.Method3();

        }
    }
    public abstract class Animal
    {
        private int _number;
        public abstract string Word // абстрактное свойство
        {
            get;
            set;
          
        }
        public Animal(int number)
        {
            _number = number;
            
        }
        
        // private double _age;
        //public Animal(double age)
        //{
        //    _age = age;
        //}
        public void Method1()
        {
            Console.WriteLine("Animal Method1");
        }
        public virtual void Method2()
        {
            Console.WriteLine("Animal Method2"); // номер животного и его возраст
        }
        public abstract void Method3();
    }
    public class Cat : Animal // наследник
    {
        public override string Word => "W";
        public Cat(int number) : base(number)
        {
            
        }
        public new void Method1()
        {
            Console.WriteLine("Cat Method1");
        }
        public override void Method2()
        {
            Console.WriteLine("Cat Method2"); ;
        }
        public override void Method3()
        {
            Console.WriteLine("Cat Method3"); ;
        }
        //public Cat(double age) : base(age)
        //{

        //}
    }
    public class Dog : Animal  // не находит первые 2 метода и ищет их в Animal
    {
        public Dog(int number) : base(number)
        {

        }
        public override void Method3() // не можем не писать 3 метод
        {
            Console.WriteLine("Dog Method3"); ;
        }
    }
    }
