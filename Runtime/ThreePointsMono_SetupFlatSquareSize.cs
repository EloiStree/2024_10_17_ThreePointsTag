using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_SetupFlatSquareSize : MonoBehaviour {

        public float m_leftRightMillimeter = 420;
        public float m_leftUpMillimeter = 594;
        public float m_heightMillimeter = 0.5f;
        public Transform m_size;
        public Transform m_topLeft;
        public Transform m_topRight;
        public Transform m_downLeft;
        public Transform m_downRight;

        [ContextMenu("Refresh")]
        public void Refresh() {

            Vector3 rootPos = m_size.position;
            float halfWidth = m_leftRightMillimeter / 2000f;
            float halfHeight = m_leftUpMillimeter / 2000f;
            if (m_size == null)
                return;
            m_size.localScale = new Vector3(m_leftRightMillimeter / 1000f, m_heightMillimeter / 1000f, m_leftUpMillimeter/1000f);
            m_size.position = rootPos;
            GetLocalToWorld_Point(new Vector3(-halfWidth, 0, halfHeight), rootPos, m_size.rotation, out Vector3 topLeft);
            GetLocalToWorld_Point(new Vector3(halfWidth, 0, halfHeight), rootPos, m_size.rotation, out Vector3 topRight);
            GetLocalToWorld_Point(new Vector3(-halfWidth, 0, -halfHeight), rootPos, m_size.rotation, out Vector3 downLeft);
            GetLocalToWorld_Point(new Vector3(halfWidth, 0, -halfHeight), rootPos, m_size.rotation, out Vector3 downRight);
            
            if (m_topLeft != null)            
                m_topLeft.position = topLeft;
            if (m_topRight != null)
                m_topRight.position = topRight;
            if (m_downLeft != null)
                m_downLeft.position = downLeft;
            if (m_downRight != null)
                m_downRight.position = downRight;
        }

        public void SetToWidthHeight(float width, float height, float size=0.5f)
        {
            m_leftRightMillimeter = width;
            m_leftUpMillimeter = height;
            m_heightMillimeter = size;
            Refresh();
        }



        [ContextMenu("Set as A5")] public void SetToA5() => SetToWidthHeight(148, 210, 0.5f);
        [ContextMenu("Set as A4")] public void SetToA4() => SetToWidthHeight(210, 297, 0.5f);
        [ContextMenu("Set as A3")] public void SetToA3() => SetToWidthHeight(297, 420, 0.5f);
        [ContextMenu("Set as A2")] public void SetToA2() => SetToWidthHeight(420, 594, 0.5f);
        [ContextMenu("Set as A1")] public void SetToA1() => SetToWidthHeight(594, 841, 0.5f);
        [ContextMenu("Set as A0")] public void SetToA0() => SetToWidthHeight(841, 1189, 0.5f);
        [ContextMenu("Set Tennis Table")] public void SetToTennisTable() => SetToWidthHeight(1525, 2740, 0.5f);



        public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Transform rootReference, out Vector3 localPosition)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetWorldToLocal_Point(in worldPosition, in p, in r, out localPosition);
        }
        public static void GetLocalToWorld_Point(in Vector3 localPosition, in Transform rootReference, out Vector3 worldPosition)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetLocalToWorld_Point(in localPosition, in p, in r, out worldPosition);
        }
        public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition) =>
            localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);

        public static void GetLocalToWorld_Point(in Vector3 localPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition) =>
            worldPosition = (rotationReference * localPosition) + (positionReference);

        public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Transform rootReference, out Vector3 localPosition, out Quaternion localRotation)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetWorldToLocal_DirectionalPoint(in worldPosition, in worldRotation, in p, in r, out localPosition, out localRotation);
        }
        public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Transform rootReference, out Vector3 worldPosition, out Quaternion worldRotation)
        {
            Vector3 p = rootReference.position;
            Quaternion r = rootReference.rotation;
            GetLocalToWorld_DirectionalPoint(in localPosition, in localRotation, in p, in r, out worldPosition, out worldRotation);
        }
        public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition, out Quaternion localRotation)
        {
            localRotation = Quaternion.Inverse(rotationReference) * worldRotation;
            localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
        }
        public static void GetLocalToWorld_DirectionalPoint(in Vector3 localPosition, in Quaternion localRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 worldPosition, out Quaternion worldRotation)
        {
            worldRotation = localRotation * rotationReference;
            worldPosition = (rotationReference * localPosition) + (positionReference);
        }

        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
        {
            return RotatePointAroundPivot(point, pivot, Quaternion.Euler(angles));
        }

        public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            return rotation * (point - pivot) + pivot;
        }

        public static void RotateAroundPivot(Transform whatToRotate, Transform centerRotation, Quaternion rotationToApply)
        {
            RotateAroundPivot(whatToRotate.position, whatToRotate.rotation, centerRotation.position, rotationToApply, out Vector3 newPosition, out Quaternion newRotation);
            whatToRotate.position = newPosition;
            whatToRotate.rotation = newRotation;
        }
        public static void RotateAroundPivot(Transform whatToRotate, Vector3 centerRotation, Quaternion rotationToApply)
        {
            RotateAroundPivot(whatToRotate.position, whatToRotate.rotation, centerRotation, rotationToApply, out Vector3 newPosition, out Quaternion newRotation);
            whatToRotate.position = newPosition;
            whatToRotate.rotation = newRotation;
        }

        public static void RotateAroundPivot(
            Vector3 whatToRotatePosition,
            Quaternion whatToRotateRotation,
            Vector3 centerRotation,
            Quaternion rotationToApply,
            out Vector3 newPosition,
            out Quaternion newRotation)

        {
            //Rotate the right point to in aim to reconstruct the forward direction
            Vector3 rightPoint = whatToRotatePosition + whatToRotateRotation * Vector3.right;
            Vector3 currentPointRelocate = RotatePointAroundPivot(whatToRotatePosition, centerRotation, rotationToApply);
            Vector3 rightPointRelocated = RotatePointAroundPivot(rightPoint, centerRotation, rotationToApply);
            Vector3 centerToPointDirection = currentPointRelocate - centerRotation;
            Vector3 pointToRightDirection = rightPointRelocated - currentPointRelocate;
            Vector3 newForwardDirection = Vector3.Cross(pointToRightDirection, centerToPointDirection).normalized;
            newPosition = currentPointRelocate;
            newRotation = Quaternion.LookRotation(newForwardDirection, centerToPointDirection);

        }


        public static void RotateTargetAroundPointMath(
            Vector3 postion, Quaternion rotation,
            Vector3 center, Quaternion rotationFrom, Quaternion rotationTo,
            out Vector3 newPosition, out Quaternion newRotation)
        {
            // Calculate the rotation difference (quaternion multiplication)
            Quaternion rotationDifference = rotationTo * Quaternion.Inverse(rotationFrom);

            // Calculate the direction from the center to the object to move
            Vector3 direction = postion - center;

            // Rotate the direction by the rotation difference
            Vector3 rotatedDirection = rotationDifference * direction;

            // Update the position of the object
            newPosition = center + rotatedDirection;

            // Apply the rotation difference to the object
            newRotation = rotationDifference * rotation;

        }

        public static void RotateTargetAroundPointMath(Transform whatToMove, Vector3 center, Quaternion rotationFrom, Quaternion rotationTo)
        {
            RotateTargetAroundPointMath(
                whatToMove.position, whatToMove.rotation,
                center, rotationFrom, rotationTo,
                out Vector3 newPosition, out Quaternion newRotation);
            whatToMove.position = newPosition;
            whatToMove.rotation = newRotation;

        }


        public static void RotateTargetAroundPointByCreatingEmpyPoint(Transform whatToMove, Vector3 centroide, Quaternion rotationFrom, Quaternion rotationTo)
        {
            Quaternion toRotate = rotationTo * Quaternion.Inverse(rotationFrom);

            Transform p = whatToMove.parent;
            GameObject g = new GameObject("t");
            Transform t = g.transform;
            t.position = centroide;

            whatToMove.parent = t;
            t.rotation *= toRotate;
            whatToMove.parent = p;
            if (Application.isPlaying)
                GameObject.DestroyImmediate(g);
            else
                GameObject.Destroy(g);
        }
    }
}
