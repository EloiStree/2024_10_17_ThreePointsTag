
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.ThreePoints
{

    [ExecuteInEditMode]
    public class ThreePointsMono_Transform3 : MonoBehaviour
    {
        public Transform m_startPoint;
        public Transform m_middlePoint;
        public Transform m_endPoint;
        public ThreePointsTriangleDefault m_triangle;

        public UnityEvent<I_ThreePointsGet> m_onPushed;
        public bool m_pushAtStart = true;
        public bool m_pushAtUpdate = false;

        private void Start()
        {
            if (m_pushAtStart)
            {
                Push();
            }
        }


        [ContextMenu("Push")]
        public void Push()
        {
            RefreshDataWithoutNotification();
            m_onPushed.Invoke(m_triangle);
        }

        public void Update()
        {
            if (m_pushAtUpdate)
            {
                Push();
            }
            else
            {
                RefreshDataWithoutNotification();
            }

        }

        public void SetWith(I_ThreePointsGet triangle)
        {

            triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
            SetWith(start, middle, end);
        }

        public void SetWith(Vector3 start, Vector3 middle, Vector3 end)
        {
            m_startPoint.position = start;
            m_middlePoint.position = middle;
            m_endPoint.position = end;
            m_triangle.SetThreePoints(m_startPoint.position, m_middlePoint.position, m_endPoint.position);
            Push();
        }


        public void GetCrossProductMiddle(out Vector3 cross)
        {
            m_triangle.GetCrossProductMiddle(out cross);
        }

        public void RefreshDataWithoutNotification()
        {
            m_triangle.SetThreePoints(m_startPoint.position, m_middlePoint.position, m_endPoint.position);
        }



        public void GetCentroid(out Vector3 centroid)
        {            //DUPLICATA IN THREEPOINTSUTILTY TO WORKS WITHOUT IT.

            m_triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
            centroid = new Vector3(
        (start.x + middle.x + end.x) / 3,
        (start.y + middle.y + end.y) / 3,
        (start.z + middle.z + end.z) / 3
    );
        }
        public void GetClosestPoint(Vector3 toPoint, out ThreePointCorner closestCorner, out Vector3 closestPosition, out float distance)
        {            //DUPLICATA IN THREEPOINTSUTILTY TO WORKS WITHOUT IT.

            distance = float.MaxValue;
            m_triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
            closestCorner = ThreePointCorner.Start;
            closestPosition = start;
            float distanceStart = Vector3.Distance(start, toPoint);
            float distanceMiddle = Vector3.Distance(middle, toPoint);
            float distanceEnd = Vector3.Distance(end, toPoint);
            if (distanceStart < distance)
            { closestCorner = ThreePointCorner.Start; distance = distanceStart; closestPosition = start; }
            if (distanceMiddle < distance)
            { closestCorner = ThreePointCorner.Middle; distance = distanceMiddle; closestPosition = middle; }
            if (distanceEnd < distance)
            { closestCorner = ThreePointCorner.End; distance = distanceEnd; closestPosition = end; }

        }



        public void GetFarestPoint(Vector3 toPoint, out ThreePointCorner closestCorner, out Vector3 closestPosition, out float distance)
        {
            //DUPLICATA IN THREEPOINTSUTILTY TO WORKS WITHOUT IT.
            distance = 0;
            m_triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
            closestCorner = ThreePointCorner.Start;
            closestPosition = start;
            float distanceStart = Vector3.Distance(start, toPoint);
            float distanceMiddle = Vector3.Distance(middle, toPoint);
            float distanceEnd = Vector3.Distance(end, toPoint);
            if (distanceStart > distance)
            { closestCorner = ThreePointCorner.Start; distance = distanceStart; closestPosition = start; }
            if (distanceMiddle > distance)
            { closestCorner = ThreePointCorner.Middle; distance = distanceMiddle; closestPosition = middle; }
            if (distanceEnd > distance)
            { closestCorner = ThreePointCorner.End; distance = distanceEnd; closestPosition = end; }

        }
    }
}
