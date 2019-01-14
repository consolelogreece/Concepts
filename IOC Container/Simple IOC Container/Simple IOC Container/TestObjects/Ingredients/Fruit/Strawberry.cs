using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_IOC_Container.TestObjects.Ingredients.Fruit
{
    public class Strawberry : IFruit
    {
        public Strawberry()
        {
            
        }
        public string FruitType { get; set; } = "Strawberry";
    }
}
