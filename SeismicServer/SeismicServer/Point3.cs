using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismicServer
{
    class Point3
    {
        private double _x;
        private double _y;
        private double _z;
        public double X { get { return _x;} set { _x = value; }}
        public double Y { get { return _y;} set { _y = value; }}
        public double Z { get { return _z;} set { _z = value; }}
        public Point3 (double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
    }
}
