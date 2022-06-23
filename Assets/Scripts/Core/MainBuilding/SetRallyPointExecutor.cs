using System.Threading.Tasks;
using Abstractions.Commands.CommandInterfaces;

namespace Core.MainBuilding
{
    public class SetRallyPointExecutor : CommandExecutorBase<ISetRallyPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
        {
            GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
        }
    }
}