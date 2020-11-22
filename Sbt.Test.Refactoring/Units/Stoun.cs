using System;
using System.Drawing;

namespace Sbt.Test.Refactoring.Units
{
    public class Stoun : UnitBase, IPositionable
    {
        private Point _position;

        public Stoun(Map map, Point position) : base(map)
        {
            if (position.X > Map.Width || position.Y > Map.Height)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }
        }
        public int PositionX => _position.X;

        public int PositionY => _position.Y;
    }
}
