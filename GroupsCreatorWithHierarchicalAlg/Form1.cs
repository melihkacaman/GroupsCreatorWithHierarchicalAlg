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
        int ctrl = 0;
        List<ComboBox> comboBoxes = new List<ComboBox>(); 
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
            foreach (var item in groupBox1.Controls)
            {
                if (item is ComboBox) {
                    ((ComboBox)item).DataSource = null;
                }
            }         
        }

        private void btn_grp2_apply_Click(object sender, EventArgs e)
        {
            if (dataGrid.DataSource != null )
            {
                if (nmr_grp2.Value > 1)
                {
                    if (checkItemsCombo())
                    {
                        // do your job 
                        List<List<string>> data = new List<List<string>>(); 
                        
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

                        data.Add(Xx);
                        data.Add(Yy);

                        if (comboBoxes.Count > 0) {
                            foreach (ComboBox item in comboBoxes)
                            {
                                List<string> atr = new List<string>();

                                for (int i = 0; i < dataGrid.Rows.Count; i++)
                                {
                                    if (dataGrid.Rows[i].Cells[cmb_grp2_X.SelectedIndex].Value != null)
                                    {
                                        atr.Add(dataGrid.Rows[i].Cells[item.SelectedIndex].Value.ToString());                                        
                                    }                                    
                                }

                                data.Add(atr);
                            }
                        }
                        ApllyAlg_Grp2 apllyAlg_ = null; 
                        if (comboBoxes.Count == 0)
                        {
                            apllyAlg_ = new
                                ApllyAlg_Grp2(Xx, Yy, cmb_grp2_X.SelectedItem.ToString(), 
                                cmb_grp2_Y.SelectedItem.ToString(), nmr_grp2.Value, 
                                radio_weightDistance.Checked == true ? false : true);                           
                        }
                        else {
                             apllyAlg_ = new ApllyAlg_Grp2(data, nmr_grp2.Value, radio_weightDistance.Checked == true ? false : true);                            
                        }
                        
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

        private bool checkItemsCombo() {
            List<int> cbs = new List<int>(); 
            foreach (var item in groupBox1.Controls)
            {
                if (item is ComboBox)
                    cbs.Add(((ComboBox)item).SelectedIndex); 
            }

            return cbs.Distinct().ToList().Count == cbs.Count;
        }


        private void btn_addAttribute_Click(object sender, EventArgs e)
        {
            if (dataGrid.DataSource != null) {
                int i = 0;
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is System.Windows.Forms.ComboBox)
                    {
                        i++;
                    }
                }

                if (CSVHelper.columnsName.Count > i) {
                    ComboBox comboBox = new ComboBox();
                    comboBox.DataSource = CSVHelper.columnsName.ToArray();

                    comboBox.SetBounds(6, 195 + ctrl, 120, 24);
                        
                    groupBox1.Controls.Add(comboBox);
                    
                    ctrl += 30;

                    comboBoxes.Add(comboBox); 
                }

            }
        }
    }
}
