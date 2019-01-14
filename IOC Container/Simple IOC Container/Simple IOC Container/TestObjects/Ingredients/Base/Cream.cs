using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_IOC_Container.TestObjects.Ingredients.Base
{
    public class Cream : IBase
    {
        public Cream(Milk milk)
        {
            
        }

        public string BaseType { get; set; } = "Cream";
    }
}
