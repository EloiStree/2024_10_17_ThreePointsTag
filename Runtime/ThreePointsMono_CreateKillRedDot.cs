using System;
using UnityEngine;

namespace Eloi.ThreePoints
{
    public class ThreePointsMono_CreateKillRedDot : MonoBehaviour
{
        public GameObject m_redDotPrefab;
        public Transform m_parent;
        public GameObject m_created;

        [ContextMenu("Create Red Dot")]
        public void CreateRedDot()
        {
            if (m_created != null)
            {
                KillRedDot();
            }
            GameObject go = Instantiate(m_redDotPrefab, m_parent);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.parent= m_parent;
            go.transform.localScale = Vector3.one;
            m_created = go;
        }

        [ContextMenu("Kill Red Dot")]
        public void KillRedDot()
        {
            if (m_created != null) { 
            if(Application.isEditor)
            {
                DestroyImmediate(m_created);
            }
            else
            {
                Destroy(m_created);
            }
            }
        }
    }

}