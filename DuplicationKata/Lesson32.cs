using System.Drawing;

namespace DuplicationKata
{
    public class Lesson32
    {
        public int GetSegmentIndex(LineListType listType, List<LineSegment> lineSegments, Point point)
        {
            int segmentIndex = 0;

            if (listType == LineListType.SourceHorizontal || listType == LineListType.DestinationHorizontal)
            {
                for (int i = 0; i < lineSegments.Count; ++i)
                {
                    var lineSegment = lineSegments[i];
                    if (lineSegment.GenerationPoint.X == point.X 
                        && point.Y >= lineSegment.StartPoint.Y 
                        && point.Y <= lineSegment.EndPoint.Y)
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
                    if (lineSegment.GenerationPoint.Y == point.Y 
                        && point.X >= lineSegment.StartPoint.X 
                        && point.X <= lineSegment.EndPoint.X)
                    {
                        segmentIndex = i;
                        break;
                    }
                }
            }

            return segmentIndex;
        }
    }

    public class LineList
    {
        public LineListType Type { get; }
        public List<LineSegment> Segments { get; }
        public Point Point { get; }

        public LineList(LineListType listType, List<LineSegment> lineSegments, Point point)
        {
            Type = listType;
            Segments = lineSegments;
            Point = point;
        }

        public override string ToString()
        {
            var segmentsAsStrings = Segments.Select(x => x.ToString(Segments.IndexOf(x)));
            var allSegments = String.Join("\n", segmentsAsStrings.ToArray());
            return $"Type: {Type.ToString()}\n"
                   + allSegments
                   + $"\nPoint: ({Point.X},{Point.Y})";
        }
    }

    public enum LineListType
    {
        SourceHorizontal,
        DestinationHorizontal,
        DestinationVertical
    }

    public class LineSegment
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Point GenerationPoint { get; set; }

        public override string ToString()
        {
            return $"Start: ({StartPoint.X},{StartPoint.Y}), "
                   + $"End: ({EndPoint.X},{EndPoint.Y}), "
                   + $"Generation: ({GenerationPoint.X},{GenerationPoint.Y})";
        }

        public string ToString(int index, int resultIndex)
        {
            string marker = index == resultIndex ? "RESULT: " : "        ";
            return $"{marker}{index}: {ToString()}";
        }

        public string ToString(int index)
        {
            return $"{index}: {ToString()}";
        }
    }
}