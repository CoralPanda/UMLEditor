using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLEditor.Classes.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace UMLEditor.Classes
{
    public class ArrowStart : IDrawnObject
    {
        public int ParentCellID { get; set; }
        public RectangleF GluedCellBox { get; set; }
        public int Side { get; set; } //  0 - right, 1 - left, 2 - top, 3 - bottom

        private RectangleF Box { get; set; }
        private int Size { get; set; } = 8;
        public PointF Center { get; private set; }
        public bool IsActive = false;

        public ArrowStart(RectangleF gluedCell, int Side, int parentCellID)
        {
            this.ParentCellID = parentCellID;
            this.GluedCellBox = gluedCell;
            this.Side = Side;
        }

        public void Draw(Graphics g)
        {
            CalculateValues();

            g.FillRectangle(Brushes.LightSkyBlue, Box);
            g.DrawRectangle(Pens.Black, Box);
        }

        public void Update(RectangleF cellBox)
        {
            this.GluedCellBox = cellBox;
        }

        private void CalculateValues()
        {
            switch (Side)
            {
                case 0:
                    Box = new RectangleF(GluedCellBox.X + GluedCellBox.Width, GluedCellBox.Y + GluedCellBox.Height / 2 - Size / 2, Size, Size);
                    break;
                case 1:
                    Box = new RectangleF(GluedCellBox.X - Size, GluedCellBox.Y + GluedCellBox.Height / 2 - Size / 2, Size, Size);
                    break;
                case 2:
                    Box = new RectangleF(GluedCellBox.X + GluedCellBox.Width / 2 - Size / 2, GluedCellBox.Y - Size, Size, Size);
                    break;
                case 3:
                    Box = new RectangleF(GluedCellBox.X + GluedCellBox.Width / 2 - Size / 2, GluedCellBox.Y + GluedCellBox.Height, Size, Size);
                    break;
            }

            this.Center = new PointF(Box.X + 5, Box.Y + 5);
        }

        public bool Contains(PointF point)
        {
            return Box.Contains(point);
        }

        public void Activate()
        {
            this.IsActive = true;
        }

        public void Deactivate()
        {
            this.IsActive = false;
        }
    }
}
