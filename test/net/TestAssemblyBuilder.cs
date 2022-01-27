using System;
using System.Reflection;
using System.Reflection.Emit;

namespace MvvmDialogs
{
    public class TestAssemblyBuilder
    {
        private readonly string assemblyName;
        private readonly AssemblyBuilder assemblyBuilder;
        private readonly ModuleBuilder moduleBuilder;

        public TestAssemblyBuilder(string assemblyName)
        {
            this.assemblyName = assemblyName;
#if !NETCOREAPP
            assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName(assemblyName),
                AssemblyBuilderAccess.RunAndSave);

            moduleBuilder = assemblyBuilder.DefineDynamicModule(
                "MainModule",
                FileName);
#else
            assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run);
            moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
#endif
        }

        public Type? CreateType(string fullName, Type? parenType = null)
        {
            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                fullName,
                TypeAttributes.Public,
                parenType);

            return typeBuilder.CreateType();
        }
        private string FileName => assemblyName + ".dll";

        public Type? GetType(string className) => moduleBuilder.GetType(className);
    }
}
