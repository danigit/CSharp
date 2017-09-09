using NUnit.Framework;

namespace ElementaryExamples.Test{
  [TestFixture]
  public class Tests{
    [Test]
    public void BoxingFromIntToObject( ){
      int val = 10;
      object obj = val;

      Assert.True( obj.Equals( 10 ) );
    }

    [Test]
    public void UnboxingFromObjectToInt( ){
      object obj = new object( );
      obj = 10;

      int val = (int)obj;

      Assert.True( val == 10 );
    }

    [Test]
    public void BoxingFromStringToObject( ){
      string val = "hello";
      object obj = val;

      Assert.True( obj.Equals( "hello" ) );
    }

    [Test]
    public void UnboxingFromObjectToString( ){
      object obj = new object(  );
      obj = "hello";

      string val = (string) obj;

      Assert.True( val.Equals( "hello" ) );
    }
  }
}