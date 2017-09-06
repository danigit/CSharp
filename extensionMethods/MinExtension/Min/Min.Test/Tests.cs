using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Min.Test{
  [TestFixture]
  public class Tests{
    [Test]
    public void FiniteSequencesReturnTrue( ){
      var left = new[]{ 1, 7, 5, 4, 2, -3, 0 };
      var right = new[]{ 5, 4, 11, 2, -2, 4, -1, 7 };
      var result = new[]{ 1, 4, 5, 2, -2, -3, -1 };
      Assert.That( result, Is.EqualTo( left.MinNum( right ) ) );
    }

    [Test]
    public void RightSequenceShorterThanRightThrows( ){
      var left = GetInfiniteStringSequence( );
      var right = new[]{ "pippo", "pluto", "paperino" };
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => left.MinNum( right ).ToList( ) );
    }

    [TestCase( 8 )]
    public void InfiniteSequencesReturnTrue( int howMany ){
      var left = GetFourMultiples( );
      var right = GetPowerOfTwo( );
      var result = new[]{ 2, 4, 8, 16, 20, 24, 28, 32 };
      var sequence = left.MinNum( right );
      var list = new List<int>( );
      var i = 0;
      foreach( var seq in sequence ){
        if( i == 8 )
          break;
        i++;
        list.Add( seq );
      }
      Assert.That( result, Is.EqualTo( list ) );
    }

    public IEnumerable<string> GetInfiniteStringSequence( ){
      var i = 0;
      while( true ){
        yield return i++.ToString( );
      }
    }

    public IEnumerable<int> GetFourMultiples( ){
      var i = 0;
      while( true ){
        yield return ( i += 4 );
      }
    }

    public IEnumerable<int> GetPowerOfTwo( ){
      var i = 1;
      while( true ){
        yield return ( i *= 2 );
      }
    }
  }
}