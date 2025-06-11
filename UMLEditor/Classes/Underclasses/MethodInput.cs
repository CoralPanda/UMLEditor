using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLEditor.Classes.Underclasses
{
    public class MethodInput
    {
        public string DataType { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{DataType} {Name}";
        }
    }
}
