using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLEditor.Classes.Underclasses;

namespace UMLEditor
{
    public partial class FormEditorInput : Form
    {
        public List<MethodInput> methodInputNew = new List<MethodInput>();
        private string[] accessModifiersList = new string[4] { "+ -> Public", "- -> Private", "# -> Protected", "~ -> Internal" };

        public FormEditorInput(string methodName, List<MethodInput> methodInputs)
        {
            InitializeComponent();

            listBoxInputList.Items.AddRange(methodInputs.ToArray());
            labelMethodName.Text = methodName;
        }

        private void buttonInputAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxInputDataType.Text) && !string.IsNullOrEmpty(textBoxInputName.Text))
            {
                listBoxInputList.Items.Add(new MethodInput() { DataType = textBoxInputDataType.Text, Name = textBoxInputName.Text });
            }
            else
            {
                MessageBox.Show("Please, fill out all the fields.");
            }
        }

        private void buttonInputClear_Click(object sender, EventArgs e)
        {
            textBoxInputDataType.Clear();
            textBoxInputName.Clear();
        }

        private void buttonInputListDelete_Click(object sender, EventArgs e)
        {
            if (listBoxInputList.SelectedIndex >= 0)
            {
                listBoxInputList.Items.RemoveAt(listBoxInputList.SelectedIndex);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            foreach (MethodInput mi in listBoxInputList.Items)
            {
                methodInputNew.Add(mi);
            }
            
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonInputCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
