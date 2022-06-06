using System;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = nameof(AssetsContext), menuName = "Strategy Game/" + nameof(AssetsContext), order = 0)]
public class AssetsContext : ScriptableObject
{
    [SerializeField] private Object[] _objects;
    
    public Object GetObjectOfType(Type targetType, string targetName = null)
    {
        foreach (var obj in _objects)
        {
            if (obj.GetType().IsAssignableFrom(targetType))
            {
                if (targetName == null || obj.name == targetName)
                {
                    return obj;
                }
            }
        }

        return null;
    }
}