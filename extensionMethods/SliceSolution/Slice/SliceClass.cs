using System;
using System.Collections.Generic;
using System.Linq;

namespace Slice{
  public static class SliceClass{
    public static IEnumerable<string> Slice( this IList<string> sequence, int position ){
      if( !sequence.Any( ) )
        throw new ArgumentNullException( );
      foreach( var str in sequence ){
        if( str == null )
          throw new ArgumentNullException( );
        if( str.Length < position )
          throw new ArgumentException( );
      }
      if( position < 0 )
        throw new ArgumentOutOfRangeException( );
      foreach( var str in sequence ){
        yield return str.Substring( position, 1 );
      }
    }
  }
}