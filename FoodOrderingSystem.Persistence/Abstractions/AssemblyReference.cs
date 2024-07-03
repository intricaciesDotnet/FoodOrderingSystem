using System.Reflection;

namespace FoodOrderingSystem.Persistence.Abstractions;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
