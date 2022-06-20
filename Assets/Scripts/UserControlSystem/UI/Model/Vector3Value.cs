using UnityEngine;
using Utils;

namespace UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public class Vector3Value : StatelessVariableValue<Vector3>
    {

    }
}