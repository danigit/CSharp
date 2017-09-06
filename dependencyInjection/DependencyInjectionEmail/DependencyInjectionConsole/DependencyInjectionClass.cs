using EmailSenderImplementation1;
using System;
using System.Diagnostics;
using TinyDependencyInjectionContainer;

namespace DependencyInjectionConsole{
  class DependencyInjectionClass{
    static void Main( ){
      var resolver = new InterfaceResolver( "ConfigurationFile.txt" );
      var sender = resolver.Instantiate<ESImplementationOne>( 100, "antaniscapellistuzica" );
      try{
        sender.SendEmail( "pippo", "pluto" );
      } catch( NullReferenceException e ){
        Debug.WriteLine( "Error: Null reference exceptio occured!\nStackTrace: {0}", e.StackTrace );
        Console.ReadLine( );
      }
    }
  }
}