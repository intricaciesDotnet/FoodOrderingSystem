using System.Reflection;

namespace FoodOrderingSystem.Application.Abstractions;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
