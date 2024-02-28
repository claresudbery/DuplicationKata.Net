using System.Drawing;

namespace DuplicationKata
{
    public class Lesson32
    {
        public int GetSegmentIndex(LineList lineList)
        {
            int segmentIndex = 0;

            if (lineList.Type == LineListType.SourceHorizontal || lineList.Type == LineListType.DestinationHorizontal)
            {
                for (int i = 0; i < lineList.Segments.Count; ++i)
                {
                    var lineSegment = lineList.Segments[i];
                    if (lineSegment.GenerationPoint.X == lineList.Point.X 
                        && lineList.Point.Y >= lineSegment.StartPoint.Y 
                        && lineList.Point.Y <= lineSegment.EndPoint.Y)
                    {
                        segmentIndex = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lineList.Segments.Count; ++i)
                {
                    var lineSegment = lineList.Segments[i];
                    if (lineSegment.GenerationPoint.Y == lineList.Point.Y 
                        && lineList.Point.X >= lineSegment.StartPoint.X 
                        && lineList.Point.X <= lineSegment.EndPoint.X)
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