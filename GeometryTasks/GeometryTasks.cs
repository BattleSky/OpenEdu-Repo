using System;

namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector vector)
        {
            return Geometry.Add(this, vector);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
            
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }

    }

    public class Geometry
    {

        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            var result = new Vector();
            result.X = vector1.X + vector2.X;
            result.Y = vector1.Y + vector2.Y;
            return result;
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(
                Math.Pow((segment.End.X - segment.Begin.X), 2) +
                Math.Pow((segment.End.Y - segment.Begin.Y), 2)
            );
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            var pointToSegmentBegin = new Vector
            {
                X = segment.Begin.X - vector.X,
                Y = segment.Begin.Y - vector.Y
            };
            var pointToSegmentEnd = new Vector
            {
                X = segment.End.X - vector.X,
                Y = segment.End.Y - vector.Y
            };

            return Math.Abs(GetLength(pointToSegmentBegin) +
                GetLength(pointToSegmentEnd) - GetLength(segment)) < 1e-6;


        }

    }
}


