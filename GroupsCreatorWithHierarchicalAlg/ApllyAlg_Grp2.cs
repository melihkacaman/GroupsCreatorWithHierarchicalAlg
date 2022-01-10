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
using System.Windows.Forms.DataVisualization.Charting;

namespace GroupsCreatorWithHierarchicalAlg
{
    public partial class ApllyAlg_Grp2 : Form
    {
        private decimal nr_cluster;
        private List<Point> points = new List<Point>(); 
        private string xTitle, yTitle;
        private double[,] distances;
        private Random rnd = new Random();
        private bool md_control = false; 

        public ApllyAlg_Grp2(List<string> x1, List<string> x2, string x_title, string y_title, decimal nr_cluster) 
        {
            this.nr_cluster = nr_cluster;           
            this.xTitle = x_title;
            this.yTitle = y_title;
            for (int i = 0; i < x1.Count; i++)
            {
                Point point = new Point(2);
                point.add(Convert.ToDouble(x1[i].Trim()));
                point.add(Convert.ToDouble(x2[i].Trim()));
                                  
                points.Add(point);
            }
            distances = DistanceMatrix(points);
            

            InitializeComponent();
        }

        public ApllyAlg_Grp2(List<List<string>> data, decimal nr_cluster)
        {
            this.nr_cluster = nr_cluster;
            this.md_control = true;
            for (int i = 0; i < data[0].Count; i++)
            {
                Point point = new Point(data.Count); 
                for (int j = 0; j < data.Count; j++)
                {
                    point.add(Convert.ToDouble(data[j][i])); 
                }

                points.Add(point);
            }

            distances = DistanceMatrix(points);

            InitializeComponent();
        }

        

        private void ApllyAlg_Grp2_Load(object sender, EventArgs e)
        {
            if (md_control == false) {
                Series series = new Series("Unlabeled Data");
                foreach (Point item in points)
                {
                    series.Points.AddXY(item.giveValue(0), item.giveValue(1));
                }
                series.ChartType = SeriesChartType.Point;
                series.MarkerStyle = MarkerStyle.Circle;


                chart1.Series.Clear();
                chart1.Series.Add(series);
                chart1.ResetAutoValues();
                chart1.Titles.Clear();
                chart1.Titles.Add($"Scatter Plot");
                chart1.ChartAreas[0].AxisX.Title = "X";
                chart1.ChartAreas[0].AxisY.Title = "Y";
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            }
        }

        private double SD(Point p1, Point p2) {
            double sum = 0.0;
            for (int i = 0; i < p1.getDimension(); i++)
            {
                double ax1 = p1.giveValue(i);
                double ax2 = p2.giveValue(i);

                sum += Math.Pow(ax1 - ax2, 2);
            }

            return Math.Sqrt(sum);
        }        

        private void apply_alg_Click(object sender, EventArgs e)
        {
            List<Point> A = points.ToList(); // set of X's 
            List<Cluster> clusters = new List<Cluster>();
            int n = A.Count;
            for (int k = 0; k < A.Count; k++)
            {
                Cluster cluster = new Cluster();
                cluster.Add(A[k]);
                clusters.Add(cluster);               
            }
            
            
            while (clusters.Count > nr_cluster)
            {                
                double dist = double.MaxValue;
                int to_index =-1 ;
                int from_index = -1;
                
                (dist, to_index, from_index) = findMinimum(distances);

                Cluster cluster_to = null;
                Cluster cluster_from = null; 

                foreach (Cluster item in clusters)
                {
                    if (item.belongWhich(points[to_index]) != null) {
                        cluster_to = item; 
                    }

                    if (item.belongWhich(points[from_index]) != null) {
                        cluster_from = item; 
                    }

                    if (cluster_to != null && cluster_from != null) {
                        break;
                    }
                }

                if (cluster_from.Equals(cluster_to)) {
                    int row_idx = points.IndexOf(points[to_index]);
                    int column_idx = points.IndexOf(points[from_index]);
                                         
                    continue;
                }

                if (cluster_to.size() > cluster_from.size())
                {
                    // cluster_to is bigger than cluster_from. 
                    cluster_from.transferPointsToAnotherCluster(cluster_to);
                    clusters.Remove(cluster_from);
                }
                else {
                    // cluster_from is bigger than cluster_to. 
                    cluster_to.transferPointsToAnotherCluster(cluster_from);
                    clusters.Remove(cluster_to); 
                }                
            }
            

            if (md_control == false)
                showClustersOnChart(clusters);
            else {
                Series s = new Series();
                foreach (Cluster item in clusters)
                {
                    s.Points.AddXY(item.ToString(), item.size().ToString()); 
                }
                s.ChartType = SeriesChartType.Bar;
                chart1.Series.Clear();
                chart1.Series.Add(s);
                chart1.ResetAutoValues();
                //chart1.Titles.Clear();
                //chart1.Titles.Add($"Scatter Plot");
                //chart1.ChartAreas[0].AxisX.Title = "X";
                //chart1.ChartAreas[0].AxisY.Title = "Y";
                //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                //chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            }
        }

        private void showClustersOnChart(List<Cluster> clusters) {
            chart1.Series.Clear(); 

            foreach (Cluster cluster in clusters)
            {
                Series s = new Series(cluster.ToString());
                Color randomColor = CreateRandomColor();
                foreach (Point item in cluster.C)
                {
                    s.Points.AddXY(item.giveValue(0), item.giveValue(1));
                }

                s.ChartType = SeriesChartType.Point;
                s.MarkerStyle = MarkerStyle.Circle;
                s.Color = randomColor;

                chart1.Series.Add(s);
            }
                              
            chart1.ResetAutoValues();
            chart1.Titles.Clear();
            chart1.Titles.Add($"Scatter Plot");
            chart1.ChartAreas[0].AxisX.Title = "X";
            chart1.ChartAreas[0].AxisY.Title = "Y";
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        }

        private double[,] DistanceMatrix(List<Point> points) {
            double[,] distances = new double[points.Count, points.Count];
            // row
            for (int i = 0; i < points.Count; i++)
            {
                // columns 
                Point from = points[i]; 
                for (int j = 0; j < points.Count; j++)
                {                    
                    Point to = points[j];
                    distances[i, j] = (j >= i) ? double.MaxValue : SD(from, to);    // i < j                 
                }
            }

             
            return distances;
        }


        private (double, int, int) findMinimum(double[,] distances) {            
            double minValue = double.MaxValue;
            int minFirstIndex = int.MinValue;
            int minSecondIndex = int.MinValue;

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (j >= i) {
                        continue;
                    }
                    else { // abowe diagonal  
                        double value = distances[i, j];
                        if (value <= minValue) {
                            minValue = value;
                            minFirstIndex = i;
                            minSecondIndex = j;                            
                        }
                    }
                }
            }

            distances[minFirstIndex, minSecondIndex] = double.MaxValue; 
            return (minValue, minFirstIndex, minSecondIndex);
        }

         

         

        private Color CreateRandomColor()
        {
            Color randomColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            return randomColor;
        }
    }
}
