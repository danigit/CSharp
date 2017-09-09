﻿using System;
using Relations;

namespace RelationsTest{
  public class Test{
    public static void Main( string[] args ){

      var relations = new Relations<int,int>(  );

      relations.AddLink( 1, 2 );
      relations.AddLink( 1, 3 );
      relations.AddLink( 2, 4 );
      relations.AddLink( 2, 5 );
      relations.AddLink( 3, 6 );
      relations.AddLink( 4, 7 );
      relations.AddLink( 4, 8 );
      relations.AddLink( 4, 9 );
      relations.AddLink( 5, 1 );
      relations.AddLink( 6, 0 );
      relations.AddLink( 7, 10 );

      Console.WriteLine( relations.ToString(  ));

      Console.WriteLine( "The remove has returned: " + relations.RemoveLink( 1, 3 ));
      Console.WriteLine( "The remove has returned: " + relations.RemoveLink( 3, 6 ));

      Console.WriteLine( relations.ToString(  ));

      Console.Write("Domain => ");
      foreach( var i in relations.GetDomain(  ) ){
        Console.Write( i + ", " );
      }

      Console.WriteLine();
      Console.Write( "Codomain => " );
      foreach( var i in relations.GetCodomain(  ) ){
        Console.Write( i + " " );
      }

      Console.WriteLine();
      Console.Write( "Relations of 4 => ");
      foreach( var i in relations.GetRelationsOfT1( 4 ) ){
        Console.Write( i + " " );
      }

      var compose = new Relations<int, string>();

      compose.AddLink( 1, "uno" );
      compose.AddLink( 4, "due" );
      compose.AddLink( 4, "tre" );
      compose.AddLink( 6, "quattro" );
      compose.AddLink( 6, "cinque" );

      Console.WriteLine();
      Console.WriteLine( relations.Compose( compose ));
    }
  }
}