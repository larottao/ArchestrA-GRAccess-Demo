using ArchestrA.GRAccess;

namespace AvevaGRAccessDemo.Services
{
    public class ParseAttribute
    {
        public static dynamic GetAttributeValue(IAttribute attribute, Boolean isArray)
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