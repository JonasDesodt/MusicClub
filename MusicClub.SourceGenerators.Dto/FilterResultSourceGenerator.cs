using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicClub.SourceGenerators.Dto
{
    [Generator]
    public class FilterResultSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is ClassDeclarationSyntaxReceiver receiver))
            {
                return;
            }

            var classDeclarations = GetFilterRequestClasses(receiver, context.Compilation);

            foreach (var classDeclaration in classDeclarations)
            {
                var model = context.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);

                var classSymbol = model.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
                if (classSymbol == null)
                {
                    continue;
                }

                //var classNamespace = classSymbol.ContainingNamespace.ToDisplayString(); 
                var requestClassName = classSymbol.Name;

                var resultClassName = requestClassName;
                if (resultClassName.Contains("Request"))
                {
                    resultClassName = resultClassName.Replace("Request", "Result");
                }
                else
                {
                    resultClassName += "Result";
                }

                var classProperties = classSymbol.GetMembers().OfType<IPropertySymbol>();

                var baseClassSymbol = classSymbol.BaseType;
                IEnumerable<IPropertySymbol> baseClassProperties = new List<IPropertySymbol>();
                //todo: get namespace of the baseclass!!

                //TODO: dynamic NAMESPACES !!

                if (baseClassSymbol != null && !SymbolHelper.IsObjectType(baseClassSymbol, context.Compilation))
                {
                    baseClassProperties = baseClassSymbol.GetMembers().OfType<IPropertySymbol>();
                }

                context.AddSource($"{resultClassName}.g.cs", GenerateFilterResultClass("MusicClub.Dto.Filters.Results", resultClassName, baseClassSymbol.Name, requestClassName, classProperties));

                var allProperties = classProperties.Concat(baseClassProperties);

                context.AddSource($"{resultClassName}Extensions.g.cs", GenerateFilterResultExtensionsClass(requestClassName, resultClassName, allProperties));
           
                context.AddSource($"{requestClassName}Extensions.g.cs", GenerateFilterRequestExtensionsClass(requestClassName, resultClassName, allProperties));
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new ClassDeclarationSyntaxReceiver());
        }

        private IList<ClassDeclarationSyntax> GetFilterRequestClasses(ClassDeclarationSyntaxReceiver receiver, Compilation compilation)
        {
            var classes = new List<ClassDeclarationSyntax>();

            foreach (var classDeclaration in receiver.Classes)
            {
                foreach (var attributeList in classDeclaration.AttributeLists)
                {
                    foreach (var attribute in attributeList.Attributes)
                    {
                        var semanticModel = compilation.GetSemanticModel(attribute.SyntaxTree);
                        var attributeSymbol = semanticModel.GetSymbolInfo(attribute).Symbol;

                        if (attributeSymbol != null)
                        {
                            if (attributeSymbol.ToString() == $"MusicClub.Dto.Attributes.GenerateFilterResult.GenerateFilterResult()")
                            {
                                classes.Add(classDeclaration);
                            }
                        }
                    }
                }
            }

            return classes;
        }

        private string GenerateFilterResultClass(string classNamespace, string className, string baseClassName, string requestClassName, IEnumerable<IPropertySymbol> classProperties)
        {
            var b = " : ";

            var builder = new StringBuilder();
            builder.AppendLine($"using MusicClub.Dto.Abstractions;");
            builder.AppendLine($"using MusicClub.Dto.Filters.Extensions;");
            builder.AppendLine($"using MusicClub.Dto.Filters;");
            builder.AppendLine($"using MusicClub.Dto.Filters.Requests;"); //TODO: make dynamic (get all the different namespace from all the annoted filterrequests)
            builder.AppendLine($"using MusicClub.Dto.Results;"); //TODO: make dynamic (get all the different namespace from all the annoted filterrequests)
            builder.AppendLine();
            builder.AppendLine($"namespace {classNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic class {className}{(string.IsNullOrWhiteSpace(baseClassName) ? string.Empty : b + baseClassName)}, IConvertToRequest<{requestClassName}>");
            builder.AppendLine($"\t{{");

            foreach (var property in classProperties)
            {
                builder.AppendLine($"\t\tpublic {property.Type} {property.Name} {{get; set;}}");

                if ((!property.Name.Equals("Id")) && property.Name.EndsWith("Id"))
                {
                    var name = property.Name.Replace("Id", "Result");

                    builder.AppendLine($"\t\tpublic {name}? {name} {{get; set; }}");
                }
            }

            builder.AppendLine($"\t\tpublic {className.Replace("Result", "Request")} ToRequest()");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\treturn {className}Extensions.ToRequest(this);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }

        private string GenerateFilterResultExtensionsClass(string requestClassName, string resultClassName, IEnumerable<IPropertySymbol> classProperties)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"using MusicClub.Dto.Filters.Requests;"); //TODO: make dynamic (get all the different namespace from all the annoted filterrequests)
            builder.AppendLine($"using MusicClub.Dto.Filters.Results;");
            builder.AppendLine();
            builder.AppendLine($"namespace MusicClub.Dto.Filters.Extensions");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic static class {resultClassName}Extensions");
            builder.AppendLine($"\t{{");
            builder.AppendLine($"\t\tpublic static {requestClassName} ToRequest(this {resultClassName} result)");
            builder.AppendLine($"\t\t{{");

            builder.AppendLine($"\t\t\treturn new {requestClassName} {{");

            foreach (var property in classProperties)
            {
                builder.AppendLine($"\t\t\t\t{property.Name} = result.{property.Name},");
            }

            builder.AppendLine($"\t\t\t}};");
            builder.AppendLine($"\t\t}}");
            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }

        //todo: get the properties of the result
        private string GenerateFilterRequestExtensionsClass(string requestClassName, string resultClassName, IEnumerable<IPropertySymbol> classProperties)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"using MusicClub.Dto.Filters.Requests;"); //TODO: make dynamic (get all the different namespace from all the annoted filterrequests)
            builder.AppendLine($"using MusicClub.Dto.Filters.Results;");
            builder.AppendLine($"using MusicClub.Dto.Results;");
            builder.AppendLine();
            builder.AppendLine($"namespace MusicClub.Dto.Filters.Extensions");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic static class {requestClassName}Extensions");
            builder.AppendLine($"\t{{");
            builder.Append($"\t\tpublic static {resultClassName} ToResult(this {requestClassName} request");
            
            //TODO: only loop once over the classProperties

            foreach (var property in classProperties)
            {
                if ((!property.Name.Equals("Id")) && property.Name.EndsWith("Id"))
                {
                    builder.Append($", {property.Name.Replace("Id", "Result")}? {ConvertFirstLetterToLowerCase(property.Name.Replace("Id", "Result"))} = null");
                }
            }

            builder.Append($")");
            builder.AppendLine($"\n\t\t{{");
            builder.AppendLine($"\t\t\treturn new {resultClassName}");
            builder.AppendLine($"\t\t\t{{");

            foreach (var property in classProperties)
            {
                builder.AppendLine($"\t\t\t\t{property.Name} = request.{property.Name},");

                if ((!property.Name.Equals("Id")) && property.Name.EndsWith("Id"))
                {
                    builder.AppendLine($"\t\t\t\t{property.Name.Replace("Id", "Result")} = {ConvertFirstLetterToLowerCase(property.Name.Replace("Id", "Result"))},");
                }
            }

            builder.AppendLine($"\t\t\t}};");
            builder.AppendLine($"\t\t}}");
            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }

        private static string ConvertFirstLetterToLowerCase(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToLower(input[0]) + input.Substring(1);
        }
    }
}
