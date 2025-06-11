using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLEditor.Classes
{
    public class DiagramFile
    {
        public List<Arrow> arrows { get; set; } = new List<Arrow>();
        public List<Cell> cells { get; set; } = new List<Cell>();
    }
}
