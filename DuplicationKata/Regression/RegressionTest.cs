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
            // CombinationApprovals.VerifyAllCombinations(
            //     GetSegmentIndex,
            //     new LineList[] {new LineList(
            //         LineListType.DestinationVertical,
            //         new List<LineSegment>(){new LineSegment{
            //                 StartPoint = new Point { X = 1, Y = 2 },
            //                 EndPoint = new Point { X = 3, Y = 4 },
            //                 GenerationPoint = new Point { X = 5, Y = 6 }}},
            //         new Point { X = 7, Y = 8 })});
            
            CombinationApprovals.VerifyAllCombinations(
                GetSegmentIndex,
                new LineListType[] {LineListType.DestinationVertical},
                new int[] {1},
                new int[] {2},
                new int[] {3},
                new int[] {4},
                new int[] {5},
                new int[] {6},
                new int[] {7},
                new int[] {8});
        }

        private static string GetSegmentIndex(LineList lineList)
        {
            var indexCalculator = new Lesson32();
            return indexCalculator.GetSegmentIndex(lineList).ToString();
        }

        private static string GetSegmentIndex(
            LineListType listType,
            int startX, int startY,
            int endX, int endY,
            int genX, int genY,
            int pointX, int pointY)
        {
            var lineList = new LineList(
                listType,
                new List<LineSegment>()
                {
                    new LineSegment
                    {
                        StartPoint = new Point { X = startX, Y = startY },
                        EndPoint = new Point { X = endX, Y = endY },
                        GenerationPoint = new Point { X = genX, Y = genY }
                    }
                },
                new Point { X = pointX, Y = pointY });
            var indexCalculator = new Lesson32();
            return indexCalculator.GetSegmentIndex(lineList).ToString();
        }
    }
}