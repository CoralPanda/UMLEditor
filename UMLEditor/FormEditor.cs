using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UMLEditor.Classes;
using UMLEditor.Classes.Underclasses;

namespace UMLEditor
{
    public partial class FormEditor : Form
    {
        public Cell selectedCell;
        public Cell returnCell;

        private Cell originalCell;

        private bool editingAttribute = false;
        private bool editingMethod = false;

        private List<MethodInput> currentlyEditingMethodInputs = new List<MethodInput>();

        private int currentlyEditingAttributeIndex = -1;
        private int currentlyEditingMethodIndex = -1;

        private List<Cell> interfaces = new List<Cell>();

        private string[] accessModifiersList = new string[4] { "+ -> Public", "- -> Private", "# -> Protected", "~ -> Internal" };

        public FormEditor(Cell cell, List<Cell> cells)
        {
            InitializeComponent();
            originalCell = (Cell)cell.Clone();

            interfaces.Add(new Cell(-5, new PointF(0,0)) { ClassName = "Import from interface..."});
            foreach (Cell interfaceCell in cells)
            {
                if (interfaceCell.Interface)
                {
                    interfaces.Add(interfaceCell);
                }
            }
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            selectedCell = (Cell)originalCell.Clone();
            returnCell = (Cell)originalCell.Clone();
            textBoxClassName.Text = returnCell.ClassName;
            comboBoxAttributeAccessModifier.DataSource = accessModifiersList.ToArray();
            comboBoxMethodAccessModifier.DataSource = accessModifiersList.ToArray();
            listBoxAttributes.Items.AddRange(selectedCell.Attributes.ToArray());
            listBoxMethods.Items.AddRange(returnCell.Methods.ToArray());
            checkBox1.Checked = originalCell.Interface;
            comboBoxInterfaceToImport.DataSource = interfaces.ToArray();
        }

        // ATTRIBUTE ------------------------------------------------------------------
        private void buttonAttributeEdit_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            if (listBoxAttributes.SelectedIndex > -1)
            {
                this.editingAttribute = true;
                this.currentlyEditingAttributeIndex = listBoxAttributes.SelectedIndex;

                buttonAttributeSave.Enabled = true;

                ClassAttribute editingAttribute = listBoxAttributes.SelectedItem as ClassAttribute;

                for (int i = 0; i < accessModifiersList.Length; i++)
                {
                    if (accessModifiersList[i].First() == editingAttribute.AccessModifier)
                    {
                        comboBoxAttributeAccessModifier.SelectedIndex = i;
                        break;
                    }
                }

                textBoxAttributeName.Text = editingAttribute.Name;

                textBoxAttributeDataType.Text = editingAttribute.DataType;
            }
        }

