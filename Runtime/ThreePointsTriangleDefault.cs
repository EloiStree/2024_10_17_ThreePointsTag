using System;
using UnityEngine;

namespace Eloi.ThreePoints
{

    
    [System.Serializable]
    public class ThreePointsTriangleDefault : I_ThreePointsDistanceAngleGet, I_ThreePointsSet
    {
        public STRUCT_ThreePointTriangle m_points;
        public STRUCT_ThreePointTriangleDistanceAndAngle m_distanceAndAngle;

        public ThreePointsTriangleDefault()
        {
            m_points = new STRUCT_ThreePointTriangle();
            m_distanceAndAngle = new STRUCT_ThreePointTriangleDistanceAndAngle();
            Clear();
        }
        public ThreePointsTriangleDefault(Vector3 start, Vector3 middle, Vector3 end)
        {
            m_points = new STRUCT_ThreePointTriangle();
            m_distanceAndAngle = new STRUCT_ThreePointTriangleDistanceAndAngle();
            SetThreePoints(start, middle, end);
        }
        public void ComputerFromOrigine()
        {
            m_distanceAndAngle.m_startMiddleDistance = Vector3.Distance(m_points.m_start, m_points.m_middle);
            m_distanceAndAngle.m_middleEndDistance = Vector3.Distance(m_points.m_middle, m_points.m_end);
            m_distanceAndAngle.m_startEndDistance = Vector3.Distance(m_points.m_start, m_points.m_end);

            m_distanceAndAngle.m_middlePointAngle = AngleBetween(m_points.m_start, m_points.m_middle, m_points.m_end);
            m_distanceAndAngle.m_endPointAngle = AngleBetween(m_points.m_start, m_points.m_end, m_points.m_middle);
            m_distanceAndAngle.m_startPointAngle = AngleBetween(m_points.m_middle, m_points.m_start, m_points.m_end);
        }

        private float AngleBetween(Vector3 start, Vector3 middle, Vector3 end)
        {
            Vector3 startToMiddle = middle - start;
            Vector3 endToMiddle = middle - end;

            float angle = Vector3.Angle(startToMiddle, endToMiddle);
            return angle;
        }

        public void GetPoints(out Vector3[] arrayOf3)
        {
            arrayOf3 = new Vector3[3];
            arrayOf3[0] = m_points.m_start;
            arrayOf3[1] = m_points.m_middle;
            arrayOf3[2] = m_points.m_end;
        }


        public void GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end)
        {
            start = m_points.m_start;
            middle = m_points.m_middle;
            end = m_points.m_end;
        }

        public void SetThreePoints(Vector3 start, Vector3 middle, Vector3 end)
        {
            m_points.m_start = start;
            m_points.m_middle = middle;
            m_points.m_end = end;
            ComputerFromOrigine();
        }

        public void SetThreePoints(I_ThreePointsGet triangle)
        {
            triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
            SetThreePoints(start, middle, end);
        }

        public void GetCornerAngle(ThreePointCorner corner, out float angle)
        {
            switch (corner)
            {
                case ThreePointCorner.Start:
                    angle = m_distanceAndAngle.m_startPointAngle;
                    break;
                case ThreePointCorner.Middle:
                    angle = m_distanceAndAngle.m_middlePointAngle;
                    break;
                case ThreePointCorner.End:
                    angle = m_distanceAndAngle.m_endPointAngle;
                    break;
                default:
                    angle = 0;
                    break;
            }
        }

        public void GetSegmentDistance(ThreePointSegment segment, out float distance)
        {
            switch (segment)
            {
                case ThreePointSegment.StartMiddle:
                    distance = m_distanceAndAngle.m_startMiddleDistance;
                    break;
                case ThreePointSegment.MiddleEnd:
                    distance = m_distanceAndAngle.m_middleEndDistance;
                    break;
                case ThreePointSegment.StartEnd:
                    distance = m_distanceAndAngle.m_startEndDistance;
                    break;
                default:
                    distance = 0;
                    break;
            }
        }

        public void GetPoint(ThreePointCorner corner, out Vector3 point)
        {
            switch (corner)
            {
                case ThreePointCorner.Start:
                    point = m_points.m_start;
                    break;
                case ThreePointCorner.Middle:
                    point = m_points.m_middle;
                    break;
                case ThreePointCorner.End:
                    point = m_points.m_end;
                    break;
                default:
                    point = Vector3.zero;
                    break;
            }
        }

