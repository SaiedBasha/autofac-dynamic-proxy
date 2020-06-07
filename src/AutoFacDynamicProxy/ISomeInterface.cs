using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFacDynamicProxy
{
    public interface ISomeInterface
    {
        int sum(int a, int b);

        SomeOutput GetOutput(SomeInput1 input1, SomeInput2 input2);
    }

    public class SomeOutput
    {
        public int Id { get; set; }
    }

    public class SomeInput1
    {
        public int Id { get; set; }
    }

    public class SomeInput2
    {
        public int Id { get; set; }
    }
}
