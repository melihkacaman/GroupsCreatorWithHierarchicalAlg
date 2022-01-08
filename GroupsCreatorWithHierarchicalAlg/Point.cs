using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupsCreatorWithHierarchicalAlg
{
    public class Point
    {
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
}
