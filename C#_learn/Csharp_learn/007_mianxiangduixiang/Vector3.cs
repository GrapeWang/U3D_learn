using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_mianxiangduixiang
{
    class Vector3
    {
        private double x;
        private double y;
        private double z;

        public void getX(double x)
        {
            this.x = x;
        }
        public void getY(double y)
        {
            this.y = y;
        }
        public void getZ(double z)
        {
            this.z = z;
        }

        public double Length()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public Vector3()
        {
            Console.WriteLine("diao");
        }

        //public int Myint
        //{
        //    set { value}
        //    get { return }
        //}
    }
}
