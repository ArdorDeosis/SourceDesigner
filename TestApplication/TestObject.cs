using System.Collections.Generic;
using FastJsonConversion;

namespace TestApplication
{
    [FastJsonConversion]
    public class TestObject
    {
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public double DoubleValue { get; set; }
        public bool BoolValue { get; set; }
        
        public NestedTestObject NestedObject { get; set; }
        
        public int[] IntArray { get; set; }
        public List<string> StringList { get; set; }
    }

    [FastJsonConversion]
    public class NestedTestObject
    {
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public double DoubleValue { get; set; }
    }
}