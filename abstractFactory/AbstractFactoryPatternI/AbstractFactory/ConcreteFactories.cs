using System;

namespace ArtificialBrainFactory{
  public class SeeFactory: AbstractFactory{
    public override ISee CreateSee( string what ){
      if( string.IsNullOrEmpty( what ) )
        throw new ArgumentNullException( );

      if( what.Equals( "Cars", StringComparison.InvariantCultureIgnoreCase ) )
        return new SeeCars( );
      if( what.Equals( "Dogs", StringComparison.InvariantCultureIgnoreCase ) )
        return new SeeDogs( );
      if( what.Equals( "Trees", StringComparison.InvariantCultureIgnoreCase ) )
        return new SeeTrees( );
      return null;
    }

    public override ISpeak CreateSpeak( string what ){
      return null;
    }

    public override IThink CreateThink( string what ){
      return null;
    }
  }

  public class SpeakFactory: AbstractFactory{
    public override ISee CreateSee( string what ){
      throw new System.NotImplementedException( );
    }

    public override ISpeak CreateSpeak( string what ){
      if( string.IsNullOrEmpty( what ) )
        throw new ArgumentNullException( );

      if( what.Equals( "English", StringComparison.InvariantCultureIgnoreCase ) )
        return new SpeakEnglish( );
      if( what.Equals( "Italian", StringComparison.InvariantCultureIgnoreCase ) )
        return new SpeakItalian( );
      if( what.Equals( "Rumenian", StringComparison.InvariantCultureIgnoreCase ) )
        return new SpeakRumenian( );
      return null;
    }

    public override IThink CreateThink( string what ){
      throw new System.NotImplementedException( );
    }
  }

  public class ThinkFactory: AbstractFactory{
    public override ISee CreateSee( string what ){
      return null;
    }

    public override ISpeak CreateSpeak( string what ){
      return null;
    }

    public override IThink CreateThink( string what ){
      if( string.IsNullOrEmpty( what ) )
        throw new ArgumentNullException( );

      if( what.Equals( "Airplains", StringComparison.InvariantCultureIgnoreCase ) )
        return new ThinkAirplains( );
      if( what.Equals( "Friend", StringComparison.InvariantCultureIgnoreCase ) )
        return new ThinkFriend( );
      return null;
    }
  }
}