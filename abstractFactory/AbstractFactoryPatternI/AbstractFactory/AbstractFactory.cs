namespace ArtificialBrainFactory{
  public abstract class AbstractFactory{

    public abstract ISee CreateSee( string what );
    public abstract ISpeak CreateSpeak( string what );
    public abstract IThink CreateThink( string what );
  }
}