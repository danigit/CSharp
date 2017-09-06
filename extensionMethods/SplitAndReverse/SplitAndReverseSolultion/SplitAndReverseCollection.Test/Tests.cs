using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SplitAndReverseSolultionNamespace;
namespace SplitAndReverseCollection.Test{
  [TestFixture]
  public class Tests{
    [Test]
    public void ValidInputSequenceFromOneToFiftySeven( ){
      var sequence = Enumerable.Range( 1, 57 );
      var block = new List<int>( );
      var blockList = new List<List<int>>( );
      var i = 0;
      foreach( var result in Enumerable.Range( 1, 57 ) ){
        if( i < 10 ){
          block.Add( result );
          i++;
        } else{
          i = 1;
          blockList.Add( Enumerable.Reverse( block ).ToList( ) );
          block.Clear( );
          block.Add( result );
        }
      }
      if( block.Count != 0 )
        blockList.Add( Enumerable.Reverse( block ).ToList( ) );
      var resultList = new List<int>( );
      foreach( var blocks in blockList )
        foreach( var block1 in blocks )
          resultList.Add( block1 );
      Assert.That( sequence.SplitAndReverse( 10 ).ToList( ), Is.EqualTo( resultList ) );
    }
    [Test]
    public void ValidInputSizeZeroThrows( ){
      var sequence = Enumerable.Range( 0, int.MaxValue );
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => sequence.SplitAndReverse( 0 ).ToList( ) );
    }
    [TestCase( 10 )]
    public void ValidStringInfiniteInput( int howMany ){
      var infiniteSequence = CreateInfiniteSequence( );
      var infiniteResultSequence = CreateInfiniteSequence( );
      var i = 0;
      var finiteSequence = new List<string>( );
      foreach( var sec in infiniteSequence ){
        if( i == howMany )
          break;
        finiteSequence.Add( sec );
        i++;
      }
      var block = new List<string>( );
      var blockList = new List<List<string>>( );
      i = 0;
      foreach( var result in finiteSequence ){
        if( i < 4 ){
          block.Add( result );
          i++;
        } else{
          i = 1;
          blockList.Add( Enumerable.Reverse( block ).ToList( ) );
          block.Clear( );
          block.Add( result );
        }
      }
      if( block.Count != 0 )
        blockList.Add( Enumerable.Reverse( block ).ToList( ) );
      var resultList = new List<string>( );
      foreach( var blocks in blockList )
        foreach( var block1 in blocks )
          resultList.Add( block1 );
      i = 0;
      var resultSequence = new List<string>( );
      foreach( var elem in infiniteResultSequence ){
        if( i == howMany )
          break;
        resultSequence.Add( elem ); i++;
      }
      Assert.That( resultSequence.SplitAndReverse( 4 ).ToList( ), Is.EqualTo( resultList ) );
    }
    public IEnumerable<string> CreateInfiniteSequence( ){
      while( true ){
        yield return "pippo";
        yield return "pluto";
        yield return "topolino";
        yield return "paperino";
      }
    }
  }
}