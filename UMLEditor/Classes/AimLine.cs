using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLEditor.Classes.Interfaces;

namespace UMLEditor.Classes
{
    public class AimLine : IDrawnObject
    {
        private PointF startingPoint;
        private PointF endingPoint;

        private Pen LineStyle = new Pen(Brushes.Black, 2);

        public AimLine(PointF startingPoint)
        {
            this.startingPoint = startingPoint;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(LineStyle, startingPoint, endingPoint);
        }

        public void Update(PointF mouseLocation)
        {
            endingPoint = mouseLocation;
        }
    }
}
