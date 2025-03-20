using UnityEngine;

namespace Eloi.ThreePoints
{
    public interface I_ThreePointsSet
    {
        public void SetThreePoints(Vector3 start, Vector3 middle, Vector3 end);
        public void SetPoint(ThreePointCorner corner, Vector3 point);
    }
}