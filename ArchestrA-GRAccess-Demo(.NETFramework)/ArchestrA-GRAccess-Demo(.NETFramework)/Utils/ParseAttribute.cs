using ArchestrA.GRAccess;
using System;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    public class ParseAttribute
    {
        public static dynamic GetAttributeValue(IAttribute attribute)
        {
            try
            {
                switch (attribute.DataType)
                {
                    case MxDataType.MxBoolean:
                        return (attribute.value.GetBoolean().ToString());

                    case MxDataType.MxInteger:
                        return (attribute.value.GetInteger().ToString());

                    case MxDataType.MxFloat:
                    case MxDataType.MxDouble:
                        return (attribute.value.GetFloat().ToString());

                    case MxDataType.MxString:
                        return (attribute.value.GetString());

                    default:

                        return ($"[Unsupported Type: {attribute.DataType}]");
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}"; // Customize error for clarity
            }
        }
    }
}