using Microsoft.CodeAnalysis;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class DataResultSelectSourceGenerator : ISourceGenerator
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

            var (classDeclaration, models) = receiver.GetModels(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateDataResultInputs.GenerateDataResultInputs(params string[])");
            if (classDeclaration is null)
            {
                return;
            }

            foreach (var model in models)
            {
                context.AddSource($"{model}{classDeclaration.Identifier.Text}.g.razor.cs", GetCrudLayoutClass(classDeclaration.GetContainingNamespace(), model, classDeclaration.Identifier.Text));
            }
        }

        private string GetCrudLayoutClass(string containingNamespace, string model, string baseClassName)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#nullable enable");
            builder.AppendLine();

            builder.AppendLine($"namespace {containingNamespace.Replace("Shared", model)}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic partial class {model}{baseClassName} : {baseClassName}<{model}Result, {model}FilterRequest>");
            builder.AppendLine($"\t{{");
            builder.AppendLine($"\t\tprotected override string Model => \"{model}\";");
            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }
}