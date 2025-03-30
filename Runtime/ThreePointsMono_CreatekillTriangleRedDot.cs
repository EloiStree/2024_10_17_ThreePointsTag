using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_CreateKillTriangleRedDot : MonoBehaviour
    {

        public ThreePointsMono_CreateKillRedDot m_start;
        public ThreePointsMono_CreateKillRedDot m_middle;
        public ThreePointsMono_CreateKillRedDot m_end;

        [ContextMenu("Create Red Dot")]
        public void CreateRedDot()
        {
            if( m_start!=null)
                m_start.CreateRedDot();
            if (m_middle != null)
                m_middle.CreateRedDot();
            if (m_end != null)
                m_end.CreateRedDot();
        }
        [ContextMenu("Kill red dot")]
        public void KillRedDot()
        {
            if (m_start != null)
                m_start.KillRedDot();
            if (m_middle != null)
                m_middle.KillRedDot();
            if (m_end != null)
                m_end.KillRedDot();
        }
    }    

}