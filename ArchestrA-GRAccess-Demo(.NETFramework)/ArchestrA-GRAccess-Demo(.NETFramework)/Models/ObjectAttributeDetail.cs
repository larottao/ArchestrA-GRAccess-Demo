using System;

namespace ArchestrA_GRAccess_Demo_.NETFramework_
{
    public class ObjectAttributeDetail
    {
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string dataType { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public dynamic value { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Name: {name} \n Value {Convert.ToString(value)} \n Type: {dataType}, \n Category: {category}, \n";
        }
    }
}