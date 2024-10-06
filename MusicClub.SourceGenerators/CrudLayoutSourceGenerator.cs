using Microsoft.CodeAnalysis;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class CrudLayoutSourceGenerator : ISourceGenerator
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

            var (classDeclaration, models) = receiver.GetModels(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateLayouts.GenerateLayouts(params string[])");
            if (classDeclaration is null)
            {
                return;
            }

            foreach (var model in models)
            {
                context.AddSource($"{model}{classDeclaration.Identifier.Text}.g.cs", GetCrudLayoutClass(classDeclaration.GetContainingNamespace(), model, classDeclaration.Identifier.Text));
            }
        }

        private string GetCrudLayoutClass(string containingNamespace, string model, string baseClassName)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic class {model}{baseClassName} : {baseClassName}"); 
            builder.AppendLine($"\t{{");
            builder.AppendLine($"\t\tprotected override string Model => \"{model}\";");
            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }
}