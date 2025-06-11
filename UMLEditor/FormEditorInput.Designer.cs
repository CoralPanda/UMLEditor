namespace UMLEditor
{
    partial class FormEditorInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxInputName = new TextBox();
            groupBox1 = new GroupBox();
            textBoxInputDataType = new TextBox();
            buttonInputAdd = new Button();
            buttonInputClear = new Button();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            buttonInputListDelete = new Button();
            listBoxInputList = new ListBox();
            labelMethodName = new Label();
            buttonOK = new Button();
            buttonInputCancel = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 28);
            label1.TabIndex = 0;
            label1.Text = "Method name: ";
            // 
            // textBoxInputName
            // 
            textBoxInputName.Location = new Point(6, 91);
            textBoxInputName.Name = "textBoxInputName";
            textBoxInputName.PlaceholderText = "Insert name for input...";
            textBoxInputName.Size = new Size(395, 23);
            textBoxInputName.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxInputDataType);
            groupBox1.Controls.Add(buttonInputAdd);
            groupBox1.Controls.Add(buttonInputClear);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxInputName);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(407, 154);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input";
            // 
            // textBoxInputDataType
            // 
            textBoxInputDataType.Location = new Point(6, 43);
            textBoxInputDataType.Name = "textBoxInputDataType";
            textBoxInputDataType.Size = new Size(138, 23);
            textBoxInputDataType.TabIndex = 7;
            // 
            // buttonInputAdd
            // 
            buttonInputAdd.ForeColor = Color.Black;
            buttonInputAdd.Location = new Point(185, 120);
            buttonInputAdd.Name = "buttonInputAdd";
            buttonInputAdd.Size = new Size(105, 28);
            buttonInputAdd.TabIndex = 6;
            buttonInputAdd.Text = "Add";
            buttonInputAdd.UseVisualStyleBackColor = true;
            buttonInputAdd.Click += buttonInputAdd_Click;
            // 
            // buttonInputClear
            // 
            buttonInputClear.ForeColor = Color.Black;
            buttonInputClear.Location = new Point(296, 120);
            buttonInputClear.Name = "buttonInputClear";
            buttonInputClear.Size = new Size(105, 28);
            buttonInputClear.TabIndex = 5;
            buttonInputClear.Text = "Clear";
            buttonInputClear.UseVisualStyleBackColor = true;
            buttonInputClear.Click += buttonInputClear_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 73);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 25);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Data type";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonInputListDelete);
            groupBox2.Controls.Add(listBoxInputList);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(12, 201);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(407, 233);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "List of inputs on this method";
            // 
            // buttonInputListDelete
            // 
            buttonInputListDelete.ForeColor = Color.Black;
            buttonInputListDelete.Location = new Point(296, 197);
            buttonInputListDelete.Name = "buttonInputListDelete";
            buttonInputListDelete.Size = new Size(105, 28);
            buttonInputListDelete.TabIndex = 7;
            buttonInputListDelete.Text = "Delete";
            buttonInputListDelete.UseVisualStyleBackColor = true;
            buttonInputListDelete.Click += buttonInputListDelete_Click;
            // 
            // listBoxInputList
            // 
            listBoxInputList.FormattingEnabled = true;
            listBoxInputList.ItemHeight = 15;
            listBoxInputList.Location = new Point(6, 22);
            listBoxInputList.Name = "listBoxInputList";
            listBoxInputList.Size = new Size(395, 169);
            listBoxInputList.TabIndex = 0;
            // 
            // labelMethodName
            // 
            labelMethodName.AutoSize = true;
            labelMethodName.BackColor = Color.Transparent;
            labelMethodName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            labelMethodName.ForeColor = Color.White;
            labelMethodName.Location = new Point(147, 9);
            labelMethodName.Name = "labelMethodName";
            labelMethodName.Size = new Size(271, 30);
            labelMethodName.TabIndex = 5;
            labelMethodName.Text = "method name placeholder";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(203, 440);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(105, 28);
            buttonOK.TabIndex = 6;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonInputCancel
            // 
            buttonInputCancel.Location = new Point(314, 440);
            buttonInputCancel.Name = "buttonInputCancel";
            buttonInputCancel.Size = new Size(105, 28);
            buttonInputCancel.TabIndex = 7;
            buttonInputCancel.Text = "Cancel";
            buttonInputCancel.UseVisualStyleBackColor = true;
            buttonInputCancel.Click += buttonInputCancel_Click;
            // 
            // FormEditorInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(433, 477);
            Controls.Add(buttonInputCancel);
            Controls.Add(buttonOK);
            Controls.Add(labelMethodName);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "FormEditorInput";
            Text = "Editing inputs";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxInputName;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Button button2;
        private Button button1;
        private ListBox listBox1;
        private Button buttonInputAdd;
        private Button buttonInputClear;
        private Label labelMethodName;
        private Button buttonInputListDelete;
        private ListBox listBoxInputList;
        private TextBox textBoxInputDataType;
        private Button buttonOK;
        private Button buttonInputCancel;
    }
}