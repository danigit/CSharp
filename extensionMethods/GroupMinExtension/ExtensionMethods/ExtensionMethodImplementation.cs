using System;
using System.Collections.Generic;
namespace ExtensionMethods{
  public static class ExtensionMethodImplementation{
    public static IEnumerable<int> GroupMin( this IEnumerable<int> individuals, int groupSize ){
      var individ = individuals.GetEnumerator( );
      if( individ == null )
        throw new ArgumentNullException( );
      if( groupSize <= 0 )
        throw new ArgumentOutOfRangeException( );
      var z = 0;
      while( individ.MoveNext( ) ){
        z++;
      }
      if( z % groupSize != 0 )
        throw new ArgumentException( );
      individ.Reset( );
      while( individ.MoveNext( ) ){
        var current = individ.Current;
        for( var i = 0; i < groupSize - 1; i++ ){
          individ.MoveNext( );
          if( individ.Current < current )
            current = individ.Current;
        }
        yield return current;
      }
    }
  }
}