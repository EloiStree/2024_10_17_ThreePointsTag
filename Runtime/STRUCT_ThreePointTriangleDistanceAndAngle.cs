using System;
using UnityEngine;

namespace Eloi.ThreePoints
{
    [System.Serializable]
    public struct STRUCT_ThreePointTriangleDistanceAndAngle
    {
        public float m_startMiddleDistance;
        public float m_middleEndDistance;
        public float m_startEndDistance;
        [Range(0, 180)]
        public float m_middlePointAngle;
        [Range(0, 180)]
        public float m_startPointAngle;
        [Range(0, 180)]
        public float m_endPointAngle;
    }

    [System.Serializable]
    public struct STRUCT_EdgeDistanceABC
    {
        public float m_distanceA;
        public float m_distanceB;
        public float m_distanceC;
    }
    [System.Serializable]
    public struct STRUCT_EdgeDistanceStartMiddleEnd
    {
        public float m_startMiddleDistance;
        public float m_middleEndDistance;
        public float m_startEndDistance;
    }
}