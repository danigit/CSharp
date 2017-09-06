using System;
using System.Collections;
namespace EventHandling{
  public class ListWithChangedEvent: ArrayList{
    //the event (delegate) that whill accept registration of methods to be called when somethiing happen
    public event EventHandler Changed;
    //this controll if a method is attached and if so then invokes it
    public virtual void OnChange( EventArgs e ){
      Changed?.Invoke( this, e );
    }
    public override int Add( object value ){
      var i = base.Add( value );
      OnChange( EventArgs.Empty );
      return i;
    }
    public override void Clear( ){
      base.Clear( );
      OnChange( EventArgs.Empty );
    }
    public override object this[ int index ] {
      set{
        base[index] = value;
        OnChange( EventArgs.Empty );
      }
    }
  }
  public class EventListener{
    private ListWithChangedEvent List;
    public EventListener( ListWithChangedEvent list ){
      List = list;
    }
    public void Attach( ){
      List.Changed += new EventHandler( ListChanged );
    }
    public void ListChanged( object sender, EventArgs e ){
      Console.WriteLine( "The event has ben sended from " + sender.ToString( ) + " end eventArgs " + e.ToString( ) );
    }
    public void Detach( ){
      List.Changed -= new EventHandler( ListChanged );
      List = null;
    }
  }
}