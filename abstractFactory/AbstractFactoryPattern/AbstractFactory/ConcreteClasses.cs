using System;

namespace AbstractFactory{
  public class Red: IColor{
    public void Fill( ){
      Console.WriteLine( "Filling with red" );
    }
  }

  public class Green: IColor{
    public void Fill( ){
      Console.WriteLine( "Filling with Green" );
    }
  }

  public class Circle: IShape{
    public void Draw( ){
      Console.WriteLine( "Drawing a Circle" );
    }
  }

  public class Rectangle: IShape{
    public void Draw( ){
      Console.WriteLine( "Drawing a Rectangle" );
    }
  }

  public class Square: IShape{
    public void Draw( ){
      Console.WriteLine( "Drawing a Square" );
    }
  }
}
