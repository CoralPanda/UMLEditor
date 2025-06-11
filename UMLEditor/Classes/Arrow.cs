using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLEditor.Classes.Interfaces;
using System.Windows.Forms;
using System.Diagnostics;

namespace UMLEditor.Classes
{
    public class Arrow : IDrawnObject
    {
        // Arrow coordinations
        /*public ArrowStart SourceLocation { get; set; }
        public ArrowStart TargetLocation { get; set; }*/

        // Input for arrow coordinates
        public int SourceCellID { get; set; }
        public Cell SourceLocation { private get; set; }
        public int SourceSide { get; set; }
        public int TargetCellID { get; set; }
        public Cell TargetLocation { private get; set; }
        public int TargetSide { get; set; }

        // Calculated arrow coordinates
        public PointF StartPoint { get; private set; }
        public PointF TargetPoint { get; private set; }
        private PointF Breakpoint { get; set; }

        // Arrow style
        public string LineType { get; set; }
        private string[] validLineType = { "full", "dashed" };
        public string ArrowType { get; set; }
        private string[] validArrowType = { "composition", "aggregation", "heritage", "association" };
        public string LineGuideline { get; set; }
        private string[] validGuideline = { "h-h", "v-v", "h-v", "v-h" }; // (h = horizontal, v = vertical)

        private Pen LineStyle = new Pen(Brushes.Black, 2);
        private Pen LineEnd = new Pen(Brushes.Black, 2);

        GraphicsPath gPath = new GraphicsPath();
        AdjustableArrowCap arrowEnd;

        public Arrow(Arrow arrow, List<Cell> cells)
        {
            Debug.WriteLine($"[ARROW] CREATION USING ARROW");

            foreach (Cell cell in cells)
            {
                Debug.WriteLine("[ARROW] CREATION > looking for cell ID ===");
                Debug.WriteLine($"[ARROW] CREATION > looking at {cell.ID} == {arrow.SourceCellID}");
                if (cell.ID == arrow.SourceCellID)
                {
                    this.SourceLocation = cell;
                }
                Debug.WriteLine($"[ARROW] CREATION > looking at {cell.ID} == {arrow.TargetCellID}");
                if (cell.ID == arrow.TargetCellID)
                {
                    this.TargetLocation = cell;
                }
            }
            this.SourceCellID = arrow.SourceCellID;
            this.TargetCellID = arrow.TargetCellID;
            this.SourceSide = arrow.SourceSide;
            this.TargetSide = arrow.TargetSide;
            this.LineGuideline = arrow.LineGuideline;
            this.LineType = arrow.LineType;
            this.ArrowType = arrow.ArrowType;

            switch (arrow.ArrowType)
            {
                case "composition":
                    LineEnd.CustomEndCap = CreateDiamondCap(true);
                    break;

                case "aggregation":
                    LineEnd.CustomEndCap = CreateDiamondCap(false);
                    break;

                case "heritage":
                    LineEnd.CustomEndCap = CreateTriangleCap(false);
                    break;

                case "association":
                    arrowEnd = new AdjustableArrowCap(7, 7, false);
                    LineEnd.CustomEndCap = arrowEnd;
                    break;
            }


            if (LineType == "dashed")
            {
                LineStyle.DashStyle = DashStyle.Dash;
                LineEnd.DashStyle = DashStyle.Dash;
            }
        }

        public Arrow(List<Cell> cells, int sourceID, int sourceSide, int targetID, int targetSide, string lineGuideline, string arrowType, string lineType)
        {
            Debug.WriteLine($"[ARROW] CREATION USING ALL PARAMETERS");
            foreach (Cell cell in cells)
            {
                if (cell.ID == sourceID)
                {
                    Debug.WriteLine($"[ARROW] CREATION > FOUND SOURCE CELL ID as {cell.ID} == {sourceID}");
                    this.SourceCellID = cell.ID;
                    this.SourceLocation = cell;
                }

                if (cell.ID == targetID)
                {
                    Debug.WriteLine($"[ARROW] CREATION > FOUND TARGET CELL ID as {cell.ID} == {targetID}");
                    this.TargetCellID = cell.ID;
                    this.TargetLocation = cell;
                }
            }
            SourceSide = sourceSide;
            TargetSide = targetSide;
            LineGuideline = lineGuideline;
            LineType = lineType;
            ArrowType = arrowType;

            switch (arrowType)
            {
                case "composition":
                    LineEnd.CustomEndCap = CreateDiamondCap(true);
                    break;

                case "aggregation":
                    LineEnd.CustomEndCap = CreateDiamondCap(false);
                    break;

                case "heritage":
                    LineEnd.CustomEndCap = CreateTriangleCap(false);
                    break;

                case "association":
                    arrowEnd = new AdjustableArrowCap(7, 7, false);
                    LineEnd.CustomEndCap = arrowEnd;
                    break;
            }


            if (LineType == "dashed")
            {
                LineStyle.DashStyle = DashStyle.Dash;
                LineEnd.DashStyle = DashStyle.Dash;
            }
        }

