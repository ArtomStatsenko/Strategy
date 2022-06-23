using UnityEngine;

namespace Abstractions.Commands.CommandInterfaces
{
    public interface IProduceUnitCommand : ICommand, IIconHolder
    {
        GameObject UnitPrefab { get; }
        string UnitName { get; }
        float ProductionTime { get; }
    }
}