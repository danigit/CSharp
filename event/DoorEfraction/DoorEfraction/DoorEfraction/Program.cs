namespace DoorEfraction{
  internal class Program{
    public static void Main( string[] args ){
      var flat = new Flat(  );
      var securityService = new SecurityService( flat );
      flat.OpenDoor( "1233" );
    }
  }
}