namespace UMLEditor
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            buttonAddCell = new Button();
            comboBoxArrowStyle = new ComboBox();
            comboBoxLineStyle = new ComboBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            buttonExport = new Button();
            buttonImport = new Button();
            label3 = new Label();
            buttonExportImage = new Button();
            buttonExportCode = new Button();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(240, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 620);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDoubleClick += pictureBox1_MouseDoubleClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // buttonAddCell
            // 
            buttonAddCell.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCell.FlatAppearance.BorderColor = Color.Black;
            buttonAddCell.FlatAppearance.BorderSize = 2;
            buttonAddCell.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonAddCell.ForeColor = SystemColors.ControlText;
            buttonAddCell.Location = new Point(12, 594);
            buttonAddCell.Name = "buttonAddCell";
            buttonAddCell.Size = new Size(222, 75);
            buttonAddCell.TabIndex = 1;
            buttonAddCell.Text = "Add Cell";
            buttonAddCell.UseVisualStyleBackColor = true;
            buttonAddCell.Click += buttonAddCell_Click;
            // 
            // comboBoxArrowStyle
            // 
            comboBoxArrowStyle.FormattingEnabled = true;
            comboBoxArrowStyle.Location = new Point(6, 107);
            comboBoxArrowStyle.Name = "comboBoxArrowStyle";
            comboBoxArrowStyle.Size = new Size(210, 29);
            comboBoxArrowStyle.TabIndex = 2;
            // 
            // comboBoxLineStyle
            // 
            comboBoxLineStyle.FormattingEnabled = true;
            comboBoxLineStyle.Location = new Point(6, 49);
            comboBoxLineStyle.Name = "comboBoxLineStyle";
            comboBoxLineStyle.Size = new Size(210, 29);
            comboBoxLineStyle.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBoxLineStyle);
            groupBox1.Controls.Add(comboBoxArrowStyle);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(1046, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(227, 153);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Arrow";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(6, 83);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 5;
            label2.Text = "Arrow style";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 4;
            label1.Text = "Line style";
            // 
            // buttonExport
            // 
            buttonExport.ForeColor = Color.Black;
            buttonExport.Location = new Point(6, 59);
            buttonExport.Margin = new Padding(3, 2, 3, 2);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(210, 34);
            buttonExport.TabIndex = 6;
            buttonExport.Text = "Save as";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonImport
            // 
            buttonImport.ForeColor = Color.Black;
            buttonImport.Location = new Point(6, 21);
            buttonImport.Margin = new Padding(3, 2, 3, 2);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(210, 34);
            buttonImport.TabIndex = 7;
            buttonImport.Text = "Open";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(1052, 206);
            label3.Name = "label3";
            label3.Size = new Size(218, 42);
            label3.TabIndex = 8;
            label3.Text = "Reconnect the same arrow 2x \r\nto remove it.";
            label3.Click += label3_Click;
            // 
            // buttonExportImage
            // 
            buttonExportImage.ForeColor = Color.Black;
            buttonExportImage.Location = new Point(6, 59);
            buttonExportImage.Margin = new Padding(3, 2, 3, 2);
            buttonExportImage.Name = "buttonExportImage";
            buttonExportImage.Size = new Size(210, 34);
            buttonExportImage.TabIndex = 9;
            buttonExportImage.Text = "Export as .png";
            buttonExportImage.UseVisualStyleBackColor = true;
            buttonExportImage.Click += buttonExportImage_Click;
            // 
            // buttonExportCode
            // 
            buttonExportCode.ForeColor = Color.Black;
            buttonExportCode.Location = new Point(6, 21);
            buttonExportCode.Margin = new Padding(3, 2, 3, 2);
            buttonExportCode.Name = "buttonExportCode";
            buttonExportCode.Size = new Size(210, 34);
            buttonExportCode.TabIndex = 10;
            buttonExportCode.Text = "Export to code";
            buttonExportCode.UseVisualStyleBackColor = true;
            buttonExportCode.Click += buttonExportCode_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonImport);
            groupBox2.Controls.Add(buttonExport);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(6, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(222, 100);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "File";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonExportCode);
            groupBox3.Controls.Add(buttonExportImage);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(6, 118);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(222, 100);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Export diagram";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1285, 681);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(buttonAddCell);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            MinimumSize = new Size(1280, 718);
            Name = "FormMain";
            Text = "UML Editor";
            Resize += FormMain_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button buttonAddCell;
        private ComboBox comboBoxArrowStyle;
        private ComboBox comboBoxLineStyle;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Button buttonExport;
        private Button buttonImport;
        private Label label3;
        private Button buttonExportImage;
        private Button buttonExportCode;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}
