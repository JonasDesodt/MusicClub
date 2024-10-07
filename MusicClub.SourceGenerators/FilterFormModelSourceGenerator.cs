﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MusicClub.SourceGenerators
{
    [Generator]
    public class FilterFormModelSourceGenerator : ISourceGenerator
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

            foreach (var (blueprint, model) in receiver.GetGenerateParams(context.Compilation, "MusicClub.Cms.Blazor.Attributes.GenerateFilterFormModel.GenerateFilterFormModel(string)"))
            {
                if (blueprint == null || model == null)
                {
                    continue;
                }

                var containingNamespace = blueprint.GetContainingNamespace();
                var interfaces = blueprint.GetInterfaces(context.Compilation);
                var properties = blueprint.GetProperties(context.Compilation);

                var source = GetDataFormModelClass(containingNamespace, model, interfaces, properties);


                context.AddSource($"{model}test.g.cs", "/*" + source + "*/");

                context.AddSource($"{model}FilterFormModel.g.cs", source);

 
                
            
            }
        }

        public string GetDataFormModelClass(string containingNamespace, string model, IEnumerable<string> interfaces, IEnumerable<IPropertySymbol> properties)
        {
            var builder = new StringBuilder();

            //builder.AppendLine($"#nullable enable");
            //builder.AppendLine();

            builder.AppendLine($"namespace {containingNamespace}");
            builder.AppendLine($"{{");

            builder.Append($"\tpublic partial class {model}FilterFormModel");
            if (interfaces.Count() > 0)
            {
                builder.AppendLine($" : {string.Join(", ", interfaces)}");
            }
            builder.AppendLine($"\t{{");

            foreach (var property in properties)
            {
                var syntax = property.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax(); //todo: also get the props from partials
                if (syntax is PropertyDeclarationSyntax propertyDeclarationSyntax)
                {
                    builder.AppendLine($"\t\t{propertyDeclarationSyntax}");
                    builder.AppendLine();
                }

                if (property.Name.EndsWith("Id") && !property.Name.Equals("Id") && (!properties.Any(p => p.Name.Equals(property.Name.Replace("Id", "Result")))))
                {
                    builder.AppendLine($"\t\tpublic {property.Name.Replace("Id", "Result")}? {property.Name.Replace("Id", "Result")} {{get; set; }}");
                    builder.AppendLine();
                }


            }

            builder.AppendLine($"\t}}");

            builder.AppendLine($"}}");

            return builder.ToString();
        }

    }
}