        private void buttonAttributeSave_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            if (!string.IsNullOrEmpty(textBoxAttributeName.Text) && !string.IsNullOrEmpty(textBoxAttributeDataType.Text))
            {
                listBoxAttributes.Items[currentlyEditingAttributeIndex] = new ClassAttribute()
                {
                    AccessModifier = accessModifiersList[comboBoxAttributeAccessModifier.SelectedIndex].First(),
                    Name = textBoxAttributeName.Text,
                    DataType = textBoxAttributeDataType.Text
                };

                editingAttribute = false;
                buttonAttributeSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please, fill out all the fields.");
            }
        }

        private void buttonAttributeAdd_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            if (!string.IsNullOrEmpty(textBoxAttributeName.Text) && !string.IsNullOrEmpty(textBoxAttributeDataType.Text))
            {
                listBoxAttributes.Items.Add(new ClassAttribute()
                {
                    AccessModifier = accessModifiersList[comboBoxAttributeAccessModifier.SelectedIndex].First(),
                    Name = textBoxAttributeName.Text,
                    DataType = textBoxAttributeDataType.Text
                });

                editingAttribute = false;
                buttonAttributeSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please, fill out all the fields.");
            }
        }

        private void buttonAttributeClear_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            comboBoxAttributeAccessModifier.SelectedIndex = 0;
            textBoxAttributeName.Text = "";
            textBoxAttributeDataType.Text = "";
        }

        private void buttonAttributeDelete_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            if (listBoxAttributes.SelectedIndex >= 0)
            {
                listBoxAttributes.Items.RemoveAt(listBoxAttributes.SelectedIndex);
                buttonAttributeSave.Enabled = false;
            }
        }

        // METHOD ------------------------------------------------------------------
        private void buttonMethodEdit_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            if (listBoxMethods.SelectedIndex >= 0)
            {
                listBoxMethodInputs.Items.Clear();
                currentlyEditingMethodIndex = listBoxMethods.SelectedIndex;
                ClassMethod classMethod = (ClassMethod)listBoxMethods.SelectedItem;
                currentlyEditingMethodInputs = classMethod.Input;

                ClassMethod editingMethod = listBoxMethods.SelectedItem as ClassMethod;

                for (int i = 0; i < accessModifiersList.Length; i++)
                {
                    if (accessModifiersList[i].First() == editingMethod.AccessModifier)
                    {
                        comboBoxMethodAccessModifier.SelectedIndex = i;
                        break;
                    }
                }

                textBoxMethodName.Text = editingMethod.Name;
                listBoxMethodInputs.Items.Clear();
                listBoxMethodInputs.Items.AddRange(editingMethod.Input.ToArray());
                textBoxMethodOutput.Text = editingMethod.Output;

                buttonMethodSave.Enabled = true;
            }
        }

        private void buttonMethodSave_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            if (!string.IsNullOrEmpty(textBoxMethodName.Text) && !string.IsNullOrEmpty(textBoxMethodOutput.Text))
            {
                listBoxMethods.Items[listBoxMethods.SelectedIndex] = new ClassMethod()
                {
                    AccessModifier = accessModifiersList[comboBoxMethodAccessModifier.SelectedIndex].First(),
                    Name = textBoxMethodName.Text,
                    Input = currentlyEditingMethodInputs,
                    Output = textBoxMethodOutput.Text
                };

                buttonMethodSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please, fill out all the fields.");
            }

        }

        private void buttonMethodInputEdit_Click(object sender, EventArgs e) // HOTOVO ==============================================================
        {
            List<MethodInput> list = new List<MethodInput>();
            foreach (MethodInput input in listBoxMethodInputs.Items)
            {
                list.Add(input);
            }
            using (FormEditorInput form = new FormEditorInput(textBoxMethodName.Text, list))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    listBoxMethodInputs.Items.Clear();
                    currentlyEditingMethodInputs = form.methodInputNew;
                    listBoxMethodInputs.Items.AddRange(currentlyEditingMethodInputs.ToArray());
                }
            }
        }

        private void buttonMethodClear_Click(object sender, EventArgs e)
        {
            comboBoxMethodAccessModifier.SelectedIndex = 0;
            listBoxMethodInputs.Items.Clear();
            textBoxMethodName.Text = "";
            textBoxMethodOutput.Text = "";
        }

        private void buttonMethodAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxMethodName.Text) && !string.IsNullOrEmpty(textBoxMethodOutput.Text))
            {
                listBoxMethods.Items.Add(new ClassMethod()
                {
                    AccessModifier = accessModifiersList[comboBoxMethodAccessModifier.SelectedIndex].First(),
                    Name = textBoxMethodName.Text,
                    Input = currentlyEditingMethodInputs,
                    Output = textBoxMethodOutput.Text
                });

                buttonMethodSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please, fill out all the fields.");
            }

        }

        private void buttonMethodDelete_Click(object sender, EventArgs e)
        {
            if (listBoxMethods.SelectedIndex >= 0)
            {
                listBoxMethods.Items.RemoveAt(listBoxMethods.SelectedIndex);
                buttonMethodSave.Enabled = false;
            }
        }

        private void buttonFormOK_Click(object sender, EventArgs e)
        {

            returnCell.ClassName = textBoxClassName.Text;

            returnCell.Attributes.Clear();
            foreach (object att in listBoxAttributes.Items)
            {
                ClassAttribute attClass = (ClassAttribute)att;

                if (checkBox1.Checked) attClass.AccessModifier = '+';
                returnCell.Attributes.Add(attClass);
            }


            returnCell.Methods.Clear();
            foreach (object method in listBoxMethods.Items)
            {
                ClassMethod methodClass = (ClassMethod)method;

                if (checkBox1.Checked) methodClass.AccessModifier = '+';
                returnCell.Methods.Add((ClassMethod)method);
            }

            returnCell.Interface = checkBox1.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonFormCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonFormDeleteCell_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxInterfaceToImport.Enabled = !checkBox1.Checked;

            comboBoxAttributeAccessModifier.Enabled = !checkBox1.Checked;
            comboBoxMethodAccessModifier.Enabled = !checkBox1.Checked;

            comboBoxAttributeAccessModifier.SelectedIndex = 0;
            comboBoxMethodAccessModifier.SelectedIndex = 0;
        }

        private void buttonImportFromInterface_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[FE] import interface started");
            if (comboBoxInterfaceToImport.SelectedIndex < 1) return;
            Debug.WriteLine("[FE] import interface continuing");

            listBoxMethods.Items.Clear();
            listBoxAttributes.Items.Clear();

            Debug.WriteLine("[FE] importing from index" + comboBoxInterfaceToImport.SelectedIndex + " class " + interfaces[comboBoxInterfaceToImport.SelectedIndex].ClassName);

            foreach (ClassMethod method in interfaces[comboBoxInterfaceToImport.SelectedIndex].Methods)
            {
                Debug.WriteLine("[FE] import adding method "  + method.Name);
                listBoxMethods.Items.Add(method);
            }


            foreach (ClassAttribute attribute in interfaces[comboBoxInterfaceToImport.SelectedIndex].Attributes)
            {
                Debug.WriteLine("[FE] import adding attribute " + attribute.Name);
                listBoxAttributes.Items.Add(attribute);
            }
        }
    }
}
