using System;
namespace EventHandling{
  internal class Program{
    public static void Main( string[] args ){
      var list = new ListWithChangedEvent(  );
      var listener = new EventListener( list );
      list.Changed += Generate;
      list.Add( "item 1" );
      list.Clear(  );
    }
    public static void Generate( object sender, EventArgs e ){
      Console.WriteLine("Ciao Mondo!");
    }
  }
}