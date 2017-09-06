using System;
using System.Collections.Generic;
namespace SplitAndReverseSolultionNamespace{
  public static class SplitAndReverseClass{
    public static IEnumerable<T> SplitAndReverse<T>( this IEnumerable<T> sequence, int size ){
      if( sequence == null )
        throw new ArgumentNullException( );
      if( size <= 0 )
        throw new ArgumentOutOfRangeException( );
      var enumerator = sequence.GetEnumerator( );
      IList<T> block = new List<T>( );
      var control = 1;
      while( enumerator.MoveNext( ) ){
        block.Add( enumerator.Current );
        while( enumerator.MoveNext( ) ){
          if( control == size )
            break;
          block.Add( enumerator.Current );
          control++;
        }
        for( var i = block.Count - 1; i >= 0; i-- )
          yield return block[i];
        block.Clear( );
        block.Add( enumerator.Current );
        control = 2;
      }
    }
  }
}