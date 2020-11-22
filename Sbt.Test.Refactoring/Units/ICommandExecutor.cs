using Sbt.Test.Refactoring.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Units
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(CommandBase command);
    }
}
