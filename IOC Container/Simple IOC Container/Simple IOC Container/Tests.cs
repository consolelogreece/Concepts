using System;
using Simple_IOC_Container.TestObjects.Ice_Cream;
using Simple_IOC_Container.TestObjects.Ingredients.Base;
using Simple_IOC_Container.TestObjects.Ingredients.Fruit;
using Xunit;

namespace Simple_IOC_Container
{
    public class Tests
    {
        [Fact]
        public void ShouldThrowError()
        {
            //arrange
            var ioc = new IoC_Container();
            
            //act & assert
            Assert.Throws<ArgumentException>(() => ioc.Resolve<Ice_Cream>());
        }

        [Fact]
        public void ShouldResolveSingleton()
        {
            //arrange
            var ioc = new IoC_Container();
            ioc.RegisterSingleton<IFruit, Strawberry>();

            //act
            var fruit = ioc.Resolve<IFruit>();
            fruit.FruitType = "Edited Strawberry";
            var secondFruit = ioc.Resolve<IFruit>();

            //assert
            Assert.Equal("Edited Strawberry", secondFruit.FruitType);
        }

        [Fact]
        public void ShouldResolveTransient()
        {
            //arrange
            var ioc = new IoC_Container();
            ioc.RegisterTransient<IFruit, Strawberry>();

            //act
            var fruit = ioc.Resolve<IFruit>();
            fruit.FruitType = "Edited Strawberry";
            var secondFruit = ioc.Resolve<IFruit>();

            //assert
            Assert.Equal("Strawberry", secondFruit.FruitType);
        }

        [Fact]
        public void ShouldRecursivelyResolveDependencies()
        {
            //arrange
            var ioc = new IoC_Container();
            ioc.RegisterSingleton<Ice_Cream>();
            ioc.RegisterSingleton<IBase, Cream>();
            ioc.RegisterSingleton<Milk>();
            ioc.RegisterTransient<IFruit, Banana>();

            //act
            var x = ioc.Resolve<Ice_Cream>();

            Assert.Equal("Banana", x.Fruit.FruitType);
        }
    }
}
