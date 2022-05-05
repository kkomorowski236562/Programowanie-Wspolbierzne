using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;

namespace LogicTest;

[TestClass]
public class BallTest
{

    [TestMethod]
    public void simulateMoveTest()
    {

        int x = 1;
        int y = 2;
        int r = 0;
        int vx = 0;
        int vy = 3;

        Ball pilka = new Ball(x, y, r, vx, vy);

        pilka.simulateMove(200);
        pilka.simulateMove(200);

        Assert.AreEqual(5, pilka.y);
    }
    [TestMethod]
    public void tt()
    {


        Assert.AreEqual(5, 3);
    }
}