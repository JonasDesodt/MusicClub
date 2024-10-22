using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace MusicClub.SourceGenerators.Dto
{
    internal class InterfaceDeclarationSyntaxReceiver : ISyntaxReceiver
    {
        public IList<InterfaceDeclarationSyntax> Interfaces { get; } = new List<InterfaceDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is InterfaceDeclarationSyntax interfaceDeclarationSyntax)
            {
                Interfaces.Add(interfaceDeclarationSyntax);
            }
        }

        public IEnumerable<(InterfaceDeclarationSyntax InterfaceDeclartionSyntax, IList<string> Models)> GetAnnotatedInterfaces(Compilation compilation, string attributeName)
        {
            foreach (var interfaceDeclaration in Interfaces) 
            {
                var models = new List<string>();

                foreach (var attributeList in interfaceDeclaration.AttributeLists)
                {
                    foreach(var attribute in attributeList.Attributes)
                    {
                        var symbol = compilation.GetSemanticModel(attribute.SyntaxTree).GetSymbolInfo(attribute).Symbol;

                        if(symbol != null && symbol.ToString() == attributeName)
                        {
                            models.AddRange(attribute.ArgumentList.Arguments
                                    .Select(a => a.Expression is LiteralExpressionSyntax literalExpression
                                    ? literalExpression.Token.ValueText
                                    : a?.ToString() ?? "unknown"));

                            yield return (interfaceDeclaration, models);
                        }
                    }
                }
            }
        }
    }
}