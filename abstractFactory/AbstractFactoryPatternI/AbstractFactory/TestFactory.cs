namespace ArtificialBrainFactory{
  internal class Program{
    public static void Main( string[] args ){
      var concreteFactorySee = ConcreteFactory.GetFactory( "See" );
      var concreteFactorySpeak = ConcreteFactory.GetFactory( "Speak" );
      var concreteFactoryThink = ConcreteFactory.GetFactory( "Think" );

      var seeCars = concreteFactorySee.CreateSee( "cars" );
      var seeDogs = concreteFactorySee.CreateSee( "dogs" );
      var seeTrees = concreteFactorySee.CreateSee( "trees" );

      var speakEnglish = concreteFactorySpeak.CreateSpeak( "english" );
      var speakItalian = concreteFactorySpeak.CreateSpeak( "italian" );
      var speckRumenian = concreteFactorySpeak.CreateSpeak( "rumenian" );

      var thinkAiplains = concreteFactoryThink.CreateThink( "airplains" );
      var thinkFriend = concreteFactoryThink.CreateThink( "friend" );

      seeCars.See( "panda" );
      seeDogs.See( "pitbull" );
      seeTrees.See( "pine" );

      speakEnglish.Speak( );
      speakItalian.Speak( );
      speckRumenian.Speak( );

      thinkAiplains.Think( "boing" );
      thinkFriend.Think( "Costel" );
    }
  }
}