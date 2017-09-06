namespace DependencyInjection{
  public class FactoryE: EFactory{
    public override IE CreateE( string s ){
      return new E( s );
    }
  }
}