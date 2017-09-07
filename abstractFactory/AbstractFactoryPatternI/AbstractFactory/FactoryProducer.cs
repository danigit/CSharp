using System;

namespace ArtificialBrainFactory{
  public class ConcreteFactory{

    public static AbstractFactory GetFactory( string type ){
      if( string.IsNullOrEmpty( type ) )
        throw new ArgumentNullException( );

      if( type.Equals( "See", StringComparison.InvariantCultureIgnoreCase ) )
        return new SeeFactory( );
      if( type.Equals( "Speak", StringComparison.InvariantCultureIgnoreCase ) )
        return new SpeakFactory( );
      if( type.Equals( "Think", StringComparison.InvariantCultureIgnoreCase ) )
        return new ThinkFactory( );
      return null;
    }
  }
}