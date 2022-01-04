using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupsCreatorWithHierarchicalAlg
{
    public partial class ApllyAlg_Grp2 : Form
    {
        public ApllyAlg_Grp2(List<string> x1, List<string> x2)
        {
            InitializeComponent();
        }

        private void ApllyAlg_Grp2_Load(object sender, EventArgs e)
        {

        }

        private float SD(Point p1, Point p2) {
            return (float)Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }

        private class Point {
            public float X { get; set; }
            public float Y { get; set; }
        }
    }
}
