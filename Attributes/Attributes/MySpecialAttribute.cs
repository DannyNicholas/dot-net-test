using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    class MySpecialAttribute : Attribute
    {
    }
}
