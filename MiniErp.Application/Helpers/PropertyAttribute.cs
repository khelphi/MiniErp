using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniErp.Application.Helpers
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class PropertyAttribute: Attribute
    {
        public PropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
