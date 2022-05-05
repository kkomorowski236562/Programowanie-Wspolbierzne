using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic;

namespace Model
{
    public  abstract class ModelApi
    {
        private logic logic;
        public static ModelApi CreateLayer(Logic.logic Lapi = default(logic))
        {
            return new Model(Lapi == null ? logic.CreateLayer() : Lapi);
        }

        public abstract ObservableCollection<ElipseModel> GetModels();

        public abstract void StartMoving();
        public abstract void StopMoving();

        //public abstract void Start();
        public abstract int getBoardSize();
        public abstract void addBalls(int count);

        // implementacja Api
        private class Model : ModelApi
        {
            private ObservableCollection<ElipseModel> Elipses = new ObservableCollection<ElipseModel>();

            public override ObservableCollection<ElipseModel> GetModels()
            {
                return Elipses;
            }
            public Model(logic logika)
            {
                logic = logika;
            }

            override public void StartMoving()
            {
                logic.StartMovingBalls();
            }

            public override void StopMoving()
            {
                logic.StopMovingBalls();
            }


            override public int getBoardSize()
            {
                return logic.BoardSize();
            }

            public override void addBalls(int count)
            {
                for( int i = 0; i< count; i++ )
                {
                    logic.AddBall();
                    Elipses.Add(new ElipseModel(logic.AddBall()));

                }

            }

        }
    }
}
