using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupsCreatorWithHierarchicalAlg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_importFile_Click(object sender, EventArgs e)
        {
            if (dataGrid.DataSource != null)
                resetAllComponents(); 

            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "C:";
            file.Filter = "CSV File |*.csv";

            string filePathRes = "";

            if (file.ShowDialog() == DialogResult.OK)
            {
                filePathRes = file.FileName;

                var result = CSVHelper.readCSV(filePathRes, ',', true);

                result.Rows.RemoveAt(result.Rows.Count - 1);
                dataGrid.DataSource = result;
                cmb_grp2_X.DataSource = CSVHelper.columnsName;
                cmb_grp2_Y.DataSource = CSVHelper.columnsName.ToArray(); 
            }
        }


        private void resetAllComponents() {
            dataGrid.DataSource = null;
            cmb_grp2_X.DataSource = null;
            cmb_grp2_Y.DataSource = null;         
        }

        private void btn_grp2_apply_Click(object sender, EventArgs e)
        {

        }
    }
}
