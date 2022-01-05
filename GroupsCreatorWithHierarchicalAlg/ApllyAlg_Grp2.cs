﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private List<Point> points;
        private string xTitle, yTitle; 
        public ApllyAlg_Grp2(List<string> x1, List<string> x2, string x_title, string y_title)
        {
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
            InitializeComponent();
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
            
            int i = n + 1;
            while (clusters.Count > 1)
            {
                // 
            }
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
                    distances[i, j] = (j >= i) ? double.MaxValue : SD(from, to);                    
                }
            }

             
            return distances;
        }

        private (double, Point, Point, double[,]) findMinimum(double[,] distances, List<Point> points) {
            double[,] distancesCopy = distances.Clone() as double[,]; 
            double minValue = double.MaxValue;
            int minFirstIndex = int.MinValue;
            int minSecondIndex = int.MinValue;

            for (int i = 0; i < distancesCopy.Length; i++)
            {
                for (int j = 0; j < distancesCopy.Length; j++)
                {
                    if (i < j) { // abowe diagonal  
                        double value = distancesCopy[i, j];
                        if (value <= minValue) {
                            minValue = value;
                            minFirstIndex = i;
                            minSecondIndex = j;

                            distancesCopy[i, j] = double.MaxValue;
                        }
                    }
                }
            }

            return (minValue, points[minFirstIndex], points[minSecondIndex], distancesCopy);
        }

        private class Point {
            public double X { get; set; }
            public double Y { get; set; }
        }

        private class Cluster {
            private List<Point> C { get; set; }

            public Cluster()
            {
                C = new List<Point>(); 
            }

            public void Add(Point point) {
                C.Add(point);
            }

            public bool Remove(Point p) {
                return C.Remove(p);
            }
        }
    }
}
