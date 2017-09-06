using System;

namespace AbstractFactory{
  public class FactoryProducer{
    public static AbstractFactory GetFactory( string choice ){
      if( choice.Equals( "Shape", StringComparison.InvariantCultureIgnoreCase ) )
        return new ShapeFactory( );

      if( choice.Equals( "Color", StringComparison.InvariantCultureIgnoreCase ) )
        return new ColorFactory( );

      return null;
    }
  }
}
