using System.Threading.Tasks;
using Abstractions.Commands;
using UnityEngine;

namespace Core
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor<T> where T : class, ICommand
    {
        public async Task TryExecuteCommand(object command)
        {
            if (command is T specificCommand)
            {
                await ExecuteSpecificCommand(specificCommand);
            }
        }

        public abstract Task ExecuteSpecificCommand(T command);
    }
}