        public void Draw(Graphics g)
        {
            CalculateValues();

            switch (LineGuideline)
            {
                case "h-h":
                    g.DrawLine(LineStyle, StartPoint, new PointF(Breakpoint.X, StartPoint.Y));
                    g.DrawLine(LineStyle, new PointF(Breakpoint.X, StartPoint.Y), new PointF(Breakpoint.X, TargetPoint.Y));
                    if (TargetSide == 0)
                        g.DrawLine(LineEnd, new PointF(Breakpoint.X, TargetPoint.Y), new PointF(TargetPoint.X + 5, TargetPoint.Y));
                    if (TargetSide == 1)
                        g.DrawLine(LineEnd, new PointF(Breakpoint.X, TargetPoint.Y), new PointF(TargetPoint.X - 5, TargetPoint.Y));
                    break;
                case "v-v":
                    g.DrawLine(LineStyle, StartPoint, new PointF(StartPoint.X, Breakpoint.Y));
                    g.DrawLine(LineStyle, new PointF(StartPoint.X, Breakpoint.Y), new PointF(TargetPoint.X, Breakpoint.Y));
                    if (TargetSide == 2)
                        g.DrawLine(LineEnd, new PointF(TargetPoint.X, Breakpoint.Y), new PointF(TargetPoint.X, TargetPoint.Y - 5));
                    if (TargetSide == 3)
                        g.DrawLine(LineEnd, new PointF(TargetPoint.X, Breakpoint.Y), new PointF(TargetPoint.X, TargetPoint.Y + 5));
                    break;
                case "h-v":
                    g.DrawLine(LineStyle, StartPoint, Breakpoint);
                    if (TargetSide == 2)
                        g.DrawLine(LineEnd, Breakpoint, new PointF(TargetPoint.X, TargetPoint.Y - 5));
                    if (TargetSide == 3)
                        g.DrawLine(LineEnd, Breakpoint, new PointF(TargetPoint.X, TargetPoint.Y + 5));
                    break;
                case "v-h":
                    g.DrawLine(LineStyle, StartPoint, Breakpoint);
                    if (TargetSide == 0)
                        g.DrawLine(LineEnd, Breakpoint, new PointF(TargetPoint.X + 5, TargetPoint.Y));
                    if (TargetSide == 1)
                        g.DrawLine(LineEnd, Breakpoint, new PointF(TargetPoint.X - 5, TargetPoint.Y));
                    break;
            }
        }

        private void CalculateValues()
        {
            StartPoint = CalculatePointValue(SourceLocation, SourceSide);
            TargetPoint = CalculatePointValue(TargetLocation, TargetSide);

            switch (LineGuideline)
            {
                case "h-h":
                    Breakpoint = new PointF(new float[] { StartPoint.X, TargetPoint.X }.Average(), 0);
                    break;
                case "v-v":
                    Breakpoint = new PointF(0, new float[] { StartPoint.Y, TargetPoint.Y }.Average());
                    break;
                case "h-v":
                    Breakpoint = new PointF(TargetPoint.X, StartPoint.Y);
                    break;
                case "v-h":
                    Breakpoint = new PointF(StartPoint.X, TargetPoint.Y);
                    break;
            }
        }

        public bool CanBeCreated(Arrow arrow)
        {
            if (this.SourceLocation == arrow.SourceLocation && this.TargetLocation == arrow.TargetLocation) return false;
            return true;
        }

        public bool AlreadyExists(Arrow arrow)
        {
            if (this.SourceLocation.ID == arrow.SourceLocation.ID && this.SourceSide == arrow.SourceSide && this.TargetLocation.ID == arrow.TargetLocation.ID && this.TargetSide == arrow.TargetSide ||
                this.SourceLocation.ID == arrow.TargetLocation.ID && this.SourceSide == arrow.TargetSide)
                return true;

            return false;
        }

        private CustomLineCap CreateDiamondCap(bool filled)
        {

            GraphicsPath hPath = new GraphicsPath(FillMode.Winding);

            hPath.AddLine(new Point(0, 0), new Point(4, -8));
            hPath.AddLine(new Point(4, -8), new Point(0, -16));
            hPath.AddLine(new Point(0, -16), new Point(-4, -8));
            hPath.AddLine(new Point(-4, -8), new Point(0, 0));

            if (filled)
            {
                CustomLineCap lineCapNew = new CustomLineCap(hPath, null);
                lineCapNew.BaseInset = 16;

                return lineCapNew;
            }
            else
            {
                CustomLineCap lineCapNew = new CustomLineCap(null, hPath);
                lineCapNew.BaseInset = 16;

                return lineCapNew;
            }
        }

        private CustomLineCap CreateTriangleCap(bool filled)
        {
            GraphicsPath hPath = new GraphicsPath(FillMode.Winding);
            hPath.AddLine(new Point(0, 0), new Point(4, -8));
            hPath.AddLine(new Point(4, -8), new Point(-4, -8));
            hPath.AddLine(new Point(-4, -8), new Point(0, 0));

            if (filled)
            {
                CustomLineCap lineCapNew = new CustomLineCap(hPath, null);
                lineCapNew.BaseInset = 8;

                return lineCapNew;
            }
            else
            {
                CustomLineCap lineCapNew = new CustomLineCap(null, hPath);
                lineCapNew.BaseInset = 8;

                return lineCapNew;
            }
        }

        private PointF CalculatePointValue(Cell cell, int side)
        {
            switch (side)
            {
                case 0: // right
                    return new PointF(
                        cell.Box.X + cell.Box.Width, 
                        cell.Box.Y + (cell.Box.Height / 2)
                        );
                case 1: // left
                    return new PointF(
                        cell.Box.X,
                        cell.Box.Y + (cell.Box.Height / 2)
                        );
                case 2: // top
                    return new PointF(
                        cell.Box.X + (cell.Box.Width / 2),
                        cell.Box.Y
                        );
                case 3: // bottom
                    return new PointF(
                        cell.Box.X + (cell.Box.Width / 2),
                        cell.Box.Y + cell.Box.Height
                        );
                default:
                    return new PointF();
            }
        }

        public override string ToString()
        {
            return $"Source cell ID: {SourceCellID}, Target cell ID: {TargetCellID}, Guideline: {LineGuideline}";
        }
    }
}
