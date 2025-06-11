using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLEditor.Classes;
using Newtonsoft.Json;
using System.Diagnostics;
using UMLEditor.Classes.Underclasses;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace UMLEditor.Managers
{
    public class DiagramFileManager
    {

        public void SaveAs(DiagramFile diagramFile)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string SaveToPath = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveToPath = saveFileDialog.FileName;
                }
                else return;
            }

            File.WriteAllText(SaveToPath + ".json", JsonConvert.SerializeObject(diagramFile, settings));
        }

        public DiagramFile Open()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string GetFromPath = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            using (openFileDialog)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GetFromPath = openFileDialog.FileName;
                }
                else return null;
            }

            string JSON = File.ReadAllText(GetFromPath);

            try
            {
                return JsonConvert.DeserializeObject<DiagramFile>(JSON, settings);
            }
            catch
            {
                return null;
            }
        }

        public void ExportToImg(PictureBox pb)
        {
            string SaveToPath = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveToPath = saveFileDialog.FileName;
                } else return;
            }

            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            pb.DrawToBitmap(bmp, new Rectangle(0,0,pb.Width,pb.Height));
            bmp.Save(SaveToPath + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        public void ExportToCode(DiagramFile diagramFile)
        {
            string SaveToPath = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < saveFileDialog.FileName.Split('\\').Count() - 1; i++)
                    {
                        SaveToPath += saveFileDialog.FileName.Split('\\')[i] + "\\";
                    }
                    
                }
                else return;
            }

            foreach (Cell cell in diagramFile.cells)
            {
                File.WriteAllText(SaveToPath + cell.ClassName + ".cs", GenerateClassString(cell, diagramFile));
            }
        }

        private string GenerateClassString(Cell cell, DiagramFile diagramFile)
        {
            string text;

            if (cell.Interface) text = "using System;\n\nnamespace SolutionName\n{\n\tpublic interface " + cell.ClassName + "\n\t{";
            else text = "using System;\n\nnamespace SolutionName\n{\n\tpublic class " + cell.ClassName + CheckForHeritage(cell, diagramFile) + "\n\t{";

            foreach (ClassAttribute attribute in cell.Attributes)
            {
                text += $"\n\t\t{AccessModifier(attribute.AccessModifier)} {attribute.DataType} {attribute.Name} " + "{ get; set; }";
            }

            text += "\n";

            foreach (ClassMethod method in cell.Methods)
            {
                int index = 0;
                text += $"\n\t\t{AccessModifier(method.AccessModifier)} {method.Output} {method.Name}(";
                if (method.Input.Count > 0)
                {
                    foreach (MethodInput input in method.Input)
                    {
                        if (index > 0 && index < method.Input.Count) text += ", ";
                        index++;
                        text += $"{input.DataType} {input.Name}";
                    }
                }
                text += ")\n\t\t{\n\n\t\t}";
            }

            text += "\n\t}\n}";

            return text;
        }

        private string CheckForHeritage(Cell cell, DiagramFile diagramFile)
        {
            List<string> interfaces = new List<string>();

            foreach (Arrow arrow in diagramFile.arrows)
            {
                Debug.WriteLine("[DFM] looking trough arrow " + arrow.SourceCellID + " > " + arrow.TargetCellID + " with " + arrow.ArrowType);
                if (arrow.SourceCellID == cell.ID || arrow.ArrowType == "heritage")
                {
                    Debug.WriteLine("[DFM] arrow accepted, looking for cells");
                    Cell heritageCell = null;

                    foreach (Cell cellIn in diagramFile.cells)
                    {
                        if (cellIn.ID == arrow.TargetCellID) heritageCell = cellIn;
                    }

                    interfaces.Add(heritageCell.ClassName);
                }
            }

            if (interfaces.Count > 0)
            {

                string returnValue = " : ";

                for (int i  = 0; i < interfaces.Count; i++)
                {
                    Debug.WriteLine("[DFM] creating return value + " + interfaces[i]);
                    if (i > 0) returnValue += ", ";
                    returnValue += interfaces[i];
                }
                Debug.WriteLine("[DFM] returnValue" + returnValue);
                return returnValue;
            }
            else
            {
                Debug.WriteLine("[DFM] interfaces count is 0");
                return "";
            }
        }

        private string AccessModifier(char accmod)
        {
            switch (accmod)
            {
                case '+':
                    return "public";
                case '-':
                    return "private";
                case '#':
                    return "protected";
                case '~':
                    return "internal";
                default:
                    throw new ArgumentException("");
            }
        }
    }
}
