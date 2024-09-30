using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class DataControllerSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is DataControllerSyntaxReceiver receiver))
                return;

            var parameters = new Dictionary<string, string>();

            var dataController = receiver.Classes.FirstOrDefault();
            if(dataController == null)
            {
                context.AddSource($"DataController.g.cs", GenerateClass(parameters));

                return;
            }      

            foreach (var (fieldName, model) in dataController.GetFieldsWithPreFetchAttribute())
            {
                parameters[fieldName] = model;
            }

            //var types = new List<string>();
            //var editRazorClasses = receiver.Classes.Where(x => x.Identifier.Text.Equals("Edit", StringComparison.OrdinalIgnoreCase));

            //foreach (var classDeclaration in editRazorClasses)
            //{
            //    var model = context.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);

            //    var classSymbol = model.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;

            //    if (classSymbol == null)
            //        continue;

            //    var classNamespace = classSymbol.ContainingNamespace.ToDisplayString(); // e.g., "MyProject.Models"

            //    if (classNamespace.StartsWith("MusicClub.Cms.Blazor.Pages"))
            //    {
            //        types.Add(classNamespace.Split('.').Last());
            //    }
            //}

            context.AddSource($"DataController.g.cs", GenerateClass(parameters));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new DataControllerSyntaxReceiver());

        }

        private string GenerateRouteHandlers(string name, string type)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"\t\tif(new Regex(@$\"^/{type.ToLower()}/edit/\\d+$\").IsMatch(route))");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\t\treturn await HandleEditRouteMatchFound({name}, route);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tif(new Regex(@$\"^/{type.ToLower()}$\").IsMatch(route))");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\t\treturn await HandleIndexRouteMatchFound({name});");
            builder.AppendLine($"\t\t}}");

            return builder.ToString();
        }

        private string GenerateClass(Dictionary<string, string> parameters)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"using System.Text.RegularExpressions;");
            builder.AppendLine($"\nnamespace MusicClub.Cms.Blazor.Services {{");
            builder.AppendLine($"\tpublic partial class DataController");
            builder.AppendLine($"\t{{");
            builder.AppendLine($"\t\tprotected override partial async Task<bool> HandleRoute(string route)");
            builder.AppendLine($"\t\t{{");

            foreach (var type in parameters)
            {
                builder.Append(GenerateRouteHandlers(type.Key, type.Value));
            }
            builder.AppendLine($"\t\t\treturn true;");
            builder.AppendLine($"\t\t}}");
            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }

    public class RazorClassSyntaxReceiver : ISyntaxReceiver
    {
        //todo: filter on razor.cs classes

        public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                Classes.Add(classDeclaration);
            }
        }
    }

    public class DataControllerSyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                // Example: Collect classes with a specific name
                if (classDeclaration.Identifier.Text == "DataController")
                {

                    Classes.Add(classDeclaration);
                }
            }
        }
    }

    public static class ClassDeclarationExtensions
    {
        public static IEnumerable<(string FieldName, string ModelValue)> GetFieldsWithPreFetchAttribute(
         this ClassDeclarationSyntax classDeclaration)
        {
            // Find all fields in the class
            var fields = classDeclaration.Members.OfType<FieldDeclarationSyntax>();

            foreach (var field in fields)
            {
                // Iterate through each variable declared in the field (in case of multiple variable declarations in one field)
                foreach (var variable in field.Declaration.Variables)
                {
                    // Check if the field has the [PreFetch] attribute
                    var preFetchAttribute = field.AttributeLists
                        .SelectMany(attrList => attrList.Attributes)
                        .FirstOrDefault(attr => attr.Name.ToString() == "PreFetch");

                    // If it has the [PreFetch] attribute, extract the 'Model' property
                    if (preFetchAttribute != null)
                    {
                        // Try to get the named argument for the 'Model' property
                        var modelArgument = preFetchAttribute.ArgumentList?.Arguments
                            .FirstOrDefault()
                            ?.Expression;

                        // If the model argument is found, get its value
                        var modelValue = modelArgument is LiteralExpressionSyntax literalExpression
                            ? literalExpression.Token.ValueText  // Get the value if it's a string literal
                            : modelArgument?.ToString() ?? "unknown";  // Otherwise, get the expression as string


                        var fieldName = variable.Identifier.Text;

                        yield return (fieldName, modelValue);
                    }
                }
            }
        }
    }


}