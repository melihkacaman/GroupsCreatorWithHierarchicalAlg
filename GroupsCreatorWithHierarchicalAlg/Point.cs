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
        private double[] components;
        private int dimension = -1;

        private int counter_dimension = 0; 

        public Point(int dimension)
        {
            components = new double[dimension]; 
            Id = id_counter;
            id_counter++;

            this.dimension = dimension;
        }

        public double giveValue(int position) {
            return components[position];
        }

        public void add(double data) {
            if (counter_dimension < dimension) {
                components[counter_dimension] = data;
                counter_dimension++;
            }
        }

        public int getDimension() {
            return dimension;
        }

        private static int id_counter = 0;

        public override string ToString()
        {
            return "point-" + Id;
        }
    }
}
