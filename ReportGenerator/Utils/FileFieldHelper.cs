﻿using System;
using System.Linq;
using System.Reflection;
using Cyriller;
using ReportGenerator.Exception;

namespace ReportGenerator.Utils
{
    public static class FileFieldHelper
    {
        public static bool IsFormatField(string fieldName)
        {
            return fieldName[0] == '"';
        }

        public static string GetFieldValue(string fieldName, params object[] objs)
        {
            return IsFormatField(fieldName)
                ? GetFormatFieldValue(fieldName, objs)
                : GetSimpleFieldValue(fieldName, objs);
        }

        private static bool FieldNameStartsWithTypeName(string fieldName, Type type)
        {
            return FieldNameStartsWithMemberName(fieldName, type);
        }

        private static bool FieldNameStartsWithMemberName(string fieldName, MemberInfo memberInfo)
        {
            return !fieldName.IsNullOrEmpty() && (fieldName.StartsWith($"{memberInfo.Name}.") || fieldName.Equals(memberInfo.Name));
        }

        private static object GetPropertyValueByFormatString(object obj, string format, bool skipClassName = false)
        {
            string[] split = format.Split('.');
            Type objType = obj.GetType();
            if (!skipClassName && objType.Name != split[0])
            {
                throw new FileFieldError($"Invalid format string.\n" +
                    $"Type.Name: '{objType.Name}'.\n" +
                    $"Format: '{format}'.");
            }

            object subObj = obj;
            for (var i = 1; i < split.Length; i++)
            {
                PropertyInfo property = subObj.GetType().GetProperty(split[i]);
                if (property is null)
                {
                    throw new FileFieldError($"Invalid format string.\n" +
                        $"Object type name: '{objType.Name}'.\n" +
                        $"Subobject type name: '{subObj.GetType().Name}'.\n" +
                        $"Expected propert name: '{split[i]}'.\n" +
                        $"Format: '{format}'.");
                }
                subObj = property.GetValue(subObj);
            }

            return subObj;
        }

        private static object GetSimpleFieldValueAsObject(string fieldName, object[] objs)
        {
            object fieldValueObj =
                objs.FirstOrDefault(o => FieldNameStartsWithTypeName(fieldName, o.GetType()));

            return fieldValueObj is null ? null : GetPropertyValueByFormatString(fieldValueObj, fieldName);
        }

        private static string GetSimpleFieldValue(string fieldName, object[] objs)
        {
            object fieldValueObj = GetSimpleFieldValueAsObject(fieldName, objs);
            return fieldValueObj is null ? string.Empty : fieldValueObj.ToString();
        }

        private static string GetFormatFieldValue(string fieldName, object[] objs)
        {
            string[] splitColumnName = fieldName.Split('$');
            string format = splitColumnName[0].Trim('"');
            var formatValues = new object[splitColumnName.Length - 1];
            for (var i = 1; i < splitColumnName.Length; ++i)
            {
                formatValues[i - 1] = GetSimpleFieldValueAsObject(splitColumnName[i], objs);
            }

            string result = string.Empty;
            try
            {
                result = string.Format(format, formatValues);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
    }
}