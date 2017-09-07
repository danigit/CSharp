namespace AbstractFactory{

  public abstract class AbstractFactory{

    public abstract IShape CreateShape( string shape );
    public abstract IColor CreateColor( string color );
  }
}