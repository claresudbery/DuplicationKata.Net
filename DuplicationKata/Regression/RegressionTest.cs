using System.Drawing;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DuplicationKata.Regression
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class RegressionTest
    {
        [TestMethod]
        public void testCat()
        {
            var song = new Lesson1Straight();
            song.SingCatSong();
            Approvals.Verify(song.song + "\n");
        }

        [TestMethod]
        public void testBeer()
        {
            var song = new Lesson2Variable();
            song.SingBottlesOfBeer();
            Approvals.Verify(song.song + "\n");
        }

        [TestMethod]
        public void testNumbers()
        {
            var song = new Lesson3HigherOrderFunctions();
            song.SingCheers();
            Approvals.Verify(song.song + "\n");
        }

        [TestMethod]
        public void test21()
        {
            Lesson21 song = new Lesson21();
            var names = new[] {"Llewellyn", "Samatha", "Tomas", "Emilia"};
            song.SingSong(1, names);
            song.SingSong(2, names);
            song.SingSong(3, names);
            Approvals.Verify(song.song + "\n");
        }

        [TestMethod]
        public void test31()
        {
            var song = new Lesson31();
            var names = new[] {"Llewellyn", "Samatha", "Tomas", "Emilia"};
            song.SingSong(1, names);
            song.SingSong(2, names);
            song.SingSong(3, names);
            Approvals.Verify(song.song + "\n");
        }

        [TestMethod]
        public void test32()
        {   
            CombinationApprovals.VerifyAllCombinations(
                GetSegmentIndex,
                new LineListType[] {LineListType.DestinationVertical, LineListType.DestinationHorizontal, LineListType.SourceHorizontal},
                new SegmentList[] {new SegmentList(new List<LineSegment>{
                        new LineSegment{
                            StartPoint = new Point { X = 1, Y = 2 },
                            EndPoint = new Point { X = 3, Y = 4 },
                            GenerationPoint = new Point { X = 5, Y = 6 }},
                        new LineSegment{
                            StartPoint = new Point { X = 9, Y = 10 },
                            EndPoint = new Point { X = 11, Y = 12 },
                            GenerationPoint = new Point { X = 13, Y = 14 }}})},
                new Point[] {new Point { X = 7, Y = 8 }});
        }

        private static string GetSegmentIndex(LineListType listType, SegmentList segmentList, Point point)
        {
            var indexCalculator = new Lesson32();
            return indexCalculator.GetSegmentIndex(listType, segmentList.LineSegments, point).ToString();
        }
    }

    internal class SegmentList
    {
        public List<LineSegment> LineSegments { get; }

        public SegmentList(List<LineSegment> lineSegments)
        {
            LineSegments = lineSegments;
        }

        public override string ToString()
        {
            var segmentsAsStrings = LineSegments.Select(x => x.ToString(LineSegments.IndexOf(x)));
            return $"\n{String.Join("\n", segmentsAsStrings.ToArray())}\n";
        }
    }

    internal class SegmentIndexResult
    {
        public LineList LineList { get; }
        public int Result { get; }

        public SegmentIndexResult(LineList lineList, int result)
        {
            LineList = lineList;
            Result = result;
        }

        public override string ToString()
        {
            var segmentsAsStrings = LineList.Segments.Select(x => x.ToString(LineList.Segments.IndexOf(x), Result));
            var allSegments = String.Join("\n", segmentsAsStrings.ToArray());
            return $"\nType: {LineList.Type.ToString()}\n"
                   + allSegments
                   + $"\nPoint: ({LineList.Point.X},{LineList.Point.Y})";
        }
    }
}