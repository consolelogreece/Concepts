using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_IOC_Container
{
    public class ServiceObject
    {
        public ServiceObject(InstanceType instanceType, Type type)
        {
            InstanceType = instanceType;
            Type = type;
        }

        public InstanceType InstanceType { get; }

        public Type Type { get; }
    }
}
