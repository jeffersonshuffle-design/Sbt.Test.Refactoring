
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Units
{
    using Sbt.Test.Refactoring.Extensions;
    using Sbt.Test.Refactoring.Commands;
    using Sbt.Test.Refactoring.Exceptions;
    public class MoveableUnit:UnitBase,  IOrientable, IPositionable
    {
        private Point _position;
        private Orientation _orientation;

        private readonly Dictionary<Type, Action> actions ;

        public MoveableUnit(Map map, Orientation orientation,Point position) : base(map)
        {
            _orientation = orientation;
            _position = position;
            actions = new Dictionary<Type, Action>
            {
                [typeof(MoveForwardCommand)] = () => MoveForward(),
                [typeof(TurnClockwiseCommand)] = () => TurnClockwise()
            };
        }

        public Orientation Orientation => _orientation;

        public int PositionX => _position.X;

        public int PositionY => _position.Y;

        public override void ExecuteCommand(CommandBase command)
        {
            base.ExecuteCommand(command);

            var commandType = command.GetType();

            if (!actions.ContainsKey(commandType))
            {
                return;
            }

            actions[commandType]();
        }

        private void MoveForward()
        {
            if (_orientation == Orientation.North)
            {
                _position.Y++;
            }
            else if (_orientation == Orientation.East)
            {
                _position.X++;
            }
            else if (_orientation == Orientation.South)
            {
                _position.Y--;
            }
            else if (_orientation == Orientation.West)
            {
                _position.X--;
            }

            if (_position.X > Map.Width || _position.Y > Map.Height)
            {
                throw new MapBoundsExceededException();
            }
        }

        private void TurnClockwise()
        {
            _orientation = _orientation.GetNext();
        }
    }
}
