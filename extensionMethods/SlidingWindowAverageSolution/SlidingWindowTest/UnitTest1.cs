using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SlidingWindowAverage;
namespace SlidingWindowTest{
  [TestFixture]
  public class UnitTest1{
    public IEnumerable<double> CreateSequence( int starting, int length ){
      for( var i = starting; i < length; )
        yield return (double) i++;
    }
    public IEnumerable<double> CreateInfiniteSequence( int starting ){
      for( var i = starting;; )
        yield return (double) i++;
    }
    [TestCase( 3, 5 )]
    [TestCase( 35, 5000 )]
    public void FirstMethod( int windowSize, int numbersLenght ){
      var sequence = CreateSequence( 0, numbersLenght );
      int i = 0;
      var result = new List<double>( );
      foreach( var d in sequence ){
        if( i < numbersLenght )
          result.Add( d );
        else
          break;
      }
      var res = new List<double>( );
      var k = 0;
      var y = 0;
      for( var j = windowSize; j <= numbersLenght; j++ ){
        double partial = 0;
        k = y;
        for( ; k < j; k++ )
          partial += result[k];
        res.Add( partial / windowSize );
        y++;
      }
      Assert.That( res, Is.EqualTo( result.SlidingWindowAverage( windowSize ) ) );
    }
    [TestCase( 0 )]
    public void SecondMethod( int windowSize ){
      var sequence = CreateInfiniteSequence( 100 );
      int i = 0;
      var result = new List<double>( );
      foreach( var d in sequence ){
        if( i < 1000 )
          result.Add( d );
        else
          break;
        i++;
      }
      var res = new List<double>( );
      var k = 0;
      var y = 0;
      for( var j = windowSize; j <= 1000; j++ ){
        double partial = 0;
        k = y;
        for( ; k < j; k++ )
          partial += result[k];
        res.Add( partial / windowSize );
        y++;
      }
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => result.SlidingWindowAverage( windowSize ).ToList( ) );
    }
    [TestCase( 15 )]
    public void ThirdMethod( int windowSize ){
      var sequence = CreateInfiniteSequence( 27 );
      int i = 0;
      var result = new List<double>( );
      foreach( var d in sequence ){
        if( i < 1000 )
          result.Add( d );
        else
          break;
        i++;
      }
      var res = new List<double>( );
      var k = 0;
      var y = 0;
      for( var j = windowSize; j <= 1000; j++ ){
        double partial = 0;
        k = y;
        for( ; k < j; k++ )
          partial += result[k];
        res.Add( partial / windowSize );
        y++;
      }
      Assert.That( res, Is.EqualTo( result.SlidingWindowAverage( windowSize ) ) );
    }
  }
}