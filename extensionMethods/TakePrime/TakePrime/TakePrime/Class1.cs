using System;
using System.Collections.Generic;

namespace TakePrime{
  public static class TakePrimeClass{
    public static IEnumerable<T> TakePrime<T>( this IEnumerable<T> s, int count ){

      if( s == null)
        throw new ArgumentNullException();
      if(count <= 0)
        throw new ArgumentOutOfRangeException();

      var i = 0;
      var x = 0;

      foreach( var ss in s ){
        if(i == count)
          break;
        if( IsPrime( x++ ) ){
          yield return ss;
          i++;
        }

      }
    }

    public static bool IsPrime(long number) {
      if (number <= 1)
        return false;
      if (number % 2 == 0)
        return number == 2;

      var N = (long) (Math.Sqrt(number) + 0.5);

      for (var i = 3; i <= N; i += 2)
        if (number % i == 0)
          return false;

      return true;
    }
  }
}