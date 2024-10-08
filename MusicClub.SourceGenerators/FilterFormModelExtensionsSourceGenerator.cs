using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class FilterFormModelExtensionsSourceGenerator : ISourceGenerator
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

            foreach (var (blueprint, model) in receiver.GetGenerateParams(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateFilterFormModelExtensions.GenerateFilterFormModelExtensions(string)"))
            {
                if (blueprint == null || model == null)
                {
                    continue;
                }

                var containingNamespace = blueprint.GetContainingNamespace();
                var properties = blueprint.GetProperties(context.Compilation);

                context.AddSource($"{model}FilterFormModelExtensions.g.cs", GetFitlerFormModelExtensionsClass(containingNamespace, model, properties));
            }
        }

        private string GetFitlerFormModelExtensionsClass(string containingNamespace, string model, IEnumerable<IPropertySymbol> properties)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#nullable enable");
            builder.AppendLine();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{"); //open namespace

            builder.AppendLine($"\tpublic static partial class {model}FilterFormModelExtensions");
            builder.AppendLine($"\t{{"); //open class

            builder.AppendLine($"\t\tpublic static {model}FilterRequest? ToRequest(this {model}FilterFormModel formModel)");
            builder.AppendLine($"\t\t{{"); //open method

            builder.AppendLine();
            builder.AppendLine($"\t\t\treturn new {model}FilterRequest");
            builder.AppendLine($"\t\t\t{{");
            foreach (var property in properties)
            {
                builder.AppendLine($"\t\t\t\t{property.Name} = formModel.{property.Name},");
            }
            builder.AppendLine($"\t\t\t}};");
            builder.AppendLine($"\t\t}}"); //close method

            builder.AppendLine($"\t}}"); //close class

            builder.AppendLine($"}}"); // close namespace

            return builder.ToString();
        }

    }
}
