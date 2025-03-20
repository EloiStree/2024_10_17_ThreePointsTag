using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_CreatekillGroupRedDot : MonoBehaviour
    {

        public ThreePointsMono_CreateKillRedDot [] m_group;


        [ContextMenu("Create Red Dot")]
        public void CreateRedDot()
        {
            foreach (var item in m_group)
            {
                if (item != null)
                    item.CreateRedDot();
            }
        }
        [ContextMenu("Kill red dot")]
        public void KillRedDot()
        {
            foreach (var item in m_group)
            {
                if(item != null)
                    item.KillRedDot();
            }
        }
    }

}