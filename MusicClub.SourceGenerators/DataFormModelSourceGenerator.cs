using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class DataFormModelSourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new ClassDeclarationSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is ClassDeclarationSyntaxReceiver receiver))
            {
                return;
            }

            foreach (var (blueprint, model) in receiver.GetGenerateParams(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateDataFormModel.GenerateDataFormModel(string)"))
            {
                if (blueprint == null || model == null)
                {
                    continue;
                }

                var containingNamespace = blueprint.GetContainingNamespace();
                var interfaces = blueprint.GetInterfaces(context.Compilation);
                var properties = blueprint.GetProperties(context.Compilation);

                var source = GetDataFormModelClass(containingNamespace, model, interfaces, properties);

                context.AddSource($"{model}FormModel.g.cs", source);
            }
        }

        public string GetDataFormModelClass(string containingNamespace, string model, IEnumerable<string> interfaces, IEnumerable<IPropertySymbol> properties)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#nullable enable");
            builder.AppendLine();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");

            builder.Append($"\tpublic partial class {model}FormModel");
            if (interfaces.Count() > 0)
            {
                builder.AppendLine($" : {string.Join(", ", interfaces)}");
            }
            builder.AppendLine($"\t{{");
            foreach (var property in properties)
            {
                foreach (var attribute in property.GetAttributes())
                {
                    //System.Runtime.CompilerServices.NullableAttribute
                    //System.ComponentModel.DataAnnotations.NullableAttribute
                    if (!attribute.ToString().Contains("NullableAttribute"))
                    {
                        builder.AppendLine($"\t\t[{attribute}]");
                    }
                }

                builder.AppendLine($"\t\tpublic {property.Type}{(property.Type.NullableAnnotation is NullableAnnotation.NotAnnotated ? "?" : string.Empty)} {property.Name} {{get; set; }}");

                var result = property.Name.Replace("Id", "Result");

                if ((!property.Name.Equals("Id")) && property.Name.EndsWith("Id") && (!properties.Any(p => p.Name.Equals(result))))
                {           
                    builder.AppendLine($"\t\tpublic {result}? {result} {{get; set; }}");
                }
            }
            builder.AppendLine($"\t}}");

            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }
}
