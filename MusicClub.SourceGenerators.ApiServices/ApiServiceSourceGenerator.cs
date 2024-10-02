using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

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

            foreach(var interfaceDeclarationSyntax in interfaceDeclarationSyntaxes)
            {
                var semanticModel = context.Compilation.GetSemanticModel(interfaceDeclarationSyntax.SyntaxTree);

              }
        }

        private IList<InterfaceDeclarationSyntax> GetServiceInterfaces(InterfaceDeclarationSyntaxReceiver receiver, Compilation compilation)
        {
            var interfaces = new List<InterfaceDeclarationSyntax>();

            foreach (var classDeclaration in receiver.Interfaces)
            {
                foreach (var attributeList in classDeclaration.AttributeLists)
                {
                    foreach (var attribute in attributeList.Attributes)
                    {
                        var semanticModel = compilation.GetSemanticModel(attribute.SyntaxTree);
                        var attributeSymbol = semanticModel.GetSymbolInfo(attribute).Symbol;

                        if (attributeSymbol != null)
                        {
                            if (attributeSymbol.ToString() == $"MusicClub.Dto.Attributes.GenerateApiService.GenerateApiService()")
                            {
                                interfaces.Add(classDeclaration);
                            }
                        }
                    }
                }
            }

            return interfaces;
        }

    }
}
