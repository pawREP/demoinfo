using System;
using EHVAG.DemoInfo.Utils;

namespace EHVAG.DemoInfo.ValveStructs
{
    /// <summary>
    /// And Source-Engine Vector. 
    /// </summary>
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public double Angle2D
        {
            get
            {
                return Math.Atan2(this.Y, this.X); 
            }
        }

        public double Absolute
        {
            get
            {
                return Math.Sqrt(AbsoluteSquared); 
            }
        }

        public double AbsoluteSquared
        {
            get 
            {
                return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
            }
        }

        internal static Vector Parse(IBitStream reader)
        {
            return new Vector
            {
                X = reader.ReadFloat(),
                Y = reader.ReadFloat(),
                Z = reader.ReadFloat(),
            };
        }

        public Vector()
        {

        }

        public Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Copy this instance. So if you want to permanently store the position of a player at a point in time, 
        /// COPY it. 
        /// </summary>
        public Vector Copy()
        {
            return new Vector(X,Y,Z);
        }

        public static Vector operator + (Vector a, Vector b)
        {
            return new Vector() {X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }

        public static Vector operator - (Vector a, Vector b)
        {
            return new Vector() {X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }

        public override string ToString()
        {
            return "{X: " + X + ", Y: " + Y + ", Z: " + Z + " }";
        }
    }
}

