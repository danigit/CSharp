using LengthStr;
using NUnit.Framework;
namespace List.Test{
  [TestFixture]
  public class Tests{
    [Test]
    public void TestIsMeter( ){
      var str = new LengthStruc( 10, true );
      Assert.That( str.ToString( ), Is.EqualTo( "10 m" ) );
    }
    [Test]
    public void TestIsFeetWithNoOptionalParameter( ){
      var str = new LengthStruc( 10 );
      Assert.That( str.ToString( ), Is.EqualTo( "10 ft" ) );
    }
    [Test]
    public void TestIsFeet( ){
      var str = new LengthStruc( 10, false );
      Assert.That( str.ToString( ), Is.EqualTo( "10 ft" ) );
    }
    [Test]
    public void TestLessThanTrue( ){
      var meter = new LengthStruc( 10, true );
      var feet = new LengthStruc( 10, false );
      var result = feet < meter;
      Assert.That( result, Is.EqualTo( true ) );
    }
    [Test]
    public void TestLessThanFalse( ){
      var meter = new LengthStruc( 10, true );
      var feet = new LengthStruc( 10, false );
      var result = meter < feet;
      Assert.That( result, Is.EqualTo( false ) );
    }
    [Test]
    public void TestGreatherThanTrue( ){
      var meter = new LengthStruc( 10, true );
      var feet = new LengthStruc( 10, false );
      var result = meter > feet;
      Assert.That( result, Is.EqualTo( true ) );
    }
    [Test]
    public void TestGreatherThanFalse( ){
      var meter = new LengthStruc( 10, false );
      var feet = new LengthStruc( 10, false );
      var result = feet < meter;
      Assert.That( result, Is.EqualTo( false ) );
    }
    [Test]
    public void TestConvertFromDoubleToLengthStruc( ){
      var doubleVar = 10D;
      var converted = (LengthStruc) doubleVar;
      Assert.AreEqual( converted.GetType( ), typeof( LengthStruc ) );
    }
    [Test]
    public void TestSumOperator( ){
      var meter = new LengthStruc( 10, true );
      var feet = new LengthStruc( 10, false );
      var result = feet + meter;
      Assert.That( result.ToString( ), Is.EqualTo( "13.048 m" ) );
    }
    [Test]
    public void TestIsBoolChangeStructure( ){
      var meter = new LengthStruc( 10, true );
      meter.IsMeter = false;
      Assert.That( meter.ToString( ), Is.EqualTo( "32.8084 ft" ) );
    }
  }
}