using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGame.Tests
{
    [TestClass]
    public class BowlingGameTest
    {
        private Game game;

        [TestInitialize]
        public void SetUp()
        {
            game = new Game();
        }

        [TestMethod]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

        [TestMethod]
        public void TestAllSpares()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(5);
                game.Roll(5);
            }
            game.Roll(5); // Bonus roll
            Assert.AreEqual(150, game.Score());
        }

        [TestMethod]
        public void TestLastFrameSpare()
        {
            RollMany(18, 0); // 9 frames of zeros
            game.Roll(5);
            game.Roll(5); // Spare in 10th frame
            game.Roll(7); // Bonus roll
            Assert.AreEqual(17, game.Score());
        }

        [TestMethod]
        public void TestLastFrameStrike()
        {
            RollMany(18, 0); // 9 frames of zeros
            game.Roll(10); // Strike in 10th frame
            game.Roll(7);
            game.Roll(2); // Two bonus rolls
            Assert.AreEqual(19, game.Score());
        }

        [TestMethod]
        public void TestSampleGame()
        {
            int[] rolls = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
            foreach (int pins in rolls)
            {
                game.Roll(pins);
            }
            Assert.AreEqual(133, game.Score());
        }

        [TestMethod]
        public void TestMultipleStrikes()
        {
            // Two strikes in a row
            game.Roll(10); // Strike
            game.Roll(10); // Strike
            game.Roll(5);
            game.Roll(3);
            RollMany(14, 0);
            Assert.AreEqual(51, game.Score());
        }

        [TestMethod]
        public void TestStrikesAndSpares()
        {
            game.Roll(10); // Strike
            game.Roll(5);
            game.Roll(5); // Spare
            game.Roll(7);
            RollMany(14, 0);
            Assert.AreEqual(49, game.Score());
        }

        [TestMethod]
        public void TestTenthFrameStrikeFollowedBySpare()
        {
            RollMany(18, 0); // 9 frames of zeros
            game.Roll(10); // Strike in 10th frame
            game.Roll(4);
            game.Roll(6); // Spare in bonus rolls
            Assert.AreEqual(20, game.Score());
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }
    }
}