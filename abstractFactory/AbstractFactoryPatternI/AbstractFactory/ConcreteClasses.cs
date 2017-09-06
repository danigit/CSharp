using System;

namespace ArtificialBrainFactory{
  public class SeeCars: ISee{
    public void See( string what ){
      Console.WriteLine( "I see " + what );
    }
  }

  public class SeeDogs: ISee{
    public void See( string what ){
      Console.WriteLine( "I see " + what );
    }
  }

  public class SeeTrees: ISee{
    public void See( string what ){
      Console.WriteLine( "I see " + what );
    }
  }

  public class SpeakEnglish: ISpeak{
    public void Speak( ){
      Console.WriteLine( "Hi there! I speak english" );
    }
  }

  public class SpeakItalian: ISpeak{
    public void Speak( ){
      Console.WriteLine( "Hi there! I speak Italian" );
    }
  }

  public class SpeakRumenian: ISpeak{
    public void Speak( ){
      Console.WriteLine( "Hi there! I speak Rumenian" );
    }
  }

  public class ThinkAirplains: IThink{
    public void Think( string what ){
      Console.WriteLine( "I think of " + what );
    }
  }

  public class ThinkFriend: IThink{
    public void Think( string what ){
      Console.WriteLine( "I think of " + what );
    }
  }
}