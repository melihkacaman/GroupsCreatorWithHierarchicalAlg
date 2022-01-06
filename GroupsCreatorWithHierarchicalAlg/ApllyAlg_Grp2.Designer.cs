
namespace GroupsCreatorWithHierarchicalAlg
{
    partial class ApllyAlg_Grp2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.apply_alg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(994, 604);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // apply_alg
            // 
            this.apply_alg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.apply_alg.Location = new System.Drawing.Point(0, 610);
            this.apply_alg.Name = "apply_alg";
            this.apply_alg.Size = new System.Drawing.Size(994, 46);
            this.apply_alg.TabIndex = 1;
            this.apply_alg.Text = "Apply Algorithm";
            this.apply_alg.UseVisualStyleBackColor = true;
            this.apply_alg.Click += new System.EventHandler(this.apply_alg_Click);
            // 
            // ApllyAlg_Grp2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 656);
            this.Controls.Add(this.apply_alg);
            this.Controls.Add(this.chart1);
            this.Name = "ApllyAlg_Grp2";
            this.Text = "Applying Algorithm";
            this.Load += new System.EventHandler(this.ApllyAlg_Grp2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button apply_alg;
    }
}