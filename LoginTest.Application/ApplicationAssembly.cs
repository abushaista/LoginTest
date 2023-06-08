using System;
using System.Reflection;

namespace LoginTest.Application;

public static class ApplicationAssembly
{
    public static readonly Assembly Instance = typeof(ApplicationAssembly).Assembly;
}

