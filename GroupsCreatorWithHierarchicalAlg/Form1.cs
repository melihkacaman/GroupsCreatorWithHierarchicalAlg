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
            if (dataGrid.DataSource != null )
            {
                if (nmr_grp2.Value > 1)
                {
                    if (cmb_grp2_X.SelectedIndex != cmb_grp2_Y.SelectedIndex)
                    {
                        // do your job 
                        List<string> Xx = new List<string>();
                        List<string> Yy = new List<string>();


                        for (int i = 0; i < dataGrid.Rows.Count; i++)
                        {
                            if (dataGrid.Rows[i].Cells[cmb_grp2_X.SelectedIndex].Value != null)
                            {
                                Xx.Add(dataGrid.Rows[i].Cells[cmb_grp2_X.SelectedIndex].Value.ToString());
                                Yy.Add(dataGrid.Rows[i].Cells[cmb_grp2_Y.SelectedIndex].Value.ToString());
                            }

                        }

                        ApllyAlg_Grp2 apllyAlg_ = new 
                            ApllyAlg_Grp2(Xx, Yy, cmb_grp2_X.SelectedItem.ToString(), cmb_grp2_Y.SelectedItem.ToString(), nmr_grp2.Value);
                        apllyAlg_.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please, choose different columns for charting!");
                    }
                }
                else {
                    MessageBox.Show("Nr. Of clusters should be greater than 2. ");                
                }
            }
        }
    }
}
