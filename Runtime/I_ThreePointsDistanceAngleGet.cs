namespace Eloi.ThreePoints
{
    public interface I_ThreePointsDistanceAngleGet : I_ThreePointsGet
    {

        public void GetCornerAngle(ThreePointCorner corner, out float angle);
        public void GetSegmentDistance(ThreePointSegment segment, out float distance);
    }
}