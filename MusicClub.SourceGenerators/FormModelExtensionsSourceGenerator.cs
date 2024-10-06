using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class FormModelExtensionsSourceGenerator : ISourceGenerator
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

            foreach (var (blueprint, model) in receiver.GetGenerateParams(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateDataFormModelExtensions.GenerateDataFormModelExtensions(string)"))
            {
                if (blueprint == null || model == null)
                {
                    continue;
                }

                var containingNamespace = blueprint.GetContainingNamespace();
                var properties = blueprint.GetProperties(context.Compilation);

                context.AddSource($"{model}FormModelExtensions.g.cs", GetFormModelExtensionsClass(containingNamespace, model, properties));
            }
        }

        private string GetFormModelExtensionsClass(string containingNamespace, string model, IEnumerable<IPropertySymbol> properties)
        {
            var builder = new StringBuilder();


            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{"); //open namespace

            builder.AppendLine($"\tpublic static class {model}FormModelExtensions");
            builder.AppendLine($"\t{{"); //open class

            builder.AppendLine($"\t\tpublic static {model}Request? ToRequest(this {model}FormModel formModel)");
            builder.AppendLine($"\t\t{{"); //open method
            foreach (var property in properties)
            {
                if (property.IsRequired)
                {
                    builder.AppendLine($"\t\t\tif(formModel.{property.Name} is null)");
                    builder.AppendLine($"\t\t\t{{");
                    builder.AppendLine($"\t\t\t\treturn null;");
                    builder.AppendLine($"\t\t\t}}");
                }
            }
            builder.AppendLine();
            builder.AppendLine($"\t\t\treturn new {model}Request");
            builder.AppendLine($"\t\t\t{{");
            foreach (var property in properties)
            {
                if (property.IsRequired)
                {
                    builder.AppendLine($"\t\t\t\t{property.Name} = ({property.Type})formModel.{property.Name},");
                }
                else
                {
                    builder.AppendLine($"\t\t\t\t{property.Name} = formModel.{property.Name},");

                }
            }
            builder.AppendLine($"\t\t\t}};");
            builder.AppendLine($"\t\t}}"); //close method

            builder.AppendLine($"\t}}"); //close class

            builder.AppendLine($"}}"); // close namespace

            return builder.ToString();
        }
    }
}
