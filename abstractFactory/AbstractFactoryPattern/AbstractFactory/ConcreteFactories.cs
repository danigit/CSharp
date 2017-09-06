using System;

namespace AbstractFactory{
  public class ColorFactory: AbstractFactory{
    public override IShape CreateShape( string shape ){
      return null;
    }

    public override IColor CreateColor( string color ){
      if( color == null )
        return null;
      if( color.Equals( "Red", StringComparison.InvariantCultureIgnoreCase ) )
        return new Red( );
      if( color.Equals( "Green", StringComparison.InvariantCultureIgnoreCase ) )
        return new Green( );

      return null;
    }
  }

  public class ShapeFactory: AbstractFactory{
    public override IShape CreateShape( string shape ){
      if( shape == null )
        return null;
      if( shape.Equals( "Circle", StringComparison.CurrentCultureIgnoreCase ) )
        return new Circle( );
      if( shape.Equals( "Rectangle", StringComparison.CurrentCultureIgnoreCase ) )
        return new Rectangle( );
      if( shape.Equals( "Square", StringComparison.CurrentCultureIgnoreCase ) )
        return new Square( );
      return null;
    }

    public override IColor CreateColor( string color ){
      return null;
    }
  }
}
