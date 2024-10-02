using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
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

            var classDeclarationSyntaxes = GetApiServiceClasses(receiver, context.Compilation);

            foreach (var (attributeSyntax, classDeclarationSyntax) in classDeclarationSyntaxes)
            {
                //var classSemanticModel = context.Compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);

                //todo: search for 'model' arg or '_model' field
                var attributeArgument = attributeSyntax.ArgumentList?.Arguments.FirstOrDefault()?.Expression;
                var model = attributeArgument is LiteralExpressionSyntax literalExpression ? literalExpression.Token.ValueText : attributeArgument?.ToString() ?? "unknown";

                context.AddSource($"{model}ApiService.g.cs", GetApiServiceClass(GetImports(), NamespaceHelper.GetContainingNamespace(classDeclarationSyntax), classDeclarationSyntax.Identifier.Text, model, "MusicClubApi"));
            }
        }

        private IEnumerable<(AttributeSyntax attributeSyntax, ClassDeclarationSyntax classDeclarationSyntax)> GetApiServiceClasses(ClassDeclarationSyntaxReceiver receiver, Compilation compilation)
        {
            //var interfaces = new List<InterfaceDeclarationSyntax>();

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
                            if (attributeSymbol.ToString() == $"MusicClub.Dto.Attributes.GenerateApiService.GenerateApiService(string)")
                            {
                                yield return (attribute, classDeclaration);
                            }
                        }
                    }
                }
            }
        }

        private string GetApiServiceClass(IList<string> importedNamespaces, string containingNamespace, string name, string model, string client)
        {
            var builder = new StringBuilder();

            foreach (var importedNamespace in importedNamespaces)
            {
                builder.AppendLine($"using {importedNamespace};");
            }

            builder.AppendLine();
            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic partial class {name}(IHttpClientFactory httpClientFactory) : I{model}Service");
            builder.AppendLine($"\t{{");

            builder.AppendLine($"\t\tpublic async Task<ServiceResult<{model}Result>> Create({model}Request request)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\treturn await httpClientFactory.Create<{model}Request, {model}Result>(\"{client}\", \"{model}/\", request);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tpublic async Task<ServiceResult<{model}Result>> Delete(int id)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\treturn await httpClientFactory.Delete<{model}Result>(\"{client}\", \"{model}/\", id);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tpublic Task<ServiceResult<bool>> Exists(int id)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\tthrow new NotImplementedException();");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tpublic async Task<ServiceResult<{model}Result>> Get(int id)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\treturn await httpClientFactory.Get<{model}Result>(\"{client}\", \"{model}/\", id);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tpublic async Task<PagedServiceResult<IList<{model}Result>, {model}FilterResult>> GetAll(PaginationRequest paginationRequest, {model}FilterRequest filterRequest)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\treturn await httpClientFactory.GetAll<{model}Result, {model}FilterRequest, {model}FilterResult>(\"{client}\", \"{model}?\", paginationRequest, filterRequest);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tpublic Task<ServiceResult<bool>> IsReferenced(int id)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\tthrow new NotImplementedException();");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t\tpublic async Task<ServiceResult<{model}Result>> Update(int id, {model}Request request)");
            builder.AppendLine($"\t\t{{");
            builder.AppendLine($"\t\t\treturn await httpClientFactory.Update<{model}Request, {model}Result>(\"{client}\", \"{model}/\", id, request);");
            builder.AppendLine($"\t\t}}");

            builder.AppendLine($"\t}}");
            builder.AppendLine($"}}");
            return builder.ToString();
        }

        private IList<string> GetImports()
        {
            return new List<string>(){};
        }    
    }
}
