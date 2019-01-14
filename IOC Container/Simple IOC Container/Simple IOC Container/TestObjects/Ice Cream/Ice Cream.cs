using System;
using System.Collections.Generic;
using System.Text;
using Simple_IOC_Container.TestObjects.Ingredients.Base;
using Simple_IOC_Container.TestObjects.Ingredients.Fruit;

namespace Simple_IOC_Container.TestObjects.Ice_Cream
{
    public class Ice_Cream
    {
        public IFruit Fruit;

        public IBase IceCreamBase;

        public Ice_Cream(IBase iceCreamBase, IFruit fruit)
        {
            IceCreamBase = iceCreamBase;

            Fruit = fruit;
        }
    }
}
