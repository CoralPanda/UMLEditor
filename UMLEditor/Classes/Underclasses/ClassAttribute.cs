using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLEditor.Classes.Underclasses
{
    public class ClassAttribute
    {
        public char AccessModifier { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }


        public override string ToString()
        {
            return $"{AccessModifier} {DataType} {Name}";
        }
    }
}
