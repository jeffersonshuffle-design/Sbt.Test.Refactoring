using System.Drawing;
using Sbt.Test.Refactoring.Commands;
using System.Collections.Generic;
using System;
using Sbt.Test.Refactoring.Exceptions;

namespace Sbt.Test.Refactoring.Units
{
    public class Tractor : UnitBase, IOrientable,IPositionable
    {
        private readonly MoveableUnit _moveEngine;

        private readonly Dictionary<Type, Action<CommandBase>> actions;

        public Tractor(Map map, Orientation orientation, Point position) : base(map)
        {
            _moveEngine = new MoveableUnit(map, orientation, position);
            actions = new Dictionary<Type, Action<CommandBase>>()
            {
                [typeof(MoveForwardCommand)] = c => _moveEngine.ExecuteCommand(c),
                [typeof(TurnClockwiseCommand)] = c => _moveEngine.ExecuteCommand(c)
            };
        }

        public Orientation Orientation => _moveEngine.Orientation;

        public int PositionX => _moveEngine.PositionX;

        public int PositionY => _moveEngine.PositionY;

        public override void ExecuteCommand(CommandBase command)
        {
            base.ExecuteCommand(command);

            var commandType = command.GetType();

            if (!actions.ContainsKey(commandType))
            {
                return;
            }
            try
            {
                actions[commandType](command);
            }
            catch (MapBoundsExceededException )
            {
                throw new TractorInDitchException();
            }
        }

    }
}
