using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicClub.SourceGenerators.Dto
{
    internal static class IMethodSymbolExtensions
    {
        public static string GetMethodSignature(this IMethodSymbol methodSymbol)
        {
            // Accessibility (e.g., public, private)
            var accessibility = methodSymbol.DeclaredAccessibility.ToString().ToLower();

            // Modifiers (e.g., static, virtual, etc.)
            var modifiers = new List<string>();
            if (methodSymbol.IsStatic) modifiers.Add("static");
            if (methodSymbol.IsAbstract) modifiers.Add("abstract");
            if (methodSymbol.IsVirtual && !methodSymbol.IsAbstract) modifiers.Add("virtual");
            if (methodSymbol.IsOverride) modifiers.Add("override");

            // Return type
            var returnType = methodSymbol.ReturnType.ToDisplayString();

            // Method name
            var methodName = methodSymbol.Name;

            // Parameters
            var parameters = new List<string>();
            foreach (var parameter in methodSymbol.Parameters)
            {
                // Format each parameter as "type name"
                parameters.Add($"{parameter.Type.ToDisplayString()} {parameter.Name}");
            }

            // Join parameters into a single string
            var parameterList = string.Join(", ", parameters);

            // Build the full method signature
            var signature = $"{accessibility} {string.Join(" ", modifiers)} {returnType} {methodName}({parameterList})";

            return signature.Trim(); // Remove excess spaces if no modifiers
        }
        public static string GetInterfaceMethodSignature(this IMethodSymbol methodSymbol)
        {
            var returnType = methodSymbol.ReturnType.ToDisplayString();

            // Get the method name
            var methodName = methodSymbol.Name;

            // Get the parameters
            var parameters = string.Join(", ", methodSymbol.Parameters.Select(p =>
            {
                var parameterType = p.Type.ToDisplayString();
                var parameterName = p.Name;
                return $"{parameterType} {parameterName}";
            }));

            // Build the full method signature
            return $"{returnType} {methodName}({parameters})";
        }  
    }
}
