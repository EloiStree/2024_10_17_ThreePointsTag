using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_DistanceAndAngle : MonoBehaviour
    {
        public ThreePoints_DistanceAndAngle m_data = new ThreePoints_DistanceAndAngle();

        public bool m_updateValue = true;
        public void Update()
        {
            if (m_updateValue)
            {
                m_data.m_triangle.ComputerFromOrigine();
            }
        }
    }

    [System.Serializable]
     public class ThreePoints_DistanceAndAngle 
    {
        public ThreePointsTriangleDefault m_triangle;

        public UnityEvent<I_ThreePointsDistanceAngleGet> m_onTriangleChanged;


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

        public void DrawLine( float timeToDraw =0)
        {
            if (timeToDraw<=0)
                timeToDraw = Time.deltaTime;

            Vector3 a = Vector3.one * 0.001f;
            m_triangle.GetPoints(out Vector3[] points);
            Debug.DrawLine(points[0] + a, points[1] + a, Color.green, timeToDraw);
            Debug.DrawLine(points[1] + a, points[2] + a, Color.red, timeToDraw);
            Debug.DrawLine(points[0] + a, points[2] + a, Color.blue, timeToDraw);
        }

    }
}