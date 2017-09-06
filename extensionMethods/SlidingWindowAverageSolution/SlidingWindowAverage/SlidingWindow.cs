using System;
using System.Collections.Generic;
namespace SlidingWindowAverage{
  public static class SlidingWindow{
    public static IEnumerable<double> SlidingWindowAverage( this IList<double> numbers, int howMany ){
      if( numbers == null )
        throw new ArgumentNullException( );
      if( howMany <= 0 )
        throw new ArgumentOutOfRangeException( );
      if( numbers.Count < howMany )
        throw new ArgumentException( );
      var x = howMany;
      var y = 0;
      for( var i = 0; i < numbers.Count; ){
        double res = 0;
        i = y;
        while( i < x ){
          res += numbers[i]; i++;
        }
        yield return res / howMany;
        x++;  y++;
      }
    }
  }
}