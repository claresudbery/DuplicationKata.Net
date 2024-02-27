using System.Drawing;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
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
                new LineListType[] { LineListType.DestinationVertical },
                new List<LineSegment>[] {new List<LineSegment>(){new LineSegment{
                        StartPoint = new Point { X = 2, Y = 3 },
                        EndPoint = new Point { X = 2, Y = 3 },
                        GenerationPoint = new Point { X = 2, Y = 3 }}}},
                new Point[] { new Point { X = 2, Y = 3 } });
        }

        private static string GetSegmentIndex(LineListType lineListType, List<LineSegment> lineSegments, Point point)
        {
            var indexCalculator = new Lesson32();
            return indexCalculator.GetSegmentIndex(lineListType, lineSegments, point).ToString();
        }
    }
}