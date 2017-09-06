namespace AbstractFactory{
  internal class Test{
    public static void Main( string[] args ){

      var shapeFactory = FactoryProducer.GetFactory( "shape" );
      var shapeFactoryColor = FactoryProducer.GetFactory( "color" );

      var shape1 = shapeFactory.CreateShape( "Square" );
      var shape2 = shapeFactory.CreateShape( "REctangle" );
      var shape3 = shapeFactory.CreateShape( "Circle" );

      shape1.Draw( );
      shape2.Draw( );
      shape3.Draw( );

      var color1 = shapeFactoryColor.CreateColor( "Red" );
      var color2 = shapeFactoryColor.CreateColor( "Green" );

      color1.Fill( );
      color2.Fill( );
    }
  }
}
