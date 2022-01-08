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
        private List<Point> points;
        private string xTitle, yTitle;
        private double[,] distances;
        private Random rnd = new Random();


        private List<List<double>> md_points; 

        public ApllyAlg_Grp2(List<string> x1, List<string> x2, string x_title, string y_title, decimal nr_cluster) 
        {
            this.nr_cluster = nr_cluster;           
            this.xTitle = x_title;
            this.yTitle = y_title;
            points = new List<Point>(); 
            for (int i = 0; i < x1.Count; i++)
            {
                Point point = new Point() { 
                    X = Convert.ToDouble(x1[i].Trim()), 
                    Y = Convert.ToDouble(x2[i].Trim())
                };

                points.Add(point);
            }
            distances = DistanceMatrix(points);
            

            InitializeComponent();
        }

        public ApllyAlg_Grp2(List<List<string>> data, decimal value)
        {
            this.md_points = new List<List<double>>(); 
            this.nr_cluster = value;

            for (int i = 0; i < data.Count; i++)
            {
                List<double> attrList = new List<double>();
                foreach (string item in data[i])
                {
                    attrList.Add(Convert.ToDouble(item.Trim()));
                }

                md_points.Add(attrList);
            }

            distances = DistanceMatrix(md_points);
        }

        

        private void ApllyAlg_Grp2_Load(object sender, EventArgs e)
        {           
            Series series = new Series("Unlabeled Data");
            foreach (Point item in points)
            {
                series.Points.AddXY(item.X, item.Y);
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

        private double SD(Point p1, Point p2) {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }

        private double SD(List<double> p1, List<double> p2)
        {
            double sum = 0.0; 
            for (int i = 0; i < p1.Count; i++)
            {
                double ax1 = p1[i];
                double ax2 = p2[i];

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
            Cluster.showInfoClusters(clusters);

            showClustersOnChart(clusters);
        }

        private void showClustersOnChart(List<Cluster> clusters) {
            chart1.Series.Clear(); 

            foreach (Cluster cluster in clusters)
            {
                Series s = new Series(cluster.ToString());
                Color randomColor = CreateRandomColor();
                foreach (Point item in cluster.C)
                {
                    s.Points.AddXY(item.X, item.Y);
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


        private double[,] DistanceMatrix(List<List<double>> dts)
        {
            double[,] distances = new double[dts[0].Count, dts[0].Count];
            // row
            for (int i = 0; i < dts[0].Count; i++)
            {
                // columns 
                List<double> from = new List<double>(); //points[i];
                for (int k = 0; k < dts.Count; k++)
                {
                    from.Add(dts[k][i]);
                }


                for (int j = 0; j < dts[0].Count; j++)
                {
                    List<double> to = new List<double>(); //points[i];
                    for (int k = 0; k < dts.Count; k++)
                    {
                        to.Add(dts[k][j]);
                    }
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

        private class Point {

            private int Id { get; set; }
            public double X { get; set; }
            public double Y { get; set; }

            public Point()
            {
                Id = id_counter;
                id_counter++; 
            }

            private static int id_counter = 0; 

            public override string ToString()
            {
                return "point-" + Id;
            }
        }

        private class Cluster {
            private int Id;
            private static int Id_counter = 0; 
            public List<Point> C { get; set; }

            public Cluster()
            {
                Id = Id_counter;
                Id_counter++;

                C = new List<Point>();                 
            }

            public void Add(Point point) {
                C.Add(point);
            }

            public bool Remove(Point p) {
                return C.Remove(p);
            }

            public Cluster belongWhich(Point p) {
                foreach (Point item in C)
                {
                    if (p.Equals(item)) {
                        return this; 
                    }
                }

                return null;
            }

            public int size() {
                return C.Count; 
            }

            public void transferPointsToAnotherCluster(Cluster to)
            {
                foreach (Point item in C)
                {
                    to.Add(item);
                }

                C = null;
            }

            public override string ToString()
            {
                return "cluster-" + this.Id; 
            }

            public static void showInfoClusters(List<Cluster> clusters) {
                foreach (Cluster item in clusters)
                {
                    Debug.WriteLine(item.ToString());
                    foreach (Point point in item.C)
                    {
                        Debug.WriteLine("-" + point.ToString());
                    }
                }
            }
        }

        private Color CreateRandomColor()
        {
            Color randomColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

            return randomColor;
        }
    }
}
