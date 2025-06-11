using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLEditor.Classes.Underclasses
{
    public class ClassMethod
    {
        public char AccessModifier { get; set; }
        public string Name { get; set; }
        public List<MethodInput> Input { get; set; }
        public string Output { get; set; }

        public override string ToString()
        {
            if (Input.Count == 0) 
            {
                return $"{AccessModifier} {Output} {Name} ()";
            } else if (Input.Count == 1)
            {
                return $"{AccessModifier} {Output} {Name} ({Input.First()})";
            } else
            {
                return $"{AccessModifier} {Output} {Name} ({Input.First()},...)";
            }
        }
    }
}
