using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UMLEditor.Classes.Interfaces;
using UMLEditor.Classes.Underclasses;
using static System.Net.Mime.MediaTypeNames;

namespace UMLEditor.Classes
{
    public class Cell : ICloneable, IDrawnObject
    {
        public int ID { get; private set; }

        // Cell style
        public RectangleF Box { get; set; }
        public PointF location {  get; set; }
        public PointF anchor { get; set; }

       
        public PointF pictureBoxSize { get; set; }

        public float sizeX { get; set; } = 0;
        public float topY {  get; set; } = 0;
        public float midY { get; set; } = 0;
        public float botY { get; set; } = 0;

        private Pen style = new Pen(Brushes.Black, 2f);

        private System.Drawing.Font fontName = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
        private System.Drawing.Font fontText = new System.Drawing.Font("Arial", 8);

        private float offset;

        // Cell ArrowStarts
        public ArrowStart[] arrowStarts = new ArrowStart[4];

        // Cell insides
        private string className;
        public string ClassName { get; set; }
        public List<ClassAttribute> Attributes { get; set; } = new List<ClassAttribute>();
        public List<ClassMethod> Methods { get; set; } = new List<ClassMethod>();
        public bool Interface { get; set; }

        public Cell(int id, PointF pbSize = new PointF())
        {
            this.ID = id;
            this.pictureBoxSize = pbSize;

            Attributes.Add(new ClassAttribute() {
                AccessModifier = '+',
                Name = "Attribute",
                DataType = "string"
            });

            List<MethodInput> mi = new List<MethodInput>();
            mi.Add(new MethodInput() { DataType = "string", Name = "input1" });

            Methods.Add(new ClassMethod()
            {
                AccessModifier = '+',
                Name = "Method",
                Input = mi,
                Output = "void"
            });

            ClassName = "ClassName";

            anchor = new PointF(pictureBoxSize.X / 2, pictureBoxSize.Y / 2);

            Interface = false;

            Debug.WriteLine($"[CELL] CREATION > Cell created with ID = {id}");
        }

        public void Draw(Graphics g)
        {
            CalculateValues(g);

            foreach (ArrowStart arrowStart in arrowStarts)
            {
                arrowStart.Draw(g);
            }

            if (!Interface) g.FillRectangle(Brushes.Moccasin, location.X, location.Y, sizeX, topY + midY + botY);
            if (Interface) g.FillRectangle(Brushes.LightGreen, location.X, location.Y, sizeX, topY + midY + botY);

            // draws top rectangle
            g.DrawRectangle(style, location.X, location.Y, sizeX, topY);

            g.DrawString(
                ClassName,
                fontName,
                Brushes.Black,
                new PointF
                (location.X + sizeX/2 - g.MeasureString(ClassName, fontName).Width/2, 
                location.Y + topY/2 - g.MeasureString(ClassName, fontName).Height / 2
                ) // finds center of rect for string
            );

            // draws middle rectangle
            offset = 5;
            g.DrawRectangle(style, location.X, location.Y + topY, sizeX, midY);

            for (int i = 0; i < Attributes.Count; i++)
            {
                string text = text = Attributes[i].ToString();

                g.DrawString(
                    text,
                    fontText,
                    Brushes.Black,
                    new PointF(
                        location.X + 5,
                        location.Y + topY + offset
                        )
                    );

                offset += g.MeasureString("A", fontText).Height;
            }

            // draws bottom rectangle
            offset = 5;
            g.DrawRectangle(style, location.X, location.Y + topY + midY, sizeX, botY);
            foreach (ClassMethod method in Methods)
            {
                string text1 = $"{method.AccessModifier} {method.Name}(";

                string text2 = " ";
                foreach (MethodInput input in method.Input)
                {
                    text2 += $"{input.DataType} {input.Name}, ";
                }
                text2 = text2.Remove(text2.Length - 2);

                string text3 = $" ): {method.Output}";

                string text = text1 + text2 + text3; ;

                g.DrawString(
                text,
                fontText,
                Brushes.Black,
                new PointF(
                    location.X + 5,
                    location.Y + topY + midY + offset
                    ) // finds center of rect for string
                );

                offset += g.MeasureString("A", fontText).Height;
            }
        }

        public void Update(PointF mouseLocation)
        {
            PointF offset = new PointF(location.X - mouseLocation.X, location.Y - mouseLocation.Y);

            anchor = new PointF(
                mouseLocation.X - offset.X / 2,
                mouseLocation.Y - offset.Y / 2
                );
        }

        private void CalculateValues(Graphics g)
        {
            botY = 10;
            midY = 10;

            // finds biggest string to assign the width of the cell
            float BiggestString = g.MeasureString(ClassName, fontName).Width;
            foreach (ClassAttribute att in Attributes)
            {
                string text = $"{att.AccessModifier} {att.Name}: {att.DataType}";
                if (g.MeasureString(text, fontText).Width > BiggestString) BiggestString = g.MeasureString(text, fontText).Width;
                midY += g.MeasureString("A", fontText).Height;
            }
            foreach (ClassMethod met in Methods)
            {
                string text1 = $"{met.AccessModifier} {met.Name}(";

                string text2 = " ";
                foreach (MethodInput input in met.Input)
                {
                    text2 += $"{input.DataType} {input.Name}, ";
                } 
                text2 = text2.Remove(text2.Length - 2);

                string text3 = $" ): {met.Output}";

                string text = text1 + text2 + text3;

                if (g.MeasureString(text, fontText).Width > BiggestString) BiggestString = g.MeasureString(text, fontText).Width;
                botY += g.MeasureString("A", fontText).Height;
            } 
            sizeX = BiggestString + 10;
            //

            topY = g.MeasureString(ClassName, fontName).Height * 1.5f;

            location = new PointF(
                this.anchor.X - sizeX / 2,
                this.anchor.Y - (topY + midY + botY) / 2
                );

            this.Box = new RectangleF(location.X, location.Y, sizeX, topY + midY + botY);

            if (arrowStarts[3] == null)
            {
                for (int i = 0; i < arrowStarts.Length; i++)
                {
                    arrowStarts[i] = new ArrowStart(this.Box, i, this.ID);
                }
            }

            foreach (ArrowStart arrowStart in arrowStarts)
            {
                arrowStart.GluedCellBox = this.Box;
            }
        }

        public void ClearArrowStarts()
        {
            arrowStarts = new ArrowStart[4];
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
