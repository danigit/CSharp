using System;
using System.Collections.Generic;

namespace PackSequence{
  public static class PackElements{
    public static IEnumerable<T[]> Pack<T>( this IEnumerable<T> elemSeq, int packageSize ) where T : class{
      if( elemSeq == null )
        throw new ArgumentNullException( );
      if( packageSize <= 0 )
        throw new ArgumentOutOfRangeException( );
      var i = 0;
      var package = new T[packageSize];
      var enumerator = elemSeq.GetEnumerator( );
      while( enumerator.MoveNext( ) ){
        package[i++] = enumerator.Current;
        while( enumerator.MoveNext( ) ){
          package[i++] = enumerator.Current;
          if( i == packageSize )
            break;
        }
        while( i < packageSize ){
          package[i++] = null;
        }
        yield return package;
        i = 0;
      }
    }
  }
}