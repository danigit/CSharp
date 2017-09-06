using System;
using System.ComponentModel;

namespace AttributeChaeck{
  [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
  public class RangeCheckedAttribute: Attribute{
    public int Maxim;
    public int Minim;
    public string ParamName;

    public RangeCheckedAttribute( string paramName, int maximum, int minimum ){
      if( string.IsNullOrEmpty( paramName ) )
        throw new ArgumentException( );
      if( maximum < minimum )
        throw new ArgumentException( );
      ParamName = paramName;
      Maxim = maximum;
      Minim = minimum;
    }
  }
}