        public void SetPoint(ThreePointCorner corner, Vector3 point)
        {
            switch (corner)
            {
                case ThreePointCorner.Start:
                    m_points.m_start = point;
                    break;
                case ThreePointCorner.Middle:
                    m_points.m_middle = point;
                    break;
                case ThreePointCorner.End:
                    m_points.m_end = point;
                    break;
                default:
                    break;


            }
        }

        public void GetCrossProductMiddle(out Vector3 crossProduct)
        {
            Vector3 startToMiddle = m_points.m_middle - m_points.m_start;
            Vector3 endToMiddle = m_points.m_middle - m_points.m_end;

            crossProduct = Vector3.Cross(startToMiddle, endToMiddle);
        }


        public void GetTrianglesBorderDistance(out float distance) {

            distance = m_distanceAndAngle.m_startEndDistance+ m_distanceAndAngle.m_startMiddleDistance + m_distanceAndAngle.m_middleEndDistance;
        }
        public void GetSquareBorderDistance(out float distance)
        {
            GetOrderDistance(out float biggest, out float middle, out float smallest);
            distance = middle* 2 + smallest * 2;
        }

        public void GetOrderDistance(out float biggest, out float middle, out float smallest)
        {
            float[] distances = new float[3] { m_distanceAndAngle.m_startEndDistance, m_distanceAndAngle.m_startMiddleDistance, m_distanceAndAngle.m_middleEndDistance };
            Array.Sort(distances);
            biggest = distances[2];
            middle = distances[1];
            smallest = distances[0];

        }
        public void GetOrderAngle(out float biggest, out float middle, out float smallest)
        {
            float[] angles = new float[3] { m_distanceAndAngle.m_startPointAngle, m_distanceAndAngle.m_middlePointAngle, m_distanceAndAngle.m_endPointAngle };
            Array.Sort(angles);
            biggest = angles[2];
            middle = angles[1];
            smallest = angles[0];
        }
        public void HasAngle(out bool hasAngle, float angle, float tolerence = 5f)
        {
            hasAngle = false;
            float[] angles = new float[3] { m_distanceAndAngle.m_startPointAngle, m_distanceAndAngle.m_middlePointAngle, m_distanceAndAngle.m_endPointAngle };
            for (int i = 0; i < angles.Length; i++)
            {
                if (Math.Abs(angles[i] - angle) < tolerence)
                {
                    hasAngle = true;
                    return;
                }
            }
        }
        public void HasRightAngle(out bool isRightAngle, float tolerence=5f)
        {
            HasAngle(out isRightAngle, 90, tolerence);
        }
        public void IsLine(out bool isLine, float tolerence = 5f)
        {
           
            HasAngle(out isLine, 0, tolerence);
        }
        public void IsEquilateral(out bool isIsocele, float tolerence = 5f)
        {
            bool isFirstAngleAround60= Mathf.Abs(60-m_distanceAndAngle.m_startPointAngle) < tolerence;
            bool isSecondAngleAround60 = Mathf.Abs(60 - m_distanceAndAngle.m_middlePointAngle) < tolerence;
            bool isThirdAngleAround60 = Mathf.Abs(60 - m_distanceAndAngle.m_endPointAngle) < tolerence;
            isIsocele = isFirstAngleAround60 && isSecondAngleAround60 && isThirdAngleAround60;

        }
       

        public void Clear()
        {
            SetThreePoints(Vector3.zero, Vector3.right * 0.0001f, Vector3.up * 0.0001f);
        }

        public void GetCentroid(out Vector3 centroid)
        {
            centroid = (m_points.m_start + m_points.m_middle + m_points.m_end) / 3;
        }

        public I_ThreePointsGet Copy()
        {
            ThreePointsTriangleDefault copy = new ThreePointsTriangleDefault();
            copy.SetThreePoints(m_points.m_start, m_points.m_middle, m_points.m_end);
            return copy;
        }

        public void GetAirSurface(out float airSurface)
        {
            airSurface= CalculateTriangleArea(m_distanceAndAngle.m_startEndDistance, m_distanceAndAngle.m_startMiddleDistance, m_distanceAndAngle.m_middleEndDistance);
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=6KPSmajeseI
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        float CalculateTriangleArea(float a, float b, float c)
        {
            //https://www.youtube.com/watch?v=6KPSmajeseI
            float s = (a + b + c) / 2; // Semi-perimeter
            return Mathf.Sqrt(s * (s - a) * (s - b) * (s - c)); // Heron's formula
        }
        public void GetBiggestAngle(out float biggestAngle)
        {
            GetOrderAngle(out float biggest, out float middle, out float smallest);
            biggestAngle = biggest;
        }
    }
}