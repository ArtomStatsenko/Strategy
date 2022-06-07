using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils.AssetsInjector
{
    [CreateAssetMenu(fileName = nameof(AssetsContext), menuName = "Strategy Game/" + nameof(AssetsContext), order = 0)]
    public class AssetsContext : ScriptableObject
    {
        [SerializeField] private Object[] _objects;

        public Object GetObjectOfType(Type targetType, string targetName = null)
        {
            return _objects.Where(obj => obj.GetType().IsAssignableFrom(targetType))
                .FirstOrDefault(obj => targetName == null || obj.name == targetName);
        }
    }
}