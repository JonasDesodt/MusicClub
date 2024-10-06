using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace MusicClub.SourceGenerators
{
    internal static class ClassDeclarationSyntaxExtensions
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

        public static IEnumerable<string> GetInterfaces(this ClassDeclarationSyntax classDeclaration, Compilation compilation)
        {
            //foreach (var baseTypeSyntax in classDeclaration.BaseList?.Types)
            //{
                var semanticModel = compilation.GetSemanticModel(classDeclaration.SyntaxTree);

                var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;

                foreach(var @interface in classSymbol.Interfaces)
                {
                    yield return @interface.Name;
                }

                //if (baseTypeSyntax.Type.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.ExplicitInterfaceSpecifier))
                //{
                //    yield return baseTypeSyntax.Type.ToString();

                //}

                //if (baseTypeSyntax.Type is IdentifierNameSyntax)// && baseTypeSyntax.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.InterfaceDeclaration))
                //{                   
                //    yield return baseTypeSyntax.Type.ToString();
                //}
           // }
        }

        public static IEnumerable<IPropertySymbol> GetProperties(this ClassDeclarationSyntax classDeclaration, Compilation compilation)
        {
            var semanticModel = compilation.GetSemanticModel(classDeclaration.SyntaxTree);

            var childClassSymbol = semanticModel.GetDeclaredSymbol(classDeclaration) as INamedTypeSymbol;
            var baseClassSymbol = childClassSymbol.BaseType;

            return childClassSymbol.GetMembers().OfType<IPropertySymbol>().Concat(baseClassSymbol?.GetMembers().OfType<IPropertySymbol>() ??  Enumerable.Empty<IPropertySymbol>());

        }
    }
}
