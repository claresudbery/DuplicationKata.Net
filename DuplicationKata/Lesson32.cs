using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                    Func<Point, int> BlueFunc = point => point.X;
                    Func<Point, int> YellowFunc = point => point.Y;

                    var generationPointX = BlueFunc(lineSegment.GenerationPoint);
                    var pointX = BlueFunc(point);
                    var pointY = YellowFunc(point);
                    var startPointY = YellowFunc(lineSegment.StartPoint);
                    var endPointY = YellowFunc(lineSegment.EndPoint);

                    if (generationPointX == pointX
                        && pointY >= startPointY
                        && pointY <= endPointY)
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
        
        public int GetSegmentIndex_Refactored_V1(
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
                    Func<Point, int> BlueFunc = point => point.X;
                    Func<Point, int> YellowFunc = point => point.Y;

                    var generationPointX = BlueFunc(lineSegment.GenerationPoint);
                    var pointX = BlueFunc(point);
                    var pointY = YellowFunc(point);
                    var startPointY = YellowFunc(lineSegment.StartPoint);
                    var endPointY = YellowFunc(lineSegment.EndPoint);

                    if (generationPointX == pointX
                        && pointY >= startPointY
                        && pointY <= endPointY)
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
        
        public int GetSegmentIndex_Refactored_V2(
            LineListType listType, 
            List<LineSegment> lineSegments,
            Point point)
        {
            int segmentIndex = 0;

            if (listType == LineListType.SourceHorizontal || listType == LineListType.DestinationHorizontal)
            {
                Func<Point, int> BlueFunc = point => point.X;
                Func<Point, int> YellowFunc = point => point.Y;

                for (int i = 0; i < lineSegments.Count; ++i)
                {
                    var lineSegment = lineSegments[i];
                    if (BlueFunc(lineSegment.GenerationPoint) == BlueFunc(point)
                        && YellowFunc(point) >= YellowFunc(lineSegment.StartPoint)
                        && YellowFunc(point) <= YellowFunc(lineSegment.EndPoint))
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

        public int GetSegmentIndex_Refactored_V3(
            LineListType listType, 
            List<LineSegment> lineSegments,
            Point point)
        {
            int segmentIndex = 0;

            if (listType == LineListType.SourceHorizontal || listType == LineListType.DestinationHorizontal)
            {
                Func<Point, int> BlueFunc = point => point.X;
                Func<Point, int> YellowFunc = point => point.Y;

                segmentIndex = SegmentIndex(lineSegments, BlueFunc, point, YellowFunc, segmentIndex);
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

        private static int SegmentIndex(
            List<LineSegment> lineSegments,
            Func<Point, int> BlueFunc,
            Point point,
            Func<Point, int> YellowFunc,
            int segmentIndex)
        {
            for (int i = 0; i < lineSegments.Count; ++i)
            {
                var lineSegment = lineSegments[i];
                if (BlueFunc(lineSegment.GenerationPoint) == BlueFunc(point)
                    && YellowFunc(point) >= YellowFunc(lineSegment.StartPoint)
                    && YellowFunc(point) <= YellowFunc(lineSegment.EndPoint))
                {
                    segmentIndex = i;
                    break;
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