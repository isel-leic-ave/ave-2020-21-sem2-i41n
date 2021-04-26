
// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Program
{
  .ver 0:0:0:0
}

// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit aula14_intermediate_language.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       33 (0x21)
    .maxstack  3
    .locals init (float64 V_0)
    IL_0000:  nop
    IL_0001:  ldstr      "Module (3,7) = "
    IL_0006:  ldc.i4.3
    IL_0007:  ldc.i4.7
    IL_0008:  call       float64 aula14_intermediate_language.Program::Module(int32,
                                                                              int32)
    IL_000d:  stloc.0
    IL_000e:  ldloca.s   V_0
    IL_0010:  call       instance string [mscorlib]System.Double::ToString()
    IL_0015:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_001a:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_001f:  nop
    IL_0020:  ret
  } // end of method Program::Main

  .method private hidebysig static float64 
          Module(int32 x,
                 int32 y) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  2
    .locals init (int32 V_0,
             int32 V_1,
             float64 V_2)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldarg.0
    IL_0003:  mul
    IL_0004:  stloc.0
    IL_0005:  ldarg.1
    IL_0006:  ldarg.1
    IL_0007:  mul
    IL_0008:  stloc.1
    IL_0009:  ldloc.0
    IL_000a:  ldloc.1
    IL_000b:  add
    IL_000c:  conv.r8
    IL_000d:  call       float64 [mscorlib]System.Math::Sqrt(float64)
    IL_0012:  stloc.2
    IL_0013:  br.s       IL_0015

    IL_0015:  ldloc.2
    IL_0016:  ret
  } // end of method Program::Module

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class aula14_intermediate_language.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file D:\ISEL\pg5 ave - 2020-2021 - 2º sem\aulas-41N\aula14-intermediate-language\App.res
