﻿using System;

namespace PowerArgs.Cli.Physics
{
    public class Floater : ThingInteraction
    {
        static Random rand = new Random();

        SpeedTracker tracker;
        public float MaxFloat { get; set; }

        public Floater() { }

        public Floater(Thing t, SpeedTracker tracker, float maxFloat = 1) : base(t)
        {
            this.MaxFloat = maxFloat;
            this.Governor.Rate = TimeSpan.FromSeconds(.03);
            this.tracker = tracker;
        }

        public override void Behave(Scene scene)
        {
            base.Behave(scene);

            float dX = ((float)(rand.NextDouble())) * MaxFloat;
            float dY = ((float)(rand.NextDouble())) * MaxFloat;

            if (rand.NextDouble() > .5) dX = -dX;
            if (rand.NextDouble() > .5) dY = -dY;

            tracker.SpeedX += dX;
            tracker.SpeedY += dY;
        }
    }
}
