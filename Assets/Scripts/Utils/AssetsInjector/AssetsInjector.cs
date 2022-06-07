using System;
using System.Reflection;

namespace Utils.AssetsInjector
{
    public static class AssetsInjector
    {
        private static readonly Type _attributeType = typeof(InjectAssetAttribute);

        public static T Inject<T>(this AssetsContext context, T target)
        {
            var targetType = target.GetType();

            while (targetType != null)
            {
                var allFields =
                    targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                foreach (var fieldInfo in allFields)
                {
                    if (fieldInfo.GetCustomAttribute(_attributeType) is InjectAssetAttribute injectAssetAttribute)
                    {
                        var objectToInject =
                            context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
                        fieldInfo.SetValue(target, objectToInject);
                    }
                }

                targetType = targetType.BaseType;
            }

            return target;
        }
    }
}