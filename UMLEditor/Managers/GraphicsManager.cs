using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLEditor.Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UMLEditor.Managers
{
    public class GraphicsManager
    {
        private int cellIDindex { get; set; } = -1;

        public PictureBox pb;
        public bool AllowMouseDown { get; set; } = true;

        private List<Cell> cells = new List<Cell>();
        private List<Arrow> arrows = new List<Arrow>();
        private AimLine aimLine;

        public bool DrawAim = false;

        public void Draw(Graphics g)
        {
            if (arrows != null)
            {
                foreach (Arrow arrow in arrows)
                {
                    arrow.Draw(g);
                }
            }

            if (cells != null)
            {
                foreach (Cell cell in cells)
                {
                    cell.Draw(g);
                }
            }

            if (DrawAim)
            {
                aimLine.Draw(g);
            }
        }

        public void AddArrow(PointF mouseLocation, ArrowStart startingPoint, string ArrowStyle, string LineStyle)
        {
            Debug.WriteLine("[GM] AddArrow > Method called");

            Cell endingPointParentCell = null;
            Cell startingPointParentCell = null;
            int endingPointSide = -1;

            Debug.WriteLine($"[GM] AddArrow > GOING TROUGH ALL CELLS ========================================================");
            foreach (Cell cell in cells)
            {
                Debug.WriteLine($"[GM] Cell id: " + cell.ID);

                if (endingPointParentCell == null)
                {
                    Debug.WriteLine("[GM] AddArrow > looking for ending point parent cell");

                    foreach (ArrowStart arrowStart in cell.arrowStarts)
                    {
                        if (arrowStart.Contains(mouseLocation))
                        {
                            endingPointParentCell = cell;
                            endingPointSide = arrowStart.Side;
                            Debug.WriteLine("[GM] AddArrow > FOUND ending point parent cell set as cell with id " + cell.ID);
                            Debug.WriteLine("[GM] AddArrow > FOUND ending point side set as " + arrowStart.Side);
                        }
                    }
                }

                if (startingPoint.ParentCellID == cell.ID && startingPointParentCell == null)
                {
                    startingPointParentCell = cell;
                    Debug.WriteLine("[GM] AddArrow > FOUND starting point parent cell set as cell with id " + cell.ID);
                }
            }
            Debug.WriteLine($"[GM] AddArrow > ==============================================================================");

            if (endingPointParentCell == null || endingPointSide == -1 || startingPointParentCell == null) 
            {
                Debug.WriteLine("[GM] AddArrow > ERROR values not set");
                return;
            }

            string guideline = this.SetArrowGuideline(startingPoint.Side, endingPointSide);
            Arrow newArrow = new Arrow(cells, startingPointParentCell.ID, startingPoint.Side, endingPointParentCell.ID, endingPointSide, guideline, ArrowStyle, LineStyle);

            Arrow arrowToRemove = null;
            foreach (Arrow arrow in arrows)
            {
                if (newArrow.AlreadyExists(arrow))
                {
                    RemoveArrow(arrow);
                    Debug.WriteLine("[GM] AddArrow > arrow already exists");
                    return;
                }

                if (!newArrow.CanBeCreated(arrow))
                {
                    Debug.WriteLine("[GM] AddArrow > arrow is on the same arrow start");
                    arrowToRemove = arrow;
                }
            }

            if (arrowToRemove != null) RemoveArrow(arrowToRemove);


            Debug.WriteLine($"[GM] AddArrow > if ({startingPoint.ParentCellID} != {endingPointParentCell.ID}");
            if (startingPoint.ParentCellID != endingPointParentCell.ID)
            {
                Debug.WriteLine("[GM] AddArrow > adding Arrow");
                this.arrows.Add(newArrow);
            }
            else
            {
                Debug.WriteLine("[GM] AddArrow > arrow is on the same cell");
            }
        }

        private void RemoveArrow(Arrow arrow)
        {
            Debug.WriteLine("[GM] RemoveArrow > removing Arrow");
            arrows.Remove(arrow);
        }

        public void AddCell(PictureBox pb)
        {
            bool success = true;
            do
            {
                Debug.WriteLine($"[GM] AddCell > Updating cell id index from: {cellIDindex} to {cellIDindex + 1}");
                cellIDindex++;
                foreach (Cell cell in cells)
                {
                    Debug.WriteLine($"[GM] AddCell > checking if {cell.ID} is equal to {cellIDindex}");
                    if (cell.ID == cellIDindex)
                    {
                        Debug.WriteLine($"[GM] AddCell > Cell index already exists, adding updating again");
                        success = false;
                        break;
                    }

                    success = true;
                }
            } while (!success);
            Debug.WriteLine($"[GM] AddCell > Adding cell with id: {cellIDindex}");
            cells.Add(new Cell(cellIDindex, new PointF(pb.Width, pb.Height)));
        }

        public void AddCell(Cell cell)
        {
            cell.ClearArrowStarts();
            Debug.WriteLine($"[GM] AddCell2 > Adding cell with id: {cell.ID}");
            cells.Add(cell);
        }

        public void MoveCell(Cell draggedCell, PointF mouseLocation)
        {
            draggedCell.Update(mouseLocation);
        }

        public void MoveAim(ArrowStart arrowStart, PointF mouseLocation)
        {
            aimLine = new AimLine(arrowStart.Center);
            aimLine.Update(mouseLocation);
        }

        public Cell FindCell(PointF mouseLocation)
        {
            foreach (Cell cell in cells)
            {
                if (cell.Box.Contains(mouseLocation))
                {
                    return cell;
                }
            }

            return null;
        }

        public ArrowStart FindArrowStart(PointF mouseLocation)
        {
            foreach (Cell cell in cells)
            {
                foreach (ArrowStart arrowStart in cell.arrowStarts)
                {
                    if (arrowStart.Contains(mouseLocation)) 
                    {
                        DrawAim = true;
                        Debug.WriteLine("[GM] FindArrowStart > found arrowstart with parent cell id: " + arrowStart.ParentCellID);
                        
                        return arrowStart;
                    }
                }
            }

            return null;
        }

        public int GetCellIndex(Cell cell)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i] == cell)
                {
                    return i;
                }
            }

            return -1;
        }
        public void RemoveCellByIndex(int index)
        {
            int id = cells[index].ID;
            List<int> arrowsIndexes = new List<int>();

            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].SourceCellID == id || arrows[i].TargetCellID == id) arrowsIndexes.Add(i);
            }

            for (int i = 0; i < arrowsIndexes.Count; i++)
            {
                arrows.RemoveAt(arrowsIndexes[i] - i);
            }

            cells.RemoveAt(index);
        }

        public void UpdateToSize(PictureBox pb)
        {
            foreach (Cell cell in cells)
            {
                if (cell.location.X + cell.Box.X > pb.Width)
                {
                    cell.location = new PointF(cell.location.X - (cell.location.X - pb.Width), cell.location.Y);
                }

                if (cell.location.Y + cell.Box.Y > pb.Height)
                {
                    cell.location = new PointF(cell.location.X, cell.location.Y - (cell.location.Y - pb.Height));
                }
            }
        }

        private string SetArrowGuideline(int startingPoint, int endingPoint)
        {
            string guideline = "";

            if (startingPoint == 0 && endingPoint == 0 ||
                startingPoint == 0 && endingPoint == 1 ||
                startingPoint == 1 && endingPoint == 0 ||
                startingPoint == 1 && endingPoint == 1)
            {
                guideline = "h-h";
            }
            else if (
                startingPoint == 2 && endingPoint == 2 ||
                startingPoint == 2 && endingPoint == 3 ||
                startingPoint == 3 && endingPoint == 2 ||
                startingPoint == 3 && endingPoint == 3)
            {
                guideline = "v-v";
            }
            else if (
                startingPoint == 2 && endingPoint == 0 ||
                startingPoint == 2 && endingPoint == 1 ||
                startingPoint == 3 && endingPoint == 0 ||
                startingPoint == 3 && endingPoint == 1)
            {
                guideline = "v-h";
            }
            else if (
                startingPoint == 0 && endingPoint == 2 ||
                startingPoint == 0 && endingPoint == 3 ||
                startingPoint == 1 && endingPoint == 2 ||
                startingPoint == 1 && endingPoint == 3)
            {
                guideline = "h-v";
            }
            else
            {
                throw new Exception("Unknown error in calculating arrow guideline.");
            }

            Debug.WriteLine("[GM] SetArrowGuideline > guideline set as " + guideline);
            return guideline;
        }

        public DiagramFile CreateFile()
        {
            DiagramFile diagramFile = new DiagramFile();
            Debug.WriteLine($"[GM] CreateFile > BEGINNING EXPORT TO FILE =====================");

            foreach (Cell cell in cells)
            {
                Debug.WriteLine($"EXPORTING CELL " + cell.ID);
                diagramFile.cells.Add(cell);
            }

            foreach (Arrow arrow in arrows)
            {
                Debug.WriteLine($"EXPORTING ARROW " + arrow.ToString());
                diagramFile.arrows.Add(arrow);
            }

            Debug.WriteLine($"[GM] CreateFile > FINISHED EXPORT TO FILE =======================");
            return diagramFile;
        }

        public void ReadFile(DiagramFile file)
        {
            Debug.Flush();
            Debug.WriteLine($"[GM] ReadFile > BEGIN IMPORT ==================================");
            
            foreach (Cell cell in file.cells)
            {
                Debug.WriteLine($"IMPORTING CELL " + cell.ID);
                cells.Add(cell);
            }
            Debug.WriteLine($"[GM] ======== CELL SIZE CHECK FILE({file.cells.Count}) = LIST({cells.Count})");

            foreach (Arrow arrow in file.arrows)
            {
                Debug.WriteLine($"IMPORTING ARROW + {arrow.ToString()}");
                arrows.Add(new Arrow(arrow, cells));
            }
            Debug.WriteLine($"Importer arrows ======================");
            foreach (Arrow arrow in arrows)
            {
                Debug.WriteLine($"arrow + {arrow.ToString()}");
            }
            Debug.WriteLine($"[GM] ======== ARROW SIZE CHECK FILE({file.arrows.Count}) = LIST({arrows.Count})");
            Debug.WriteLine($"[GM] ReadFile > IMPORT FINISHED ==================================");
        }

        public void Clear()
        {
            this.arrows.Clear();
            this.cells.Clear();
            this.cellIDindex = -1;
        }

        public List<Cell> getAllCells()
        { 
            return this.cells;
        }
    }
}
