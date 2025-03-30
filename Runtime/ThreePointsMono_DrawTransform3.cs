using UnityEngine;

namespace Eloi.ThreePoints
{
    [ExecuteInEditMode]
    public class ThreePointsMono_DrawTransform3 :MonoBehaviour
    {

        private void Reset()
        {
            m_source = GetComponentInParent<ThreePointsMono_Transform3>();
        }
        public ThreePointsMono_Transform3 m_source;
        public bool m_useDraw = true;
        public Color m_color = Color.green;
        public Color m_axis = Color.red;
        public float m_axisLength = 0.1f;
        public void Update()
        {
            if (m_useDraw)
                Draw();
        }
        public void Draw()
        {
            m_source.m_triangle.GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
            Debug.DrawLine(start, middle, m_color);
            Debug.DrawLine(middle, end,   m_color);
            Debug.DrawLine(end, start, m_color);
            Vector3 directionForward = Vector3.Cross(
                middle - start
                , middle - end);
            Debug.DrawRay(middle, directionForward.normalized * m_axisLength, m_axis);
        }
    }
}
