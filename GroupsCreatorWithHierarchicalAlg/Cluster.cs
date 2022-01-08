﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsCreatorWithHierarchicalAlg
{
    public class Cluster
    {
        private int Id;
        private static int Id_counter = 0;
        public List<Point> C { get; set; }

        public Cluster()
        {
            Id = Id_counter;
            Id_counter++;

            C = new List<Point>();
        }

        public void Add(Point point)
        {
            C.Add(point);
        }

        public bool Remove(Point p)
        {
            return C.Remove(p);
        }

        public Cluster belongWhich(Point p)
        {
            foreach (Point item in C)
            {
                if (p.Equals(item))
                {
                    return this;
                }
            }

            return null;
        }

        public int size()
        {
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

        public static void showInfoClusters(List<Cluster> clusters)
        {
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
}
