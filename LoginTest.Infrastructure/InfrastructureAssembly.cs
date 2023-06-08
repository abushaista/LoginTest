using System;
using System.Reflection;

namespace LoginTest.Infrastructure;

public static class InfrastructureAssembly
{
    public static readonly Assembly Instance = typeof(InfrastructureAssembly).Assembly;
}

