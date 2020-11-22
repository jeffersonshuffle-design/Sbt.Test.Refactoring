using Sbt.Test.Refactoring.Commands;
using Sbt.Test.Refactoring.Extensions;

namespace Sbt.Test.Refactoring.Units
{
    public class Wind : UnitBase, IOrientable
    {
        private Orientation orientation;

        public Wind(Map map) : base(map)
        {
            orientation = Orientation.North;
        }

        public Orientation Orientation => orientation;

        public override void ExecuteCommand(CommandBase command)
        {
            base.ExecuteCommand(command);

            if (command.GetType() != typeof(TurnClockwiseCommand))
            {
                return;
            }

            TurnClockwise();
        }

        private void TurnClockwise()
        {
            orientation = orientation.GetNext();
        }
    }
}
