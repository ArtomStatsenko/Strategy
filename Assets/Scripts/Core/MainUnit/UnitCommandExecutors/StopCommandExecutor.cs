using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands.CommandInterfaces;

namespace Core.MainUnit.UnitCommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        public override async Task ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}