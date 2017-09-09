using System;
using AccessModifiers;
using DifferentDdl;

namespace AccessModifiersTest{
  internal class Program{
    public static void Main( string[] args ){
      var accessModifiers = new DerivedClass( 1, 2, 3, 4, 5 );

      accessModifiers.AccessPublicVar(  );
      accessModifiers.AccessProtectedVar(  );
      accessModifiers.AccessInternalVar(  );
      accessModifiers.AccessProtectedInternalVar(  );
      accessModifiers.AccessoPrivateVar(  );

      Console.WriteLine( "\n\nChanging the dll...\n");
      var differentDll = new DifferentClass( accessModifiers );

      differentDll.AccessPublicVar(  );
      differentDll.AccessOtherThanPublicVar(  );
    }
  }
}