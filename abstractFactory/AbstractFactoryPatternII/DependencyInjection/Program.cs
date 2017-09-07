using System;

namespace DependencyInjection{
  public interface IE{ }

  public class E: IE{
    public string Name { get; }

    public E( string a ){
      Name = a;
    }
  }

  public class C{
    private readonly EFactory _factory;
    public IE MyE { get; }

    public C( string s, EFactory factory ){
      _factory = factory;
      MyE = factory.CreateE( s );
    }

    public IE MM( string ss ){
      return _factory.CreateE( ss );
    }
  }

  internal class Program{
    public static void Main( string[] args ){

      var factory = new FactoryE(  );
      var cClass = new C( "EString", factory );

      Console.WriteLine( "The C class has an object of type: " + cClass.MyE.GetType(  ) + " with name: " + (cClass.MyE as E).Name );

      var eObject = cClass.MM( "Another E object" );
      Console.WriteLine("This is an object created through MM method and has type: " + eObject.GetType(  ) + " with name: " + (eObject as E).Name );
    }
  }
}