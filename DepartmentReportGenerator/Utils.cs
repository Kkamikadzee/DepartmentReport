using System;
using System.Reflection;

namespace DepartmentReportGenerator
{
    public static class Utils
    {
        public static bool FileFieldNameStartsWithTypeName(string fieldName, Type type)
        {
            return fieldName.StartsWith($"{type.Name}.") || fieldName.Equals(type.Name);
        }
        
        public static string GetPropertyValueByFormatString(object obj, string format)
        {
            string[] split = format.Split('.');
            Type objType = obj.GetType();
            if (objType.Name != split[0])
            {
                throw new Exception("Invalid format string");
            }

            object subObj = obj;
            for (var i = 1; i < split.Length; i++)
            {
                PropertyInfo property = subObj.GetType().GetProperty(split[i]);
                if (property is null)
                {
                    throw new Exception("Invalid format string");
                }
                subObj = property.GetValue(subObj);
            }

            return subObj.ToString();        
        }
    }
}