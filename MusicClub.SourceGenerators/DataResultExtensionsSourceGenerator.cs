using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class DataResultExtensionsSourceGenerator : ISourceGenerator
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

            foreach (var (blueprint, model) in receiver.GetGenerateParams(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateDataResultExtensions.GenerateDataResultExtensions(string)"))
            {
                if (blueprint == null || model == null)
                {
                    continue;
                }

                var containingNamespace = blueprint.GetContainingNamespace();
                var properties = blueprint.GetProperties(context.Compilation);

                context.AddSource($"{model}ResultExtensions.g.cs", GetDataResultExtensionsClass(containingNamespace, model, properties));
            }
        }

        public string GetDataResultExtensionsClass(string containingNamespace, string model, IEnumerable<IPropertySymbol> properties)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{"); //open namespace

            builder.AppendLine($"\tpublic static partial class {model}ResultExtensions");
            builder.AppendLine($"\t{{"); //open class

            builder.AppendLine($"\t\tpublic static {model}FormModel ToFormModel(this {model}Result result)");
            builder.AppendLine($"\t\t{{"); //open method
            builder.AppendLine($"\t\t\treturn new {model}FormModel");
            builder.AppendLine($"\t\t\t{{");
            foreach (var property in properties)
            {
                if (property.Name.Equals("Id"))
                {
                    continue;
                }

                if (property.Name.EndsWith("Count"))
                {
                    continue;
                }

                if (property.Name.Equals("Created"))
                {
                    continue;
                }

                if (property.Name.Equals("Updated"))
                {
                    continue;
                }

                if (property.Name.EndsWith("Result"))
                {
                    if(property.NullableAnnotation is NullableAnnotation.Annotated)
                    {
                        builder.AppendLine($"\t\t\t\t{property.Name.Replace("Result", "Id")} = result.{property.Name}?.Id,");
                    }
                    else
                    {
                        builder.AppendLine($"\t\t\t\t{property.Name.Replace("Result", "Id")} = result.{property.Name}.Id,");

                    }
                }

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
