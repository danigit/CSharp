using System;
using System.Collections.Generic;
using System.Linq;
namespace String2BitNamespace{
  public class String2BitClass{
    public static void Main( ){
      var result = String2Bit( "gatto" ).ToList( );
      foreach( var b in result ){
        Console.Write( b + " " );
      }
      Console.ReadKey( );
    }
    public static IEnumerable<bool> String2Bit( string s ){
      var list = new List<string>( );
      foreach( var c in s ){
        var str = Convert.ToString( c, 2 );
        var len = 8 - str.Length;
        var add = "";
        if( len != 0 )
          for( var i = 0; i < len; i++ )
            add += "0";
        str = add + str;
        list.Add( str );
      }
      foreach( var bytese in list )
        foreach( var b in bytese )
          yield return ( (int) b == 49 );
    }
  }
}