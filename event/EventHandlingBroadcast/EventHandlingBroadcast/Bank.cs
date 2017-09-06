using System;

namespace EventHandlingBroadcast{
  public class Bank{
    public event EventHandler Spread;

    protected virtual void OnSpread( EventArgs e ){
      Spread?.Invoke( this, e );
    }

    public void AlarmOn( ){
      Console.WriteLine("The allarm is on");
      OnSpread( EventArgs.Empty );
    }

    public void TiefCaptured( ){
      Console.WriteLine("The tief was capturated");
      OnSpread( EventArgs.Empty );
    }
  }
}