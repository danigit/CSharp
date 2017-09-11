using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TakePrime.Test{
  [TestFixture]
  public class Tests{
    [Test]
    public void TestValidInputFiniteSequence( ){
      var sequence = Enumerable.Range( 0, 20 );
      var result = new[]{ 2, 3, 5, 7, 11, 13 };

      Assert.That( result, Is.EqualTo( sequence.TakePrime(6) ) );
    }

    [TestCase(0)]
    public void TestValidInputInfiniteSequenceCountZero( int count ){
      var sequence = GetInfiniteSequance( );

      Assert.Throws<ArgumentOutOfRangeException>( () => sequence.TakePrime(count).ToList(  ) ) ;
    }

    [TestCase( 10 )]
    public void TestValidInputInfiniteSequenceReturnTrue( int size ){
      var sequence = GetInfiniteSequance( );
      var result = sequence.TakePrime( size ).ToList( );
      var ordered = result.OrderBy( e => e );

      Assert.True( result.SequenceEqual( ordered ) );
    }

    public IEnumerable<int> GetInfiniteSequance( ){
      var i = 0;
      while( true ){
        yield return i++;
      }
    }
  }
}