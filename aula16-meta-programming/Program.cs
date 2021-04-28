using System;
using System.Reflection;
using System.Reflection.Emit;

namespace aula16_meta_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Type dynType = BuildAssemblyAndType();
            //
            // new MyDynamicType(7).MyMethod(5)
            // 
            object obj = Activator.CreateInstance(dynType, new object[]{7});
            object res = dynType
                .GetMethod("MyMethod", new Type[]{ typeof(int)}) // Get the MethodInfo of MyMethod
                .Invoke(obj, new object[]{5});                   // Invoke that MethodInfo
            Console.WriteLine("new MyDynamicType(7).MyMethod(5) --> " + res);
            //
            // TPC: new MyDynamicType(7).MyMethod(new MyDynamicType(9))
            //
            /* 
            object other = Activator.CreateInstance(dynType, new object[]{9});
            object res2 = dynType
                .GetMethod("MyMethod", new Type[]{ dynType }) // Get the MethodInfo of MyMethod
                .Invoke(obj, new object[]{other});            // Invoke that MethodInfo
            Console.WriteLine("new MyDynamicType(7).MyMethod(new MyDynamicType(9)) --> " + res2);
            */
        }

        private static Type BuildAssemblyAndType()
        {
            AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);

            // For a single-module assembly, the module name is usually
            // the assembly name plus an extension.
            ModuleBuilder mb =
                ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

            return BuildType(mb);
        }

        private static Type BuildType(ModuleBuilder mb)
        {
            TypeBuilder tb = mb.DefineType(
            "MyDynamicType",
             TypeAttributes.Public);

            // Add a private field of type int (Int32).
            FieldBuilder fbNumber = tb.DefineField(
                "m_number",
                typeof(int),
                FieldAttributes.Private);

            BuildConstructor(tb, fbNumber);
            BuildMethod(tb, fbNumber);
            BuildMethod2(tb, fbNumber);

             // Finish the type.
            Type t = tb.CreateType();
            return t;
        }

        private static void BuildMethod(TypeBuilder tb, FieldBuilder fbNumber)
        {
            // Define a method that accepts an integer argument and returns
            // the product of that integer and the private field m_number. This
            // time, the array of parameter types is created on the fly.
            MethodBuilder meth = tb.DefineMethod(
                "MyMethod",
                MethodAttributes.Public,
                typeof(int),
                new Type[] { typeof(int) });

            ILGenerator methIL = meth.GetILGenerator();
            // To retrieve the private instance field, load the instance it
            // belongs to (argument zero). After loading the field, load the
            // argument one and then multiply. Return from the method with
            // the return value (the product of the two numbers) on the
            // execution stack.
            methIL.Emit(OpCodes.Ldarg_0);         // this
            methIL.Emit(OpCodes.Ldfld, fbNumber); // this.m_number
            methIL.Emit(OpCodes.Ldarg_1);         // this.m_number; arg;
            methIL.Emit(OpCodes.Mul);             // this.m_number * arg
            methIL.Emit(OpCodes.Ret);
        }

        // MyMethod(MyDynamicType other) { return this.m_number * other.m_number; }
        private static void BuildMethod2(TypeBuilder tb, FieldBuilder fbNumber)
        {
        }
        private static void BuildConstructor(TypeBuilder tb, FieldBuilder fbNumber)
        {
            // Define a constructor that takes an integer argument and
            // stores it in the private field.
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = tb.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                parameterTypes);

            ILGenerator ctor1IL = ctor1.GetILGenerator();
            // For a constructor, argument zero is a reference to the new
            // instance. Push it on the stack before calling the base
            // class constructor. Specify the default constructor of the
            // base class (System.Object) by passing an empty array of
            // types (Type.EmptyTypes) to GetConstructor.
            ctor1IL.Emit(OpCodes.Ldarg_0); // push this
            ctor1IL.Emit(OpCodes.Call,     // base()
                typeof(object).GetConstructor(new Type[0]));
            // Push the instance on the stack before pushing the argument
            // that is to be assigned to the private field m_number.
            ctor1IL.Emit(OpCodes.Ldarg_0);         // push this
            ctor1IL.Emit(OpCodes.Ldarg_1);         // push arg
            ctor1IL.Emit(OpCodes.Stfld, fbNumber); // this.m_number = arg
            ctor1IL.Emit(OpCodes.Ret);
        }
    }
}
