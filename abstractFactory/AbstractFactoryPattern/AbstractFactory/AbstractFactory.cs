namespace AbstractFactory{
  public abstract class AbstractFactory{
    public string nuovaStringa = "Ciao mondo";
    public abstract IShape CreateShape( string shape );
    public abstract IColor CreateColor( string color );
  }
}
