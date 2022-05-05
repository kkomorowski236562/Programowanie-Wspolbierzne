using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateBall()
        {
            BallsCollection col = new BallsCollection();

            iBall b = col.createBall(3, 4, 5);

            
            Assert.AreEqual(3, b.x);
            Assert.AreEqual(4, b.y);
            Assert.AreEqual(5, b.radius);
        }

        [TestMethod]
        public void TestCount()
        {
            BallsCollection col = new BallsCollection();

            int wynik = col.count();
            Assert.AreEqual(0, wynik);
        }

        [TestMethod]
        public void TestAdd()
        {
            BallsCollection col = new BallsCollection();
            iBall b = col.createBall(2, 3, 4);
            col.add(b);


            int wynik = col.count();
            Assert.AreEqual(1, wynik);
        }

        [TestMethod]
        public void TestRemove()
        {
            BallsCollection col = new BallsCollection();
            iBall b = col.createBall(2, 3, 4);
            col.add(b);

            col.remove(b);
            int wynik = col.count();

            Assert.AreEqual(0, wynik);
        }

        
    }
}