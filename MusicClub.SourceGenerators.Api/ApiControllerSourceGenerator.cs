using Microsoft.CodeAnalysis;
using System.Text;

namespace MusicClub.SourceGenerators.Api
{
    [Generator]
    public class ApiControllerSourceGenerator : ISourceGenerator
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

            var (classDeclaration, models) = receiver.GetModels(context.Compilation, "MusicClub.Api.Attributes.GenerateApiControllers.GenerateApiControllers(string)");
            if (classDeclaration is null)
            {
                return;
            }

            foreach (var model in models)
            {
                context.AddSource($"{model}Controller.g.cs", GetApiControllerClass(classDeclaration.GetContainingNamespace(), model, classDeclaration.Identifier.Text));
            }
        }

        private string GetApiControllerClass(string containingNamespace, string model, string baseClassName)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic class {model}Controller(I{model}Service dbService) : {baseClassName}<{model}Request,{model}Result, {model}FilterRequest, {model}FilterResult>(dbService) {{ }}"); // todo: make the constructor params dynamic
            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }
}
