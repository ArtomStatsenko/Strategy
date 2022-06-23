using System.Threading;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandInterfaces;

namespace Core.UnitCommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }
        
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}