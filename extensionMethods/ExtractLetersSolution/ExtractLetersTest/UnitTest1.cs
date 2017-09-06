using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ExtractLetersNamespace;
namespace ExtractLetersTest{
  [TestFixture]
  public class UnitTest1{
    public IEnumerable<List<bool>> ThirdTest( string theWord ){
      while( true ){
        yield return ExtractLetersClass.String2Bit( theWord ).ToList( );
      }
    }
    [Test]
    public void TestMethod1( ){
      var result = ExtractLetersClass.String2Bit( "gatto" ).ToList( );
      Assert.That( "gatto", Is.EqualTo( result.ExtractLeters( ) ) );
    }
    [TestCase( 30, "daniel" )]
    public void TestMethod2( int howMany, string theWord ){
      var list = new List<List<bool>>( );
      var i = 0;
      foreach( var d in ThirdTest( theWord ) ){
        if( i++ < howMany )
          list.Add( d );
        else
          break;
      }
      var result = new List<List<char>>( );
      foreach( var l in list ){
        result.Add( l.ExtractLeters( ).ToList( ) );
      }
      var test = new List<string>( );
      for( var j = 0; j < howMany; j++ )
        test.Add( theWord );
      Assert.That( test, Is.EqualTo( result ) );
    }
    [Test]
    public void TestMethod3( ){
      var result = ExtractLetersClass.String2Bit( "pollivendolo" ).ToList( );
      result.Add( true );
      result.Add( false );
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => result.ExtractLeters( ).ToList( ) );
    }
  }
}