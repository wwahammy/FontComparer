using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontComparer;
using Xunit;

namespace Test
{
    public class Class1
    {
        [Fact]
        public void SomethingTest()
        {
            var f = new FontViewModel(@"C:\Users\Eric\Desktop\MS_ChemSans.ttf");
        }

    }
}
