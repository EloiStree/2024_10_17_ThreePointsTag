using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_MovableTransform3 : MonoBehaviour {

        private void Reset()
        {
            m_whatToMove = GetLeafParent();
            m_relatedTriangle = GetComponentInChildren<ThreePointsMono_Transform3>();
        }
        public ThreePointsMono_Transform3 m_relatedTriangle;
        public Transform m_whatToMove;


        public Transform GetLeafParent() {

            Transform current = this.transform;
            while (current.parent != null)
            {
                current = current.parent;
            }
            return current;
        }
    }
}
