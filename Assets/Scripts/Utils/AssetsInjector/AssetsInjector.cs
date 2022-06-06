using System;
using System.Reflection;

namespace Utils.AssetsInjector
{
    public static class AssetsInjector
    {
        private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);

        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();
            var allFields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            
            foreach (var fieldInfo in allFields)
            {
                if (!(fieldInfo.GetCustomAttribute(_injectAssetAttributeType) is InjectAssetAttribute
                        injectAssetAttribute))
                {
                    continue;
                }

                var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                fieldInfo.SetValue(target, objectToInject);
            }

            return target;
        }
    }
}