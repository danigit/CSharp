using System;
using System.Collections.Generic;

namespace ExtractLetersNamespace{
  public static class ExtractLetersClass{
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
    public static IEnumerable<char> ExtractLeters( this IList<bool> s ){
      if( s == null )
        throw new ArgumentNullException( );
      if( ( s.Count % 8 ) != 0 )
        throw new ArgumentOutOfRangeException( );
      for( var i = 0; i < s.Count; i += 8 ){
        var list = new List<int>( );
        for( var j = i; j < i + 8; j++ )
          list.Add( s[j] ? 1 : 0 );
        var str = Convert.ToInt32( String.Join( "", list.ToArray( ) ), 2 );
        var sst = Convert.ToChar( str );
        if( !Char.IsLetter( sst ) )
          throw new ArgumentOutOfRangeException( );
        yield return sst;
      }
    }
  }
}