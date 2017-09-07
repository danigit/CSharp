using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCovarianceControvarianc{
  class Mammals{
    public string Name { get; set; }

    public Mammals( string name ){
      Name = name;
    }


  }

  class Dogs: Mammals{
    public Dogs( string name ): base( name ){ }
  }

  //Covariance -> the return type of the method is a derived type from the return type in the delegate signature
  //Contravariance -> the tyepes of parameters of a method are base types of the delegate signature parameter type
  class CovarianceControvariance{
    public delegate Mammals HandlerMethod( );
    public delegate Mammals HandlerMethodWithParam( object mammal );

    public static Mammals MammalsHandler( ){
      return new Mammals( "Thor" );
    }

    public static Mammals MammalMethod( object mammal ) {
      Console.WriteLine( "This is a method with param " + mammal);
      return null;
    }

    public static Dogs DogsHandler( ){
      return new Dogs( "Skik" );
    }

    static void Main( string[] args ){

      HandlerMethod mammalHandler = MammalsHandler;
      HandlerMethodWithParam mammalWithParameter = MammalMethod;
      HandlerMethod dogHandler = DogsHandler;

      var mammal = mammalHandler( );
      var dog = dogHandler( );

      //I can pass a string that is a subtipe of object
      mammalWithParameter( "Lion" );

      Console.WriteLine("This is an object of type " + mammal.GetType(  ) + " and has the name: " + mammal.Name);
      Console.WriteLine("This is an object of type " + dog.GetType(  ) + " and has the name: " + dog.Name);
    }
  }
}