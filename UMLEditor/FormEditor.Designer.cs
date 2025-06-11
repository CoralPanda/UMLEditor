namespace UMLEditor
{
    partial class FormEditor
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
            textBoxClassName = new TextBox();
            textBoxAttributeName = new TextBox();
            comboBoxAttributeAccessModifier = new ComboBox();
            groupBox1 = new GroupBox();
            groupBoxAttribute = new GroupBox();
            buttonAttributeAdd = new Button();
            textBoxAttributeDataType = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonAttributeClear = new Button();
            buttonAttributeSave = new Button();
            listBoxAttributes = new ListBox();
            groupBox3 = new GroupBox();
            buttonAttributeEdit = new Button();
            buttonAttributeDelete = new Button();
            groupBoxMethod = new GroupBox();
            buttonMethodAdd = new Button();
            textBoxMethodOutput = new TextBox();
            buttonMethodInputEdit = new Button();
            label7 = new Label();
            listBoxMethodInputs = new ListBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonMethodClear = new Button();
            comboBoxMethodAccessModifier = new ComboBox();
            buttonMethodSave = new Button();
            textBoxMethodName = new TextBox();
            groupBox5 = new GroupBox();
            buttonMethodEdit = new Button();
            buttonMethodDelete = new Button();
            listBoxMethods = new ListBox();
            buttonFormOK = new Button();
            buttonFormCancel = new Button();
            buttonFormDeleteCell = new Button();
            checkBox1 = new CheckBox();
            buttonImportFromInterface = new Button();
            comboBoxInterfaceToImport = new ComboBox();
            groupBox1.SuspendLayout();
            groupBoxAttribute.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBoxMethod.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxClassName
            // 
            textBoxClassName.BackColor = Color.WhiteSmoke;
            textBoxClassName.Location = new Point(6, 30);
            textBoxClassName.Name = "textBoxClassName";
            textBoxClassName.Size = new Size(964, 34);
            textBoxClassName.TabIndex = 0;
            // 
            // textBoxAttributeName
            // 
            textBoxAttributeName.BackColor = Color.WhiteSmoke;
            textBoxAttributeName.Font = new Font("Segoe UI", 9F);
            textBoxAttributeName.Location = new Point(6, 97);
            textBoxAttributeName.Name = "textBoxAttributeName";
            textBoxAttributeName.Size = new Size(591, 23);
            textBoxAttributeName.TabIndex = 2;
            // 
            // comboBoxAttributeAccessModifier
            // 
            comboBoxAttributeAccessModifier.BackColor = Color.WhiteSmoke;
            comboBoxAttributeAccessModifier.Font = new Font("Segoe UI", 9F);
            comboBoxAttributeAccessModifier.FormattingEnabled = true;
            comboBoxAttributeAccessModifier.Location = new Point(6, 49);
            comboBoxAttributeAccessModifier.Name = "comboBoxAttributeAccessModifier";
            comboBoxAttributeAccessModifier.Size = new Size(179, 23);
            comboBoxAttributeAccessModifier.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(textBoxClassName);
            groupBox1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 238);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(976, 70);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Class name";
            // 
            // groupBoxAttribute
            // 
            groupBoxAttribute.Controls.Add(buttonAttributeAdd);
            groupBoxAttribute.Controls.Add(textBoxAttributeDataType);
            groupBoxAttribute.Controls.Add(label3);
            groupBoxAttribute.Controls.Add(label2);
            groupBoxAttribute.Controls.Add(label1);
            groupBoxAttribute.Controls.Add(buttonAttributeClear);
            groupBoxAttribute.Controls.Add(comboBoxAttributeAccessModifier);
            groupBoxAttribute.Controls.Add(buttonAttributeSave);
            groupBoxAttribute.Controls.Add(textBoxAttributeName);
            groupBoxAttribute.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBoxAttribute.ForeColor = Color.White;
            groupBoxAttribute.Location = new Point(12, 96);
            groupBoxAttribute.Name = "groupBoxAttribute";
            groupBoxAttribute.Size = new Size(603, 211);
            groupBoxAttribute.TabIndex = 6;
            groupBoxAttribute.TabStop = false;
            groupBoxAttribute.Text = "Attribute";
            // 
            // buttonAttributeAdd
            // 
            buttonAttributeAdd.Font = new Font("Segoe UI", 9F);
            buttonAttributeAdd.ForeColor = Color.Black;
            buttonAttributeAdd.Location = new Point(222, 169);
            buttonAttributeAdd.Name = "buttonAttributeAdd";
            buttonAttributeAdd.Size = new Size(121, 36);
            buttonAttributeAdd.TabIndex = 16;
            buttonAttributeAdd.Text = "Add / Copy";
            buttonAttributeAdd.UseVisualStyleBackColor = true;
            buttonAttributeAdd.Click += buttonAttributeAdd_Click;
            // 
            // textBoxAttributeDataType
            // 
            textBoxAttributeDataType.BackColor = Color.WhiteSmoke;
            textBoxAttributeDataType.Font = new Font("Segoe UI", 9F);
            textBoxAttributeDataType.Location = new Point(7, 145);
            textBoxAttributeDataType.Name = "textBoxAttributeDataType";
            textBoxAttributeDataType.Size = new Size(179, 23);
            textBoxAttributeDataType.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(7, 127);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 10;
            label3.Text = "Data type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(7, 79);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 9;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(7, 31);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 8;
            label1.Text = "Access modifier";
            // 
            // buttonAttributeClear
            // 
            buttonAttributeClear.Font = new Font("Segoe UI", 9F);
            buttonAttributeClear.ForeColor = Color.Black;
            buttonAttributeClear.Location = new Point(476, 169);
            buttonAttributeClear.Name = "buttonAttributeClear";
            buttonAttributeClear.Size = new Size(121, 36);
            buttonAttributeClear.TabIndex = 6;
            buttonAttributeClear.Text = "Clear";
            buttonAttributeClear.UseVisualStyleBackColor = true;
            buttonAttributeClear.Click += buttonAttributeClear_Click;
            // 
            // buttonAttributeSave
            // 
            buttonAttributeSave.Enabled = false;
            buttonAttributeSave.Font = new Font("Segoe UI", 9F);
            buttonAttributeSave.ForeColor = Color.Black;
            buttonAttributeSave.Location = new Point(349, 169);
            buttonAttributeSave.Name = "buttonAttributeSave";
            buttonAttributeSave.Size = new Size(121, 36);
            buttonAttributeSave.TabIndex = 5;
            buttonAttributeSave.Text = "Save";
            buttonAttributeSave.UseVisualStyleBackColor = true;
            buttonAttributeSave.Click += buttonAttributeSave_Click;
            // 
            // listBoxAttributes
            // 
            listBoxAttributes.BackColor = Color.WhiteSmoke;
            listBoxAttributes.Font = new Font("Segoe UI", 9F);
            listBoxAttributes.FormattingEnabled = true;
            listBoxAttributes.HorizontalScrollbar = true;
            listBoxAttributes.ItemHeight = 15;
            listBoxAttributes.Location = new Point(6, 33);
            listBoxAttributes.Name = "listBoxAttributes";
            listBoxAttributes.Size = new Size(355, 139);
            listBoxAttributes.TabIndex = 7;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonAttributeEdit);
            groupBox3.Controls.Add(buttonAttributeDelete);
            groupBox3.Controls.Add(listBoxAttributes);
            groupBox3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(621, 96);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(367, 211);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "List of attributes";
            // 
            // buttonAttributeEdit
            // 
            buttonAttributeEdit.Font = new Font("Segoe UI", 9F);
            buttonAttributeEdit.ForeColor = Color.Black;
            buttonAttributeEdit.Location = new Point(6, 176);
            buttonAttributeEdit.Name = "buttonAttributeEdit";
            buttonAttributeEdit.Size = new Size(112, 29);
            buttonAttributeEdit.TabIndex = 9;
            buttonAttributeEdit.Text = "Edit";
            buttonAttributeEdit.UseVisualStyleBackColor = true;
            buttonAttributeEdit.Click += buttonAttributeEdit_Click;
            // 
            // buttonAttributeDelete
            // 
            buttonAttributeDelete.Font = new Font("Segoe UI", 9F);
            buttonAttributeDelete.ForeColor = Color.Black;
            buttonAttributeDelete.Location = new Point(124, 176);
            buttonAttributeDelete.Name = "buttonAttributeDelete";
            buttonAttributeDelete.Size = new Size(115, 29);
            buttonAttributeDelete.TabIndex = 8;
            buttonAttributeDelete.Text = "Delete";
            buttonAttributeDelete.UseVisualStyleBackColor = true;
            buttonAttributeDelete.Click += buttonAttributeDelete_Click;
            // 
            // groupBoxMethod
            // 
            groupBoxMethod.Controls.Add(buttonMethodAdd);
            groupBoxMethod.Controls.Add(textBoxMethodOutput);
            groupBoxMethod.Controls.Add(buttonMethodInputEdit);
            groupBoxMethod.Controls.Add(label7);
            groupBoxMethod.Controls.Add(listBoxMethodInputs);
            groupBoxMethod.Controls.Add(label4);
            groupBoxMethod.Controls.Add(label5);
            groupBoxMethod.Controls.Add(label6);
            groupBoxMethod.Controls.Add(buttonMethodClear);
            groupBoxMethod.Controls.Add(comboBoxMethodAccessModifier);
            groupBoxMethod.Controls.Add(buttonMethodSave);
            groupBoxMethod.Controls.Add(textBoxMethodName);
            groupBoxMethod.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBoxMethod.ForeColor = Color.White;
            groupBoxMethod.Location = new Point(12, 313);
            groupBoxMethod.Name = "groupBoxMethod";
            groupBoxMethod.Size = new Size(571, 306);
            groupBoxMethod.TabIndex = 11;
            groupBoxMethod.TabStop = false;
            groupBoxMethod.Text = "Method";
            // 
            // buttonMethodAdd
            // 
            buttonMethodAdd.Font = new Font("Segoe UI", 9F);
            buttonMethodAdd.ForeColor = Color.Black;
            buttonMethodAdd.Location = new Point(190, 260);
            buttonMethodAdd.Name = "buttonMethodAdd";
            buttonMethodAdd.Size = new Size(121, 36);
            buttonMethodAdd.TabIndex = 15;
            buttonMethodAdd.Text = "Add / Copy";
            buttonMethodAdd.UseVisualStyleBackColor = true;
            buttonMethodAdd.Click += buttonMethodAdd_Click;
            // 
            // textBoxMethodOutput
            // 
            textBoxMethodOutput.BackColor = Color.WhiteSmoke;
            textBoxMethodOutput.Font = new Font("Segoe UI", 9F);
            textBoxMethodOutput.Location = new Point(6, 228);
            textBoxMethodOutput.Name = "textBoxMethodOutput";
            textBoxMethodOutput.Size = new Size(179, 23);
            textBoxMethodOutput.TabIndex = 14;
            // 
            // buttonMethodInputEdit
            // 
            buttonMethodInputEdit.Font = new Font("Segoe UI", 9F);
            buttonMethodInputEdit.ForeColor = Color.Black;
            buttonMethodInputEdit.Location = new Point(323, 184);
            buttonMethodInputEdit.Name = "buttonMethodInputEdit";
            buttonMethodInputEdit.Size = new Size(75, 23);
            buttonMethodInputEdit.TabIndex = 13;
            buttonMethodInputEdit.Text = "Edit";
            buttonMethodInputEdit.UseVisualStyleBackColor = true;
            buttonMethodInputEdit.Click += buttonMethodInputEdit_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(6, 125);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 12;
            label7.Text = "Input list";
            // 
            // listBoxMethodInputs
            // 
            listBoxMethodInputs.BackColor = Color.WhiteSmoke;
            listBoxMethodInputs.Font = new Font("Segoe UI", 9F);
            listBoxMethodInputs.FormattingEnabled = true;
            listBoxMethodInputs.ItemHeight = 15;
            listBoxMethodInputs.Location = new Point(7, 143);
            listBoxMethodInputs.Name = "listBoxMethodInputs";
            listBoxMethodInputs.Size = new Size(310, 64);
            listBoxMethodInputs.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(7, 210);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 10;
            label4.Text = "Output data type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(7, 70);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(7, 29);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 8;
            label6.Text = "Access modifier";
            // 
            // buttonMethodClear
            // 
            buttonMethodClear.Font = new Font("Segoe UI", 9F);
            buttonMethodClear.ForeColor = Color.Black;
            buttonMethodClear.Location = new Point(444, 260);
            buttonMethodClear.Name = "buttonMethodClear";
            buttonMethodClear.Size = new Size(121, 36);
            buttonMethodClear.TabIndex = 6;
            buttonMethodClear.Text = "Clear";
            buttonMethodClear.UseVisualStyleBackColor = true;
            buttonMethodClear.Click += buttonMethodClear_Click;
            // 
            // comboBoxMethodAccessModifier
            // 
            comboBoxMethodAccessModifier.BackColor = Color.WhiteSmoke;
            comboBoxMethodAccessModifier.Font = new Font("Segoe UI", 9F);
            comboBoxMethodAccessModifier.FormattingEnabled = true;
            comboBoxMethodAccessModifier.Location = new Point(6, 47);
            comboBoxMethodAccessModifier.Name = "comboBoxMethodAccessModifier";
            comboBoxMethodAccessModifier.Size = new Size(179, 23);
            comboBoxMethodAccessModifier.TabIndex = 3;
            // 
            // buttonMethodSave
            // 
            buttonMethodSave.Enabled = false;
            buttonMethodSave.Font = new Font("Segoe UI", 9F);
            buttonMethodSave.ForeColor = Color.Black;
            buttonMethodSave.Location = new Point(317, 260);
            buttonMethodSave.Name = "buttonMethodSave";
            buttonMethodSave.Size = new Size(121, 36);
            buttonMethodSave.TabIndex = 5;
            buttonMethodSave.Text = "Save";
            buttonMethodSave.UseVisualStyleBackColor = true;
            buttonMethodSave.Click += buttonMethodSave_Click;
            // 
            // textBoxMethodName
            // 
            textBoxMethodName.BackColor = Color.WhiteSmoke;
            textBoxMethodName.Font = new Font("Segoe UI", 9F);
            textBoxMethodName.Location = new Point(6, 95);
            textBoxMethodName.Name = "textBoxMethodName";
            textBoxMethodName.Size = new Size(559, 23);
            textBoxMethodName.TabIndex = 2;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(buttonMethodEdit);
            groupBox5.Controls.Add(buttonMethodDelete);
            groupBox5.Controls.Add(listBoxMethods);
            groupBox5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(589, 313);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(399, 306);
            groupBox5.TabIndex = 10;
            groupBox5.TabStop = false;
            groupBox5.Text = "List of methods";
            // 
            // buttonMethodEdit
            // 
            buttonMethodEdit.Font = new Font("Segoe UI", 9F);
            buttonMethodEdit.ForeColor = Color.Black;
            buttonMethodEdit.Location = new Point(6, 267);
            buttonMethodEdit.Name = "buttonMethodEdit";
            buttonMethodEdit.Size = new Size(131, 29);
            buttonMethodEdit.TabIndex = 9;
            buttonMethodEdit.Text = "Edit";
            buttonMethodEdit.UseVisualStyleBackColor = true;
            buttonMethodEdit.Click += buttonMethodEdit_Click;
            // 
            // buttonMethodDelete
            // 
            buttonMethodDelete.Font = new Font("Segoe UI", 9F);
            buttonMethodDelete.ForeColor = Color.Black;
            buttonMethodDelete.Location = new Point(143, 267);
            buttonMethodDelete.Name = "buttonMethodDelete";
            buttonMethodDelete.Size = new Size(128, 29);
            buttonMethodDelete.TabIndex = 8;
            buttonMethodDelete.Text = "Delete";
            buttonMethodDelete.UseVisualStyleBackColor = true;
            buttonMethodDelete.Click += buttonMethodDelete_Click;
            // 
            // listBoxMethods
            // 
            listBoxMethods.BackColor = Color.WhiteSmoke;
            listBoxMethods.Font = new Font("Segoe UI", 9F);
            listBoxMethods.FormattingEnabled = true;
            listBoxMethods.HorizontalScrollbar = true;
            listBoxMethods.ItemHeight = 15;
            listBoxMethods.Location = new Point(6, 29);
            listBoxMethods.Name = "listBoxMethods";
            listBoxMethods.Size = new Size(387, 229);
            listBoxMethods.TabIndex = 7;
            // 
            // buttonFormOK
            // 
            buttonFormOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonFormOK.Location = new Point(660, 625);
            buttonFormOK.Name = "buttonFormOK";
            buttonFormOK.Size = new Size(161, 40);
            buttonFormOK.TabIndex = 13;
            buttonFormOK.Text = "OK";
            buttonFormOK.UseVisualStyleBackColor = true;
            buttonFormOK.Click += buttonFormOK_Click;
            // 
            // buttonFormCancel
            // 
            buttonFormCancel.Location = new Point(827, 625);
            buttonFormCancel.Name = "buttonFormCancel";
            buttonFormCancel.Size = new Size(161, 40);
            buttonFormCancel.TabIndex = 14;
            buttonFormCancel.Text = "Cancel";
            buttonFormCancel.UseVisualStyleBackColor = true;
            buttonFormCancel.Click += buttonFormCancel_Click;
            // 
            // buttonFormDeleteCell
            // 
            buttonFormDeleteCell.BackColor = Color.Transparent;
            buttonFormDeleteCell.Font = new Font("Segoe UI", 9F);
            buttonFormDeleteCell.Location = new Point(6, 625);
            buttonFormDeleteCell.Name = "buttonFormDeleteCell";
            buttonFormDeleteCell.Size = new Size(104, 40);
            buttonFormDeleteCell.TabIndex = 15;
            buttonFormDeleteCell.Text = "DELETE CELL";
            buttonFormDeleteCell.UseVisualStyleBackColor = false;
            buttonFormDeleteCell.Click += buttonFormDeleteCell_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(12, 73);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 25);
            checkBox1.TabIndex = 16;
            checkBox1.Text = "Interface";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // buttonImportFromInterface
            // 
            buttonImportFromInterface.Location = new Point(280, 79);
            buttonImportFromInterface.Name = "buttonImportFromInterface";
            buttonImportFromInterface.Size = new Size(75, 23);
            buttonImportFromInterface.TabIndex = 17;
            buttonImportFromInterface.Text = "Import";
            buttonImportFromInterface.UseVisualStyleBackColor = true;
            buttonImportFromInterface.Click += buttonImportFromInterface_Click;
            // 
            // comboBoxInterfaceToImport
            // 
            comboBoxInterfaceToImport.FormattingEnabled = true;
            comboBoxInterfaceToImport.Location = new Point(361, 80);
            comboBoxInterfaceToImport.Name = "comboBoxInterfaceToImport";
            comboBoxInterfaceToImport.Size = new Size(254, 23);
            comboBoxInterfaceToImport.TabIndex = 18;
            // 
            // FormEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1000, 671);
            Controls.Add(comboBoxInterfaceToImport);
            Controls.Add(buttonImportFromInterface);
            Controls.Add(checkBox1);
            Controls.Add(buttonFormDeleteCell);
            Controls.Add(buttonFormCancel);
            Controls.Add(buttonFormOK);
            Controls.Add(groupBox5);
            Controls.Add(groupBoxMethod);
            Controls.Add(groupBox3);
            Controls.Add(groupBoxAttribute);
            Controls.Add(groupBox1);
            Name = "FormEditor";
            Text = "Editor";
            Load += FormEditor_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxAttribute.ResumeLayout(false);
            groupBoxAttribute.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBoxMethod.ResumeLayout(false);
            groupBoxMethod.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxClassName;
        private TextBox textBoxAttributeName;
        private ComboBox comboBoxAttributeAccessModifier;
        private GroupBox groupBox1;
        private GroupBox groupBoxAttribute;
        private Button buttonAttributeClear;
        private Button buttonAttributeSave;
        private ListBox listBoxAttributes;
        private GroupBox groupBox3;
        private Button buttonAttributeDelete;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button buttonAttributeEdit;
        private GroupBox groupBoxMethod;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonMethodClear;
        private ComboBox comboBoxMethodAccessModifier;
        private TextBox textBoxMethodName;
        private GroupBox groupBox5;
        private Button buttonMethodEdit;
        private Button buttonMethodDelete;
        private ListBox listBoxMethods;
        private Label label7;
        private ListBox listBoxMethodInputs;
        private Button buttonMethodInputEdit;
        private TextBox textBoxAttributeDataType;
        private TextBox textBoxMethodOutput;
        private Button buttonAttributeAdd;
        private Button buttonMethodAdd;
        private Button buttonMethodSave;
        private Button buttonFormOK;
        private Button buttonFormCancel;
        private Button buttonFormDeleteCell;
        private CheckBox checkBox1;
        private Button buttonImportFromInterface;
        private ComboBox comboBoxInterfaceToImport;
    }
}