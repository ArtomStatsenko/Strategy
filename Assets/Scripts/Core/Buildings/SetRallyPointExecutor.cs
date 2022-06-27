using System.Threading.Tasks;
using Abstractions.Commands.CommandInterfaces;

namespace Core.Buildings
{
    public class SetRallyPointExecutor : CommandExecutorBase<ISetRallyPointCommand>
    {
        public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
        {
            GetComponent<Buildings.MainBuilding>().RallyPoint = command.RallyPoint;
        }
    }
}