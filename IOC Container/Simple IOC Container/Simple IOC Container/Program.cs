using System;
using Simple_IOC_Container.TestObjects.Ice_Cream;
using Simple_IOC_Container.TestObjects.Ingredients.Fruit;

namespace Simple_IOC_Container
{
    class Program
    {
        public static IoC_Container ioc = new IoC_Container();

        //Main
        static void Main(string[] args)
        {
            var ioc = new IoC_Container();
            ioc.RegisterSingleton<Ice_Cream>();
            var fruit = ioc.Resolve<IFruit>();
            fruit.FruitType = "Edited Strawberry";
            var secondFruit = ioc.Resolve<IFruit>();


            //Console.WriteLine("Initial entry");;

            //ioc.RegisterSingleton<Test>();

            //ioc.RegisterTransient<dependency1>();

            //var testInstance1 = ioc.Resolve<Test>();

            //Console.WriteLine(testInstance1.test);

            //testInstance1.test = "modified test";

            //var testInstance2 = ioc.Resolve<Test>();

            //Console.WriteLine(testInstance2.test);
        }   
    }
}
