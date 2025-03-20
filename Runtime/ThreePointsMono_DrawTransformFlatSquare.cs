using UnityEngine;

namespace Eloi.ThreePoints
{
    [ExecuteInEditMode]
    public class ThreePointsMono_DrawTransformFlatSquare : MonoBehaviour {

        public ThreePointsMono_TransformFlatSquare m_squareSource;
        public Color m_colorBorder = Color.green;
        public bool m_useDraw = true;
        public void Update()
        {
            if (m_squareSource ==null) 
                return;

            if (m_useDraw)
            {
                Draw();
            }
        }

        private void Draw()
        {
            Debug.DrawLine(m_squareSource.m_downLeft.position, m_squareSource.m_downRight.position, m_colorBorder);
            Debug.DrawLine(m_squareSource.m_downRight.position, m_squareSource.m_topRight.position, m_colorBorder);
            Debug.DrawLine(m_squareSource.m_topRight.position, m_squareSource.m_topLeft.position, m_colorBorder);
            Debug.DrawLine(m_squareSource.m_topLeft.position, m_squareSource.m_downLeft.position, m_colorBorder);
        }
    }
}
