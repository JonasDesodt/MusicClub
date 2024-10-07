using Microsoft.CodeAnalysis;

namespace MusicClub.SourceGenerators
{
    public static class SymbolHelper
    {
        public static bool IsObjectType(INamedTypeSymbol namedTypeSymbol, Compilation compilation)
        {
            // Get the special type for System.Object
            var objectTypeSymbol = compilation.GetSpecialType(SpecialType.System_Object);

            // Compare the given type symbol with System.Object
            return SymbolEqualityComparer.Default.Equals(namedTypeSymbol, objectTypeSymbol);
        }
    }
}
