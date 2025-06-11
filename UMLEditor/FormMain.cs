using System.Diagnostics;
using System.Drawing.Design;
using UMLEditor.Classes;
using UMLEditor.Managers;

namespace UMLEditor
{
    public partial class FormMain : Form
    {
        private GraphicsManager graphicsManager = new GraphicsManager();
        private DiagramFileManager diagramFileManager = new DiagramFileManager();

        bool mouseMoveLocked = false;
        private Cell draggedCell = null;
        private ArrowStart activeArrowStart = null;

        private string[] lineTypes = { "full", "dashed" };
        private string[] arrowTypes = { "composition", "aggregation", "heritage", "association" };

        public FormMain()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            graphicsManager.pb = pictureBox1;
            comboBoxLineStyle.DataSource = lineTypes;
            comboBoxArrowStyle.DataSource = arrowTypes;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            graphicsManager.Draw(g);
        }

        private void buttonAddCell_Click(object sender, EventArgs e)
        {
            graphicsManager.AddCell(pictureBox1);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedCell != null)
            {
                graphicsManager.MoveCell(draggedCell, e.Location);
            }
            else if (activeArrowStart != null)
            {
                graphicsManager.MoveAim(activeArrowStart, e.Location);
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cell cell = graphicsManager.FindCell(e.Location);
            int cellIndex = graphicsManager.GetCellIndex(cell);

            if (cell != null)
            {
                using (FormEditor form = new FormEditor(cell, graphicsManager.getAllCells()))
                {
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        graphicsManager.RemoveCellByIndex(cellIndex);
                        graphicsManager.AddCell(form.returnCell);
                    }
                    else if (form.DialogResult == DialogResult.Abort)
                    {

                        graphicsManager.RemoveCellByIndex(cellIndex);
                    }
                }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            draggedCell = null;
            if (graphicsManager.DrawAim && activeArrowStart != null && comboBoxLineStyle.SelectedIndex > -1 && comboBoxArrowStyle.SelectedIndex > -1)
            {
                Debug.WriteLine("[FORMMAIN] MouseUp > trying to add arrow");
                graphicsManager.AddArrow(e.Location, activeArrowStart, (string)comboBoxArrowStyle.SelectedItem, (string)comboBoxLineStyle.SelectedItem);
            }
            activeArrowStart = null;
            graphicsManager.DrawAim = false;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            graphicsManager.UpdateToSize(pictureBox1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            draggedCell = graphicsManager.FindCell(e.Location);
            if (draggedCell != null) return;
            else
            {
                activeArrowStart = graphicsManager.FindArrowStart(e.Location);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            diagramFileManager.SaveAs(graphicsManager.CreateFile());
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            DiagramFile diagramFile = diagramFileManager.Open();
            if (diagramFile != null)
            {
                graphicsManager.Clear();
                graphicsManager.ReadFile(diagramFile);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonExportImage_Click(object sender, EventArgs e)
        {
            diagramFileManager.ExportToImg(pictureBox1);
        }

        private void buttonExportCode_Click(object sender, EventArgs e)
        {
            diagramFileManager.ExportToCode(graphicsManager.CreateFile());
        }
    }
}
