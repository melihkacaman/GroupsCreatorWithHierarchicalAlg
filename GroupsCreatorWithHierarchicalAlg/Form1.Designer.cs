
namespace GroupsCreatorWithHierarchicalAlg
{
    partial class Form1
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
            this.panel_right = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nmr_grp2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_grp2_apply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_grp2_Y = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_grp2_X = new System.Windows.Forms.ComboBox();
            this.btn_importFile = new System.Windows.Forms.Button();
            this.panel_left = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btn_addAttribute = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_right.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_grp2)).BeginInit();
            this.panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_right
            // 
            this.panel_right.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel_right.Controls.Add(this.groupBox1);
            this.panel_right.Controls.Add(this.btn_importFile);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(924, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Padding = new System.Windows.Forms.Padding(10);
            this.panel_right.Size = new System.Drawing.Size(209, 722);
            this.panel_right.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_addAttribute);
            this.groupBox1.Controls.Add(this.nmr_grp2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_grp2_apply);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_grp2_Y);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_grp2_X);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 584);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grouping Objects";
            // 
            // nmr_grp2
            // 
            this.nmr_grp2.Location = new System.Drawing.Point(128, 487);
            this.nmr_grp2.Name = "nmr_grp2";
            this.nmr_grp2.Size = new System.Drawing.Size(43, 22);
            this.nmr_grp2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nr. of Groups :";
            // 
            // btn_grp2_apply
            // 
            this.btn_grp2_apply.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_grp2_apply.Location = new System.Drawing.Point(19, 528);
            this.btn_grp2_apply.Name = "btn_grp2_apply";
            this.btn_grp2_apply.Size = new System.Drawing.Size(152, 39);
            this.btn_grp2_apply.TabIndex = 4;
            this.btn_grp2_apply.Text = "Apply ";
            this.btn_grp2_apply.UseVisualStyleBackColor = false;
            this.btn_grp2_apply.Click += new System.EventHandler(this.btn_grp2_apply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y :";
            // 
            // cmb_grp2_Y
            // 
            this.cmb_grp2_Y.FormattingEnabled = true;
            this.cmb_grp2_Y.Location = new System.Drawing.Point(50, 79);
            this.cmb_grp2_Y.Name = "cmb_grp2_Y";
            this.cmb_grp2_Y.Size = new System.Drawing.Size(121, 24);
            this.cmb_grp2_Y.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "X :";
            // 
            // cmb_grp2_X
            // 
            this.cmb_grp2_X.FormattingEnabled = true;
            this.cmb_grp2_X.Location = new System.Drawing.Point(50, 39);
            this.cmb_grp2_X.Name = "cmb_grp2_X";
            this.cmb_grp2_X.Size = new System.Drawing.Size(121, 24);
            this.cmb_grp2_X.TabIndex = 0;
            // 
            // btn_importFile
            // 
            this.btn_importFile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_importFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_importFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_importFile.Location = new System.Drawing.Point(10, 10);
            this.btn_importFile.Margin = new System.Windows.Forms.Padding(30);
            this.btn_importFile.Name = "btn_importFile";
            this.btn_importFile.Size = new System.Drawing.Size(189, 37);
            this.btn_importFile.TabIndex = 0;
            this.btn_importFile.Text = "Import File";
            this.btn_importFile.UseVisualStyleBackColor = false;
            this.btn_importFile.Click += new System.EventHandler(this.btn_importFile_Click);
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.dataGrid);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_left.Location = new System.Drawing.Point(0, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(924, 722);
            this.panel_left.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.Size = new System.Drawing.Size(924, 722);
            this.dataGrid.TabIndex = 0;
            // 
            // btn_addAttribute
            // 
            this.btn_addAttribute.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_addAttribute.Location = new System.Drawing.Point(19, 121);
            this.btn_addAttribute.Name = "btn_addAttribute";
            this.btn_addAttribute.Size = new System.Drawing.Size(152, 34);
            this.btn_addAttribute.TabIndex = 7;
            this.btn_addAttribute.Text = "Add Attribute";
            this.btn_addAttribute.UseVisualStyleBackColor = false;
            this.btn_addAttribute.Click += new System.EventHandler(this.btn_addAttribute_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 81);
            this.label4.TabIndex = 8;
            this.label4.Text = "If you group more than two attribute, yo\'re gonna use the abbility of visualizati" +
    "on. ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 722);
            this.Controls.Add(this.panel_left);
            this.Controls.Add(this.panel_right);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_right.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_grp2)).EndInit();
            this.panel_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_importFile;
        private System.Windows.Forms.ComboBox cmb_grp2_X;
        private System.Windows.Forms.Button btn_grp2_apply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_grp2_Y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmr_grp2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_addAttribute;
    }
}

