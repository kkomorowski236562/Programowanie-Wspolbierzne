using System;
using System.Collections.Generic;
using Data;
using System.Threading;
using System.Threading.Tasks;


namespace Logic
{
    public abstract class logic
    {
        
        public static logic CreateLayer(DataApi data = default(DataApi))
        {
            return new BusinessLogic(data == null ? DataApi.Create() : data);
        }

        public abstract List<Ball> BallCollection();
        public abstract int BallCount();
        public abstract int BoardSize();
        public abstract void StartMovingBalls();
        public abstract void StopMovingBalls();

       public abstract Ball AddBall();

        private class BusinessLogic : logic
        {
            public  Task positionUpdater { get; private set; }
            public Board map = new Board(300);
            private readonly DataApi DataLayer;
            private bool running;


            public BusinessLogic(DataApi dataLayerAPI)
            {
                DataLayer = dataLayerAPI;
            }

            public override void StartMovingBalls()
            {
                this.running = true;
                positionUpdater = new Task(MoveBallsInLoop);
                positionUpdater.Start();
            }


            private void MoveBallsInLoop()
            {
                while (this.running)
                {
                    map.MoveBalls();
                    Thread.Sleep(10);
                }
            }

            public override void StopMovingBalls()
            {
                this.running = false;
            }

            override public List<Ball> BallCollection()
            {
                return map.Balls;
            }
            override public  int BallCount()
            {
                return map.Balls.Count;
            }
            override public  int BoardSize()
            {
                return map.Size;
            }
            public override Ball AddBall()
            {
                return map.AddRandomBall();
            }
        }

    }
}
