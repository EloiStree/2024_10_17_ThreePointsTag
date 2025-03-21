using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreaPointsMono_ToMoveFromTriangle : MonoBehaviour {

        private void Reset()
        {
            m_whatToMove = transform;
            m_relatedTriangle = GetComponentInChildren<ThreePointsMono_Transform3>();
        }
        public ThreePointsMono_Transform3 m_relatedTriangle;
        public Transform m_whatToMove;
    }
}
