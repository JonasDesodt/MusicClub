using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace MusicClub.SourceGenerators.ApiServices
{
    internal class InterfaceDeclarationSyntaxReceiver : ISyntaxReceiver
    {
        public List<InterfaceDeclarationSyntax> Interfaces { get; } = new List<InterfaceDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is InterfaceDeclarationSyntax interfaceDeclaration)
            {
                Interfaces.Add(interfaceDeclaration);
            }
        }
    }
}
