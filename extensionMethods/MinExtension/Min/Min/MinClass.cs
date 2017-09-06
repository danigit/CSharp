using System;
using System.Collections.Generic;
namespace Min{
  public static class MinClass{
    public static IEnumerable<T> MinNum<T>( this IEnumerable<T> leftSeq, IEnumerable<T> rightSeq )
      where T : IComparable<T>{
      if( leftSeq == null || rightSeq == null )
        throw new ArgumentNullException( );
      var enumeratorLeft = leftSeq.GetEnumerator( );
      var enumeratorRight = rightSeq.GetEnumerator( );
      while( enumeratorLeft.MoveNext( ) ){
        if( !enumeratorRight.MoveNext( ) )
          throw new ArgumentOutOfRangeException( );
        if( enumeratorLeft.Current.CompareTo( enumeratorRight.Current ) < 0 ){
          yield return enumeratorLeft.Current;
        } else
          yield return enumeratorRight.Current;
      }
    }
  }
}