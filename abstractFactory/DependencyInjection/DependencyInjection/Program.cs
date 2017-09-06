namespace DependencyInjection{
  public interface IE{ }

  public class E: IE{
    public string Name { get; }

    public E( string a ){
      Name = a;
    }
  }

  public class C{
    private readonly EFactory _factory;
    private IE MyE { get; }

    public C( string s, EFactory factory ){
      _factory = factory;
      MyE = factory.CreateE( s );
    }

    public IE MM( string ss ){
      return _factory.CreateE( ss );
    }
  }

  internal class Program{
    public static void Main( string[] args ){ }
  }
}