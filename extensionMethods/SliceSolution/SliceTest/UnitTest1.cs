using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Slice;

namespace SliceTest{
  [TestFixture]
  public class UnitTest1{
    public IEnumerable<string> CreateString( int howMany, int pos ){
      var str = "Io sono una stringa e ho un elemento nella posizione richiesta";
      var i = 32;
      while( true ){
        if( i == 126 )
          i = 32;
        var st = str.Substring( 0, pos );
        var stt = str.Substring( pos, str.Length - ( pos + 1 ) );
        yield return st + (char) i++ + stt;
      }
    }

    public IEnumerable<string> CreateStringWithA( int pos ){
      var str = "";
      var i = 32;
      var x = 0;
      while( true ){
        for( var j = 0; j <= x; j++ )
          str += "a";
        yield return str;
        x++;
        str = "";
      }
    }

    public IEnumerable<string> CreateString42( int pos ){
      var str = "Io sono una stringa e ho un elemento nella";
      var i = 32;
      while( true ){
        if( i == 126 )
          i = 32;
        var st = str.Substring( 0, pos );
        var stt = str.Substring( pos, str.Length - ( pos ) );
        yield return st + (char) i++ + stt;
      }
    }

    [TestCase( 5, 3 )]
    [TestCase( 50, 7 )]
    [TestCase( 500, 20 )]
    public void FirstTest( int howMany, int position ){
      var strings = CreateString( howMany, position );
      var strs = new List<string>( );
      var i = 0;
      foreach( var s in strings ){
        if( i < howMany )
          strs.Add( s );
        else
          break;
        i++;
      }
      var result = new List<string>( );
      var x = 32;
      for( var j = 0; j < howMany; j++ ){
        if( x == 126 )
          x = 32;
        result.Add( ( (char) x++ ).ToString( ) );
      }
      Assert.That( result, Is.EqualTo( strs.Slice( position ) ) );
    }

    [TestCase( 5, 3 )]
    public void SecondTest( int howMany, int position ){
      var str = CreateStringWithA( position );
      var res = new List<string>( );
      var i = 0;
      foreach( var s in str ){
        if( i < 10 )
          res.Add( s );
        else
          break;
        i++;
      }
      Assert.Throws<ArgumentException>( ( ) => res.Slice( position ).ToList( ) );
    }

    [TestCase( 5, 3 )]
    public void ThirdTest( int howMany, int position ){
      var str = CreateString42( position );
      var res = new List<string>( );
      var i = 0;
      foreach( var s in str ){
        if( i < 7000 )
          res.Add( s );
        else
          break;
        i++;
      }
      var result = new List<string>( );
      var x = 32;
      for( var j = 0; j < 7000; j++ ){
        if( x == 126 )
          x = 32;
        result.Add( ( (char) x++ ).ToString( ) );
      }
      Assert.That( result, Is.EqualTo( res.Slice( position ) ) );
    }
  }
}