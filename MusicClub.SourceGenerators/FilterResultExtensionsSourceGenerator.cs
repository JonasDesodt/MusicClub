using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class FilterResultExtensionsSourceGenerator : ISourceGenerator
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

            foreach (var (blueprint, model) in receiver.GetGenerateParams(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateFilterResultExtensions.GenerateFilterResultExtensions(string)"))
            {
                if (blueprint == null || model == null)
                {
                    continue;
                }

                var containingNamespace = blueprint.GetContainingNamespace();
                var properties = blueprint.GetProperties(context.Compilation);

                context.AddSource($"{model}FilterResultExtensions.g.cs", GetDataResultExtensionsClass(containingNamespace, model, properties));
            }
        }

        public string GetDataResultExtensionsClass(string containingNamespace, string model, IEnumerable<IPropertySymbol> properties)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#nullable enable");
            builder.AppendLine();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{"); //open namespace

            builder.AppendLine($"\tpublic static partial class {model}FilterResultExtensions");
            builder.AppendLine($"\t{{"); //open class

            builder.AppendLine($"\t\tpublic static {model}FilterFormModel ToFormModel(this {model}FilterResult result)");
            builder.AppendLine($"\t\t{{"); //open method
            builder.AppendLine($"\t\t\treturn new {model}FilterFormModel");
            builder.AppendLine($"\t\t\t{{");
            foreach (var property in properties)
            {
                builder.AppendLine($"\t\t\t\t{property.Name} = result.{property.Name},");
            }
            builder.AppendLine($"\t\t\t}};");
            builder.AppendLine($"\t\t}}"); //close method

            builder.AppendLine($"\t}}"); //close class

            builder.AppendLine($"}}"); // close namespace

            return builder.ToString();
        }
    }
}
