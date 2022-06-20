using Abstractions;
using UnityEngine;
using Utils;

namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue),
        order = 0)]
    public class AttackableValue : StatelessVariableValue<IAttackable>
    {

    }
}