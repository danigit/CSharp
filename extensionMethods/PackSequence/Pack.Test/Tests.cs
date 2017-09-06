using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PackSequence;

namespace Pack.Test{
  [TestFixture]
  public class Tests{
    [Test]
    public void ValidInputWithFiniteSequenceReturnTrue( ){
      var sequence = Enumerable.Range( 1, 17 ).Select( i => i.ToString( ) );
      var packageSize = 5;
      var output = Enumerable.Range( 1, 17 ).Select( i => i.ToString( ) );
      var splited = output.Select( ( x, i ) => new{ Index = i, value = x } ).GroupBy( x => x.Index / packageSize )
                          .Select( x => x.Select( v => v.value ).ToList( ) ).ToList( );
      var last = new List<string>( 5 );
      last.Add( "16" );
      last.Add( "17" );
      last.Add( null );
      last.Add( null );
      last.Add( null );
      splited.RemoveAt( 3 );
      splited.Add( last );
      Assert.That( splited, Is.EqualTo( sequence.Pack( packageSize ) ) );
    }

    [Test]
    public void PackageSizeZeroThrows( ){
      Assert.Throws<ArgumentOutOfRangeException>( ( ) => GetInfiniteSequence( ).Pack( 0 ).ToList( ) );
    }

    [Test]
    public void ValidInputWithInfiniteSequenceReturnTrue( ){
      var sequence = GetInfiniteSequencePippo( );
      var result = new string[10];
      result[0] = "pippo50";
      result[1] = "pippo51";
      result[2] = "pippo52";
      result[3] = "pippo53";
      result[4] = "pippo54";
      result[5] = "pippo55";
      result[6] = "pippo56";
      result[7] = "pippo57";
      result[8] = "pippo58";
      result[9] = "pippo59";
      var i = 0;
      var listResult = new List<String>( );
      foreach( var seq in sequence ){
        listResult.Add( seq );
        i++;
        if( i == 1000 )
          break;
      }
      var packedSequence = new string[10];
      i = 0;
      foreach( var pack in listResult.Pack( 10 ) ){
        if( i == 5 ){
          packedSequence = pack;
          break;
        }
        i++;
      }
      Assert.That( result, Is.EqualTo( packedSequence ) );
    }

    public IEnumerable<string> GetInfiniteSequence( ){
      var i = 0;
      while( true ){
        yield return ( ++i ).ToString( );
      }
    }

    public IEnumerable<string> GetInfiniteSequencePippo( ){
      var i = 0;
      while( true ){
        yield return "pippo" + i++;
      }
    }
  }
}