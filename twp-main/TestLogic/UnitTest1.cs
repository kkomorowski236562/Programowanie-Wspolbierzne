using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace TestLogic
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void gettersTest()
        {
            int x = 1;
            int y = 150;
            int r = 3;
            int vx = 2;
            int vy = 3;

            Ball pilka = new Ball(x, y, r, vx, vy);

            Assert.AreEqual(1, pilka.X);
            Assert.AreEqual(150, pilka.Y);
            Assert.AreEqual(3, pilka.R);
            Assert.AreEqual(2, pilka.VelX);
            Assert.AreEqual(3, pilka.VelY);
        }

        [TestMethod]
        public void simulateMoveTest()
        {

            int x = 1;
            int y = 150;
            int r = 3;
            int vx = 2;
            int vy = 3;

            Ball pilka = new Ball(x, y, r, vx, vy);

            pilka.simulateMove(300);

            Assert.AreEqual(153, pilka.Y);
        }

        [TestMethod]
        public void simulateMoveBouceTest()
        {

            int x = 1;
            int y = 150;
            int r = 3;
            int vx = 2;
            int vy = 3;

            Ball pilka = new Ball(x, y, r, vx, vy);

            pilka.simulateMove(151);

            Assert.AreEqual(147, pilka.Y);
        }

        [TestMethod]
        public void BoardConstructorTest()
        {
            int expectedSize = 200;
            Board plansza = new Logic.Board(expectedSize);

           
            Assert.AreEqual(0, plansza.Balls.Count);
            Assert.AreEqual(expectedSize, plansza.Size);
        }

        [TestMethod]
        public void addRandomBallTest()
        {
            int expectedSize = 200;
            int expectedBalls = 3;
            Board plansza = new Board(expectedSize);

            plansza.AddRandomBalls(expectedBalls);

            Assert.AreEqual(expectedBalls, plansza.Balls.Count);

        }
    }
}