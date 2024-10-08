using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicClub.SourceGenerators.ApiServices
{
    [Generator]
    public class ApiServiceSourceGenerator : ISourceGenerator
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

            var (classDeclaration, models) = GetModels(receiver, context.Compilation, "MusicClub.Dto.Attributes.GenerateApiServices.GenerateApiServices(params string[])");
            if (classDeclaration is null)
            {
                return;
            }

            foreach (var model in models)
            {
                context.AddSource($"{model}ApiService.g.cs", GetApiServiceClass(NamespaceHelper.GetContainingNamespace(classDeclaration), model, classDeclaration.Identifier.Text));
            }
        }

        private (ClassDeclarationSyntax, IEnumerable<string>) GetModels(ClassDeclarationSyntaxReceiver receiver, Compilation compilation, string attributeConstructorName)
        {
            var models = new List<string>();

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
                            if (attributeSymbol.ToString() == attributeConstructorName)
                            {

                                if (attributeSymbol != null)
                                {
                                    if (attributeSymbol.ToString() == attributeConstructorName)
                                    {
                                        models.AddRange(attribute.ArgumentList.Arguments
                                            .Select(a => a.Expression is LiteralExpressionSyntax literalExpression
                                            ? literalExpression.Token.ValueText
                                            : a?.ToString() ?? "unknown"));

                                        return (classDeclaration, models);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return (null, models);
        }

        private string GetApiServiceClass(string containingNamespace, string model, string baseClassName)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"#nullable enable");
            builder.AppendLine();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic class {model}ApiService(IHttpClientFactory httpClientFactory) : {baseClassName}<{model}Request,{model}Result, {model}FilterRequest, {model}FilterResult>(httpClientFactory), I{model}Service"); // todo: make the constructor params dynamic
            builder.AppendLine($"\t{{");
            builder.AppendLine($"\t\tprotected override string Endpoint {{ get; }} = \"{model}\";");
            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");

            return builder.ToString();
        }
    }
}
