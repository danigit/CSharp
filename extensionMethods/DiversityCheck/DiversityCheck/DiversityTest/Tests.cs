using System;
using System.Collections.Generic;
using System.Linq;
using DiversityCheck;
using NUnit.Framework;
namespace DiversityTest{
  [TestFixture]
  public class Tests{
    [Test]
    public void FiniteValidSequeceReturnTrue( ){
      var sequence = new[]{ "Paperotto", "", "Paper8" };
      var first = new Diversity( 8, 1, 0 );
      var second = new Diversity( 0, 0, 0 );
      var third = new Diversity( 4, 1, 1 );
      var result = new List<Diversity>{ first, second, third };
      Assert.That( result, Is.EqualTo( sequence.DiversityCheck( ) ) );
    }
    [Test]
    public void FiniteInvalidSequeceThrow( ){
      var seq = new[]{ "Paperotto&!", "&", "Paper8" };
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => seq.DiversityCheck( ).ToList( ) );
    }
    [Test]
    public void InfiniteValidSequeceNotThrow( ){
      var seq = GetInfiniteSeequence( );
      Assert.DoesNotThrow( ( ) => seq.DiversityCheck( ) );
    }
    public IEnumerable<string> GetInfiniteSeequence( ){
      var i = 0;
      while( true ){
        yield return "pluto" + i++;
      }
    }
  }
}