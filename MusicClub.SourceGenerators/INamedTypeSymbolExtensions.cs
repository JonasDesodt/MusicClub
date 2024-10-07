using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicClub.SourceGenerators
{
    public static class INamedTypeSymbolExtensions
    {
        public static IEnumerable<IPropertySymbol> GetProperties(this INamedTypeSymbol namedTypeSymbol)
        {
            while (namedTypeSymbol != null)
            {
                var properties = namedTypeSymbol.GetMembers().OfType<IPropertySymbol>();
                foreach (var property in properties)
                {
                    yield return property;
                }

                namedTypeSymbol = namedTypeSymbol.BaseType;
            }
        }
    }
}
