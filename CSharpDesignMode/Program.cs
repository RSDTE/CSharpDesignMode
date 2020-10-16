using System;

namespace CSharpDesignMode
{
    class Program
    {
        static void Main(string[] args) {

            Singleton singleton = Singleton.GetInstance();
            Console.WriteLine("age={0}, name={1}", singleton.Age, singleton.Name);

            var sing = Singleton.GetSingleton();
            Console.WriteLine("age={0}, name={1}", sing.Age, sing.Name);
            singleton.Age = 333;
            Console.WriteLine("age={0}, name={1}", sing.Age, sing.Name);
            Console.WriteLine("age={0}, name={1}", singleton.Age, singleton.Name);

            Console.WriteLine("Hello World!");
        }
    }
}
