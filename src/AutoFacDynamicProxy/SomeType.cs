using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;

namespace AutoFacDynamicProxy
{
    public class SomeType : ISomeInterface
    {
        public virtual int sum(int a, int b)
        {
            return a + b;
        }

        public virtual SomeOutput GetOutput(SomeInput1 input1, SomeInput2 input2)
        {
            return new SomeOutput(){Id = 10};
        }
    }

    // This attribute will look for a TYPED
    // interceptor registration:
    [Intercept(typeof(CallLogger))]
    public class First
    {
        public virtual int GetValue()
        {
            // Do some calculation and return a value
            return 1;
        }
    }

    // This attribute will look for a NAMED
    // interceptor registration:
    [Intercept("log-calls")]
    public class Second
    {
        public virtual int GetValue()
        {
            // Do some calculation and return a value
            return 2;
        }
    }
}
