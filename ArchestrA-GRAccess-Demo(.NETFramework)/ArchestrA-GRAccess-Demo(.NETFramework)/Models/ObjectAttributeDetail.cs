using System;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    public class ObjectAttributeDetail
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public dynamic Value { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Name: {Name} \n Value {Convert.ToString(Value)} \n Type: {DataType}, \n Category: {Category}, \n";
        }
    }
}