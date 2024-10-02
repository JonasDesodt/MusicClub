using Microsoft.CodeAnalysis;
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
            context.RegisterForSyntaxNotifications(() => new InterfaceDeclarationSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is InterfaceDeclarationSyntaxReceiver receiver))
            {
                return;
            }

            var interfaceDeclarationSyntaxes = GetServiceInterfaces(receiver, context.Compilation);

            foreach (var (attributeSyntax, interfaceDeclarationSyntax) in interfaceDeclarationSyntaxes)
            {
                var interfaceSemanticModel = context.Compilation.GetSemanticModel(interfaceDeclarationSyntax.SyntaxTree);

                //todo: search for 'model' arg or '_model' field
                var attributeArgument = attributeSyntax.ArgumentList?.Arguments.FirstOrDefault()?.Expression;
                var model = attributeArgument is LiteralExpressionSyntax literalExpression ? literalExpression.Token.ValueText : attributeArgument?.ToString() ?? "unknown";

                context.AddSource($"{model}ApiService.g.cs", GetApiServiceClass(GetImports(), "MusicClub.ApiServices", model, "MusicClubApi"));
            }
        }

        private IEnumerable<(AttributeSyntax attributeSyntax, InterfaceDeclarationSyntax inferfaceDeclarationSyntax)> GetServiceInterfaces(InterfaceDeclarationSyntaxReceiver receiver, Compilation compilation)
        {
            //var interfaces = new List<InterfaceDeclarationSyntax>();

            foreach (var interfaceDeclaration in receiver.Interfaces)
            {
                foreach (var attributeList in interfaceDeclaration.AttributeLists)
                {
                    foreach (var attribute in attributeList.Attributes)
                    {
                        var semanticModel = compilation.GetSemanticModel(attribute.SyntaxTree);
                        var attributeSymbol = semanticModel.GetSymbolInfo(attribute).Symbol;

                        if (attributeSymbol != null)
                        {
                            if (attributeSymbol.ToString() == $"MusicClub.Dto.Attributes.GenerateApiService.GenerateApiService(string)")
                            {
                                yield return (attribute, interfaceDeclaration);
                            }
                        }
                    }
                }
            }
        }

        private string GetApiServiceClass(IList<string> importedNamespaces, string containingNamespace, string model, string client)
        {
            var builder = new StringBuilder();

            foreach (var importedNamespace in importedNamespaces)
            {
                builder.AppendLine($"using {importedNamespace};");
            }

            builder.AppendLine();
            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");
            builder.AppendLine($"\tpublic class {model}ApiService(IHttpClientFactory httpClientFactory) : I{model}ApiService");
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
