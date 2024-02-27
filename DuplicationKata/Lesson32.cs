using System.Drawing;

namespace DuplicationKata
{
    public class Lesson32
    {
        public int GetSegmentIndex(
            LineListType listType, 
            List<LineSegment> lineSegments,
            Point point)
        {
            int segmentIndex = 0;

            if (listType == LineListType.SourceHorizontal || listType == LineListType.DestinationHorizontal)
            {
                for (int i = 0; i < lineSegments.Count; ++i)
                {
                    var lineSegment = lineSegments[i];
                    if (lineSegment.GenerationPoint.X == point.X && point.Y >= lineSegment.StartPoint.Y && point.Y <= lineSegment.EndPoint.Y)
                    {
                        segmentIndex = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lineSegments.Count; ++i)
                {
                    var lineSegment = lineSegments[i];
                    if (lineSegment.GenerationPoint.Y == point.Y && point.X >= lineSegment.StartPoint.X && point.X <= lineSegment.EndPoint.X)
                    {
                        segmentIndex = i;
                        break;
                    }
                }
            }

            return segmentIndex;
        }
    }

    public enum LineListType
    {
        SourceHorizontal,
        DestinationHorizontal
    }

    public class LineSegment
    {
        public Point GenerationPoint { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}