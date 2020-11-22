using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring
{
    using Sbt.Test.Refactoring.Units;
    using Sbt.Test.Refactoring.Commands;
    public class Tractor
    {

        readonly Units.Tractor _moveEngine = new Units.Tractor(new Map(5, 5), Orientation.North, new System.Drawing.Point(0, 0));
        //private int[] _position = new int[] { 0, 0 };
        //private int[] _field = new int[] { 5, 5 };
        //private Orientation _orientation = Orientation.North;

        public Orientation Orientation=> _moveEngine.Orientation;

        public void Move(string command)
        {
            if (command == "F")
            {
                _moveEngine.ExecuteCommand(new MoveForwardCommand());
            }
            else if (command == "T")
            {
                _moveEngine.ExecuteCommand(new TurnClockwiseCommand());
            }
        }

        public int GetPositionX() => _moveEngine.PositionX;

        public int GetPositionY() => _moveEngine.PositionY;
    }
}
