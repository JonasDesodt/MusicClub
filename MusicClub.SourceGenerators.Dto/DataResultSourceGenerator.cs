using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators.Dto
{
    [Generator]
    internal class DataResultSourceGenerator : DataSourceGeneratorBase
    {
        public override void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is ClassDeclarationSyntaxReceiver receiver))
            {
                return;
            }

            foreach (var classDeclaration in GetAnnotatedClasses(receiver, context.Compilation, "MusicClub.Dto.Attributes.GenerateDataResult.GenerateDataResult()"))
            {
                var model = context.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);

                if (!(model.GetDeclaredSymbol(classDeclaration) is INamedTypeSymbol classSymbol))
                {
                    continue;
                }

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

                var containingNamespace = NamespaceHelper.GetContainingNamespace(classDeclaration);
                if (containingNamespace.EndsWith(".Requests"))
                {
                    containingNamespace = containingNamespace.Replace(".Requests", ".Results");
                }
                else
                {
                    containingNamespace += ".Results";
                }

                context.AddSource($"{resultClassName}.g.cs", GenerateDataResultClass(containingNamespace, resultClassName, resultClassName, classProperties));
            }

        }

        public override void Initialize(GeneratorInitializationContext context)
        {
            base.Initialize(context);
        }

        private IList<ClassDeclarationSyntax> GetAnnotatedClasses(ClassDeclarationSyntaxReceiver receiver, Compilation compilation, string attributeName)
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
                            if (attributeSymbol.ToString() == attributeName)
                            {
                                classes.Add(classDeclaration);
                            }
                        }
                    }
                }
            }

            return classes;
        }

        private string GenerateDataResultClass(string classNamespace, string className, string requestClassName, IEnumerable<IPropertySymbol> classProperties)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#nullable enable");
            builder.AppendLine();

            builder.AppendLine($"namespace {classNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic partial class {className}");
            builder.AppendLine($"\t{{");

            builder.AppendLine($"\t\tpublic required int Id {{get; set; }}");

            builder.AppendLine($"\t\tpublic required System.DateTime Created {{get; set; }}");
            builder.AppendLine($"\t\tpublic required System.DateTime Updated {{get; set; }}");

            foreach (var property in classProperties)
            {
                if ((!property.Name.Equals("Id")) && property.Name.EndsWith("Id"))
                {
                    var name = property.Name.Replace("Id", "Result");

                    builder.AppendLine($"\t\tpublic {(property.IsRequired ? "required " : string.Empty)}{name}{(property.Type.NullableAnnotation == NullableAnnotation.Annotated ? "?" : string.Empty)} {name} {{get; set; }}");
                }
                else
                {
                    builder.AppendLine($"\t\tpublic {(property.IsRequired ? "required " : string.Empty)}{property.Type} {property.Name} {{get; set; }}");
                }
            }


            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }
}
