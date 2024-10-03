using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace MusicClub.SourceGenerators.Dto
{
    [Generator]
    internal class DataResultSourceGenerator : DataSourceGeneratorBase
    {
        public override void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxReceiver is ClassDeclarationSyntaxReceiver receiver))
            {
                return;
            }

            foreach (var classDeclaration in GetAnnotatedClasses(receiver, context.Compilation, "MusicClub.Dto.Attributes.GenerateDataResult.GenerateDataResult()"))
            { 
            }

        }

        public override void Initialize(GeneratorInitializationContext context)
        {
            base.Initialize(context);
        }

        private IList<ClassDeclarationSyntax> GetAnnotatedClasses(ClassDeclarationSyntaxReceiver receiver, Compilation compilation, string attributeName)
        {
            var classes = new List<ClassDeclarationSyntax>();

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
                            if (attributeSymbol.ToString() == attributeName)
                            {
                                classes.Add(classDeclaration);
                            }
                        }
                    }
                }
            }

            return classes;
        }
    }
}
