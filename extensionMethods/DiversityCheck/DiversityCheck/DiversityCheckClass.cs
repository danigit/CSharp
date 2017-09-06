using System;
using System.Collections;
using System.Collections.Generic;
namespace DiversityCheck{
  public struct Diversity{
    public int LowerCount { get; private set; }
    public int UpperCount { get; private set; }
    public int DigitCount { get; private set; }
    public Diversity( int lowerCount, int upperCount, int digitCount ){
      LowerCount = lowerCount;
      UpperCount = upperCount;
      DigitCount = digitCount;
    }
  }
  public static class DiversityCheckClass{
    public static IEnumerable<Diversity> DiversityCheck( this IEnumerable<string> alphanumerics ){
      if( alphanumerics == null )
        throw new ArgumentNullException( );
      int lower = 0, upper = 0, digit = 0;
      foreach( var alphanumeric in alphanumerics ){
        if( alphanumeric == null )
          throw new ArgumentNullException( );
        foreach( var chr in alphanumeric ){
          if( !( char.IsLetter( chr ) || char.IsDigit( chr ) ) )
            throw new ArgumentOutOfRangeException( );
          if( char.IsLetter( chr ) && char.IsLower( chr ) )
            lower++;
          else if( char.IsLetter( chr ) && char.IsUpper( chr ) )
            upper++;
          else digit++;
        }
        yield return new Diversity( lower, upper, digit );
        lower = 0;
        upper = 0;
        digit = 0;
      }
    }
  }
}