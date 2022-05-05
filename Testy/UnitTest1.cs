using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void gettersTest()
        {
            int id = 1;
            int x = 256;
            int y = 128;
            int szx = 64;
            int szy = 32;

            Kulki pilka = new Kulki(id, x, y, szx, szy);

            Assert.AreEqual(1, pilka.ID);
            Assert.AreEqual(256, pilka.X);
            Assert.AreEqual(128, pilka.Y);
            Assert.AreEqual(64, pilka.SzX);
            Assert.AreEqual(32, pilka.SzY);
        }

        [TestMethod]
        public void simulateMoveTest()
        {

            int id = 1;
            int x = 256;
            int y = 128;
            int szx = 64;
            int szy = 32;

            Kulki pilka = new Kulki(id, x, y, szx, szy);

            pilka.move(300);

            Assert.AreEqual(192, pilka.X);
            Assert.AreEqual(160, pilka.Y);
        }
    }
}