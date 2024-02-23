using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DuplicationKata;
using Xunit;

public class Lesson32
{
    [Fact]
    public void MyTestV1()
    {
        Point point = new Point();
        int segmentIndex = 0;
        List<LineSegment> lineSegments = new List<LineSegment>();
            
        if(lineSegments.Count > 0)
        {
            for(int i = 0; i < lineSegments.Count; ++i)
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
            for(int i = 0; i < lineSegments.Count; ++i)
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

        Assert.Equals(segmentIndex, 10);
    }
    
    [Fact]
    public void MyTestV2()
    {
        Point point = new Point();
        int segmentIndex = 0;
        List<LineSegment> lineSegments = new List<LineSegment>();
            
        if(lineSegments.Count > 0)
        {
            Func<Point, int> BlueFunc = point => point.X;
            Func<Point, int> YellowFunc = point => point.Y;
            
            for(int i = 0; i < lineSegments.Count; ++i)
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
            for(int i = 0; i < lineSegments.Count; ++i)
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

        Assert.Equals(segmentIndex, 10);
    }
    
    [Fact]
    public void MyTestV3()
    {
        Point point = new Point();
        int segmentIndex = 0;
        List<LineSegment> lineSegments = new List<LineSegment>();
            
        if(lineSegments.Count > 0)
        {
            Func<Point, int> BlueFunc = point => point.X;
            Func<Point, int> YellowFunc = point => point.Y;
            
            segmentIndex = SegmentIndex(lineSegments, BlueFunc, point, YellowFunc, segmentIndex);
        }
        else
        {
            for(int i = 0; i < lineSegments.Count; ++i)
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

        Assert.Equals(segmentIndex, 10);
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

public class LineSegment
{
    public Point GenerationPoint { get; set; }
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
}