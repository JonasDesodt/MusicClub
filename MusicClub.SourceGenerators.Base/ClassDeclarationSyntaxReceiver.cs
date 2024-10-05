using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace MusicClub.SourceGenerators.Base
{
   public class ClassDeclarationSyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                Classes.Add(classDeclaration);
            }
        }

        public (ClassDeclarationSyntax, IEnumerable<string>) GetModels(Compilation compilation, string attributeConstructorName)
        {
            var models = new List<string>();

            foreach (var classDeclaration in this.Classes)
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
            return (null, models);
        }
    }
}
