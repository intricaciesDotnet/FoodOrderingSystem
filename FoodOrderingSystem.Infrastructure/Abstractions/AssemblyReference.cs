using System.Reflection;

namespace FoodOrderingSystem.Infrastructure.Abstractions;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
