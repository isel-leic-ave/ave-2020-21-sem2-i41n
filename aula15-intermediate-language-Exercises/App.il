.assembly extern mscorlib
{
  .ver 4:0:0:0
}
.assembly App
{
  .ver 0:0:0:0
}

// =============== CLASS MEMBERS DECLARATION ===================

.class private abstract auto ansi sealed beforefieldinit App
       extends [mscorlib]System.Object
{
  .method public hidebysig static int32
          m(int32 a, // arg.0
            int32 b, // arg.1
            int32 c) cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  2
    .locals init (bool V_0,
             int32 V_1,
             bool V_2)
    IL_0000:  nop
    IL_0001:  ldarg.2            // c;
    IL_0002:  ldarg.1            // c; b;
    IL_0003:  cgt                // c > b
    IL_0005:  stloc.0    
    IL_0006:  ldloc.0            // c > b
    IL_0007:  brfalse.s  IL_000d
    IL_0009:  ldc.i4.1           // 1;
    IL_000a:  stloc.1    
    IL_000b:  br.s       IL_001d
    IL_000d:  ldarg.2
    IL_000e:  ldarg.0
    IL_000f:  clt                // c < a;
    IL_0011:  stloc.2
    IL_0012:  ldloc.2            // c < a;    
    IL_0013:  brfalse.s  IL_0019
    IL_0015:  ldc.i4.m1
    IL_0016:  stloc.1
    IL_0017:  br.s       IL_001d
    IL_0019:  ldc.i4.0
    IL_001a:  stloc.1
    IL_001b:  br.s       IL_001d
    IL_001d:  ldloc.1
    IL_001e:  ret
  } // end of method Program::m

  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       15 (0xf)
    .maxstack  8
    ldc.i4.s   12
    ldc.i4.s   21
    ldc.i4.s   19
    call       int32 App::m(int32, int32, int32)
    call       void [mscorlib]System.Console::WriteLine(int32)
    ldc.i4.s   12
    ldc.i4.s   21
    ldc.i4.s   31
    call       int32 App::m(int32, int32, int32)
    call       void [mscorlib]System.Console::WriteLine(int32)
    ldc.i4.s   12
    ldc.i4.s   21
    ldc.i4.s   7
    call       int32 App::m(int32, int32, int32)
    call       void [mscorlib]System.Console::WriteLine(int32)
    ret
  } // end of method App::Main

} // end of class App

