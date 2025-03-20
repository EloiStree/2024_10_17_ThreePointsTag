using UnityEngine;

namespace Eloi.ThreePoints
{
    public interface I_ThreePointsGet
    {
        public void GetPoints(out Vector3[] arrayOf3);
        public void GetPoint(ThreePointCorner corner, out Vector3 point);
        public void GetThreePoints(out Vector3 start, out Vector3 middle, out Vector3 end);
    }
}