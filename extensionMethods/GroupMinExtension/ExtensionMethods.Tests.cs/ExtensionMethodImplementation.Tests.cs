using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ExtensionMethods.Tests.cs{
  [TestFixture]
  class ExtensionMethodImplementation{
    public IEnumerable<int> GetInfiniteSequence( int from ){
      for( var i = from;; i++ )
        if( i % 2 == 0 )
          yield return i;
    }
    public IEnumerable<int> GetInfiniteNaturalSequence( int from ){
      for( var i = from;; i++ )
        yield return i;
    }
    [TestCase( 5, 3 )]
    public void GroupMinTest( int size, int groupNumber ){
      List<int> individuals = Enumerable.Range( 0, groupNumber * size ).ToList( );
      var result = individuals.GroupMin( size );
      Assert.That( result, Is.EqualTo( new List<int>( ){ 0, 5, 10 } ) );
    }
    [TestCase( -1, 100 )]
    public void GroupMinThrowArgumentAoutOfRangeException( int size, int groupNumber ){
      var res = new List<int>( );
      var z = 0;
      foreach( var i in GetInfiniteNaturalSequence( groupNumber ) ){
        if( z++ < 100 )
          res.Add( i );
        else
          break;
      }
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => res.GroupMin( size ).ToList( ) );
    }
    [TestCase( 2, 5 )]
    public void GroupMinEvenNumbers( int size, int groupNumber ){
      var res = GetInfiniteSequence( 42 );
      var fin = new List<int>( );
      var expected = new List<int>( );
      var z = 0;
      foreach( var i in res ){
        if( z < 3330 )
          fin.Add( i );
        else
          break;
        z++;
      }
      var y = 0;
      for( var i = 0; i < 3330; i++ ){
        if( fin[i] == 42 + y * groupNumber ){
          expected.Add( fin[i] );
          y += 2;
        }
      }
      fin = fin.GroupMin( groupNumber ).ToList( );
      Assert.That( fin, Is.EqualTo( expected ) );
    }
  }
}