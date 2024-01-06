using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace CS10_Tests
{
    internal class Attribute_Lambda_Expressions
    {
        public void ExecuteMe()
        {
            var addWithFunc = [return: CustomAttribute("Lambda return attribute")] 
                ([CustomAttribute("1st param")] int a, [CustomAttribute("2nd param")] int b) => a + b;
            //GetTestAttribute<int, int>(addWithFunc)
            //var parameterInfos = addWithFunc.Method.GetParameters();
            //var firstParameterInfo = parameterInfos[0];
            //var attributes = firstParameterInfo.GetCustomAttributes().OfType<CustomAttribute>();
            //var routeAttributes = addWithFunc.Method.GetParameters().GetCustomAttributes().OfType<TestAttribute>();

            var argumentCustomAttributes = CustomAttribute.FindArgumentCustomAttributes(addWithFunc);
            foreach (var argumentAttribute in argumentCustomAttributes)
            {
                if (argumentAttribute.Value != null)
                    Console.WriteLine($"{argumentAttribute.Key}: {argumentAttribute.Value.InnerProperty}");
            }

            //var returnParameterInfo = addWithFunc.Method.ReturnParameter;
            //var attributes2 = returnParameterInfo.GetCustomAttributes();
            var returnValueCustomAttribute = CustomAttribute.FindReturnValueCustomAttributes(addWithFunc);
            if (returnValueCustomAttribute != null)
                Console.WriteLine(returnValueCustomAttribute.InnerProperty);
        }

        //public static TestAttribute GetTestAttribute<T, V>(Expression<Func<T, V>> expression)
        //{
        //    var memberExpression = expression.Body as MemberExpression;
        //    if (memberExpression == null)
        //        throw new InvalidOperationException("Expression must be a member expression");

        //    return GetAttribute<TestAttribute>(memberExpression.Member);
        //}

        //public static T GetAttribute<T>(ICustomAttributeProvider provider)
        //    where T : Attribute
        //{
        //    var attributes = provider.GetCustomAttributes(typeof(T), true);
        //    return attributes.Length > 0 ? attributes[0] as T : null;
        //}
    }

    //public static class ExpressionHelpers
    //{

    //}

    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    public class CustomAttribute: Attribute
    {
        public CustomAttribute(string innerProperty)
        {
            this.InnerProperty = innerProperty;
        }

        public string InnerProperty { get; set; }

        public static IDictionary<string, CustomAttribute?> FindArgumentCustomAttributes(Delegate func)
        {
            return func.Method.GetParameters()
                .Where(p => p.Name != null)
                .ToDictionary(p => $"{p.Name}", p => p.GetCustomAttribute<CustomAttribute>());
        }

        public static CustomAttribute? FindReturnValueCustomAttributes(Delegate func)
        {
            return func.Method.ReturnParameter.GetCustomAttribute<CustomAttribute>();
        }
    }
}
