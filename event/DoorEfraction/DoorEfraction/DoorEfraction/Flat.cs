using System;
namespace DoorEfraction{
  public class Flat{
    public event EventHandler ControlDoor;
    private const string Code = "1234";
    private int Attempts;
    public Flat( ){
      Attempts = 1;
    }
    protected virtual void OnDorForced( EventArgs e ){
      ControlDoor?.Invoke( this, e );
    }
    private bool VerifyCode( string code ){
      if(string.IsNullOrEmpty( code ))
        throw new ArgumentException();
      if( code.Equals( Code ) && Attempts <= 3 )
        return true;
      Attempts++;
      return false;
    }
    public void OpenDoor( string code ){
      if( VerifyCode( code ) && Attempts <= 3 ){
        Console.WriteLine( "The dor is opened" );
        Attempts = 1;
      } else if( Attempts > 3 )
        OnDorForced( EventArgs.Empty );
    }
  }
  public class SecurityService{
    private Flat Flat;
    public SecurityService( Flat flat ){
      Flat = flat;
      Flat.ControlDoor += TheDoorHasBeenForced;
    }
    private void TheDoorHasBeenForced( object sender, EventArgs e){
      CallSecurity( (Flat)sender, new DateTime( 2017, 6, 12) );
    }
    public void CallSecurity( Flat toBeCheched, DateTime when ){
      Console.WriteLine( "The security has ben called from " + toBeCheched + " at date " + when );
    }
  }
}