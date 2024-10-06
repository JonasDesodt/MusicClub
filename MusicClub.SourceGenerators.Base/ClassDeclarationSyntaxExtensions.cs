﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace MusicClub.SourceGenerators.Base
{
    public static class ClassDeclarationSyntaxExtensions
    {
        public static string GetContainingNamespace(this ClassDeclarationSyntax classDeclaration)
        {
            // Traverse up the tree to find the nearest NamespaceDeclarationSyntax
            var namespaceDeclaration = classDeclaration.Ancestors()
                .OfType<BaseNamespaceDeclarationSyntax>() // This covers both NamespaceDeclarationSyntax and FileScopedNamespaceDeclarationSyntax
                .FirstOrDefault();

            if (namespaceDeclaration != null)
            {
                // Retrieve the namespace as a string
                return namespaceDeclaration.Name.ToString();
            }

            // If no namespace is found, it means the class is in the global namespace
            return "global";
        }
    }
}