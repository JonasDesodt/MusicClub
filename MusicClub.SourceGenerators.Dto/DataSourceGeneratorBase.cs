using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators.Dto
{
    internal abstract class DataSourceGeneratorBase : ISourceGenerator
    {
        public abstract void Execute(GeneratorExecutionContext context);

        public virtual void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new ClassDeclarationSyntaxReceiver());
        }
    }
}
