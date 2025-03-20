using UnityEngine;

namespace Eloi.ThreePoints
{
    [System.Serializable]
    public class ThreePointsTriangleDefault : I_ThreePointsDistanceAngleGet, I_ThreePointsSet
    {
        public STRUCT_ThreePointTriangle m_triangle;
        public STRUCT_ThreePointTriangleDistanceAndAngle m_distanceAndAngle;
        public void ComputerFromOrigine()
        {
            m_distanceAndAngle.m_startMiddleDistance = Vector3.Distance(m_triangle.m_start, m_triangle.m_middle);
            m_distanceAndAngle.m_middleEndDistance = Vector3.Distance(m_triangle.m_middle, m_triangle.m_end);
            m_distanceAndAngle.m_startEndDistance = Vector3.Distance(m_triangle.m_start, m_triangle.m_end);

            m_distanceAndAngle.m_middlePointAngle = AngleBetween(m_triangle.m_start, m_triangle.m_middle, m_triangle.m_end);
            m_distanceAndAngle.m_endPointAngle = AngleBetween(m_triangle.m_start, m_triangle.m_end, m_triangle.m_middle);
            m_distanceAndAngle.m_startPointAngle = AngleBetween(m_triangle.m_middle, m_triangle.m_start, m_triangle.m_end);
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
            arrayOf3[0] = m_triangle.m_start;
            arrayOf3[1] = m_triangle.m_middle;
            arrayOf3[2] = m_triangle.m_end;
        }


        public void GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end)
        {
            start = m_triangle.m_start;
            middle = m_triangle.m_middle;
            end = m_triangle.m_end;
        }

        public void SetThreePoints(Vector3 start, Vector3 middle, Vector3 end)
        {
            m_triangle.m_start = start;
            m_triangle.m_middle = middle;
            m_triangle.m_end = end;
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
                    point = m_triangle.m_start;
                    break;
                case ThreePointCorner.Middle:
                    point = m_triangle.m_middle;
                    break;
                case ThreePointCorner.End:
                    point = m_triangle.m_end;
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
                    m_triangle.m_start = point;
                    break;
                case ThreePointCorner.Middle:
                    m_triangle.m_middle = point;
                    break;
                case ThreePointCorner.End:
                    m_triangle.m_end = point;
                    break;
                default:
                    break;


            }
        }

        public void GetCrossProductMiddle(out Vector3 crossProduct)
        {
            Vector3 startToMiddle = m_triangle.m_middle - m_triangle.m_start;
            Vector3 endToMiddle = m_triangle.m_middle - m_triangle.m_end;

            crossProduct = Vector3.Cross(startToMiddle, endToMiddle);
        }



        public void Clear()
        {
            SetThreePoints(Vector3.zero, Vector3.right * 0.0001f, Vector3.up * 0.0001f);
        }

        public void GetCentroid(out Vector3 centroid)
        {
            centroid = (m_triangle.m_start + m_triangle.m_middle + m_triangle.m_end) / 3;
        }
    }
}