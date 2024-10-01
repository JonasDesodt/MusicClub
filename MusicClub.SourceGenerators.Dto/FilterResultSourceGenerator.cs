using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
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

                var className = classSymbol.Name;
                if (className.Contains("Request"))
                {
                    className = className.Replace("Request", "Result");
                }
                else
                {
                    className += "Result";
                }

                var classProperties = classSymbol.GetMembers().OfType<IPropertySymbol>();

                context.AddSource($"{className}.g.cs", GenerateFilterResultClass("MusicClub.Dto.Filters.GeneratedResults", className, classProperties));
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

        private string GenerateFilterResultClass(string classNamespace, string className, IEnumerable<IPropertySymbol> classProperties)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"using MusicClub.Dto.Filters.Requests;"); //TODO: make dynamic (get all the different namespace from all the annoted filterrequests)
            builder.AppendLine($"using MusicClub.Dto.Results;"); //TODO: make dynamic (get all the different namespace from all the annoted filterrequests)
            builder.AppendLine();
            builder.AppendLine($"namespace {classNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic class {className}");
            builder.AppendLine($"\t{{");

            foreach(var property in classProperties)
            {
                builder.AppendLine($"\t\tpublic {property.Type} {property.Name} {{get; set;}}");

                if((!property.Name.Equals("Id")) && property.Name.EndsWith("Id"))
                {
                    var name = property.Name.Replace("Id", "Result");

                    builder.AppendLine($"\t\tpublic {name}? {name} {{get; set; }}");
                }
            }

            builder.AppendLine($"\t\tpublic {className.Replace("Result", "Request")} ToRequest()");
            builder.AppendLine($"\t\t{{");

            //TEMP HACK
            builder.AppendLine($"\t\t\treturn new {className.Replace("Result", "Request")}();");

            //builder.AppendLine($"\t\t\treturn {className}Extensions.ToRequest(this);");
            
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");
            
            return builder.ToString();
        }
    }
}
