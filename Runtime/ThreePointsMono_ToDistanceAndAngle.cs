using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_ToDistanceAndAngle : MonoBehaviour
    {
        public ThreePointsTriangleDefault m_triangle;

        public UnityEvent<I_ThreePointsDistanceAngleGet> m_onTriangleChanged;

        public bool m_useDrawLine = true;

        public void SetWithPoints(I_ThreePointsGet triangle)
        {
            triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);

            m_triangle.SetThreePoints(start, middle, end);
            m_onTriangleChanged.Invoke(m_triangle);
        }
        public void SetWithPoints(Vector3 startPoint, Vector3 middlePoint, Vector3 endPoint)
        {

            m_triangle.SetThreePoints(startPoint, middlePoint, endPoint);
            m_onTriangleChanged.Invoke(m_triangle);
        }
        public void Update()
        {
            if (m_useDrawLine)
            {
                DrawLine();
            }
        }

        private void DrawLine()
        {
            Vector3 a = Vector3.one * 0.001f;
            m_triangle.GetPoints(out Vector3[] points);
            Debug.DrawLine(points[0] + a, points[1] + a, Color.green);
            Debug.DrawLine(points[1] + a, points[2] + a, Color.red);
            Debug.DrawLine(points[0] + a, points[2] + a, Color.blue);
        }

    }
}