using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCreateAndMultipleInv{
  class DelegateClass{
    public void Method1( string message ){
      Console.WriteLine( "Message from Method1" );
    }

    public void Method2( string message ){
      Console.WriteLine( "Message from Method2" );
    }

    public static void MethodStatic( string message ){
      Console.WriteLine( "Message from MethodStatic" );
      Console.WriteLine( message );
    }

    public static void MethodWithCallback( int param1, int param2, Del callback ){
      callback( "The number is: " + ( param1 + param2 ).ToString( ) );
    }

    public delegate void Del( string message );


    public static void Main( ){
      DelegateClass obj = new DelegateClass( );

      Del handler = MethodStatic;

      MethodWithCallback( 3, 4, handler );

      handler( "Ciao Mondo!!!" );

      Del d1 = obj.Method1;
      Del d2 = obj.Method2;
      Del d3 = MethodStatic;

      Del allMethodsDelegate = d1 + d2;
      allMethodsDelegate += d3;

      allMethodsDelegate( "antani" );

      allMethodsDelegate -= d1;

      allMethodsDelegate( "scapelli" );

      //getting the number of methods in a delegate's list
      int invocationList = allMethodsDelegate.GetInvocationList( ).GetLength( 0 );
      Console.WriteLine( "The invocatin list length is: " + invocationList );
      Console.ReadLine( );
    }
  }
}