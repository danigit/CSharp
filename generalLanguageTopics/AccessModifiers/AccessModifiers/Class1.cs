using System;

namespace AccessModifiers{
  public class AccessModifiers{
    public int publicVar;
    protected int protectedVar;
    internal int internalVar;
    protected internal int internalProtectedVar;
    private int _privateVar;

    public AccessModifiers( int publ, int protect, int intern, int internProtect, int priv ){
      publicVar = publ;
      protectedVar = protect;
      internalVar = intern;
      internalProtectedVar = internProtect;
      _privateVar = priv;
    }
  }


  public class DerivedClass: AccessModifiers{

    public DerivedClass( int publ, int protect, int intern, int internProtect, int priv ): base( publ, protect, intern, internProtect, priv ){

    }

    public void AccessPublicVar( ){
      Console.WriteLine( "Public var accessed directly from a derived class: " + publicVar);
    }


    public void AccessProtectedVar( ){
      Console.WriteLine( "Protected var accessed directly from a derived class: " + protectedVar);
    }


    public void AccessInternalVar( ){
      Console.WriteLine( "Internal var accessed directly from a derived class: " + internalVar);
    }


    public void AccessProtectedInternalVar( ){
      Console.WriteLine( "ProtectedInternal var accessed directly from a derived class: " + internalProtectedVar);
    }

    public void AccessoPrivateVar( ){
      Console.WriteLine( "The private vars can be accessed directly only from the class who declared them");
    }
  }


}