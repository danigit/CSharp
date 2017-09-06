using System;
namespace LengthStr{
  public struct LengthStruc{
    private double _length;
    private bool _isMeter;
    public bool IsMeter {
      get{ return _isMeter; }
      set{
        if( _isMeter && !value )
          _length = Math.Round( ( _length / 0.3048 ), 4 );
        if( !_isMeter && value )
          _length = _length * 0.3048;
        _isMeter = value;
      }
    }
    public LengthStruc( double length, bool isMeter = false ){
      _length = length;
      _isMeter = isMeter;
    }
    public static LengthStruc operator +( LengthStruc first, LengthStruc second ){
      if( first.IsMeter && second.IsMeter )
        return new LengthStruc( first._length + second._length, true );
      if( first.IsMeter && !second.IsMeter )
        return new LengthStruc( first._length + ( second._length * 0.3048 ), true );
      if( !first.IsMeter && second.IsMeter )
        return new LengthStruc( first._length * 0.3048 + second._length, true );
      if( !first.IsMeter && !second.IsMeter )
        return new LengthStruc( first._length * 0.3048 + second._length * 0.3048, true );
      throw new ArgumentOutOfRangeException( );
    }
    public static bool operator <( LengthStruc first, LengthStruc second ){
      if( first.IsMeter && second.IsMeter )
        return first._length < second._length;
      if( first.IsMeter && !second.IsMeter )
        return first._length < second._length * 0.3048;
      if( !first.IsMeter && second.IsMeter )
        return first._length * 0.3048 < second._length;
      if( !first.IsMeter && !second.IsMeter )
        return first._length * 0.3048 < second._length * 0.3048;
      throw new ArgumentOutOfRangeException( );
    }
    public static bool operator >( LengthStruc first, LengthStruc second ){
      if( first.IsMeter && second.IsMeter )
        return first._length > second._length;
      if( first.IsMeter && !second.IsMeter )
        return first._length > second._length * 0.3048;
      if( !first.IsMeter && second.IsMeter )
        return first._length * 0.3048 > second._length;
      if( !first.IsMeter && !second.IsMeter )
        return first._length * 0.3048 > second._length * 0.3048;
      throw new ArgumentOutOfRangeException( );
    }
    public static implicit operator LengthStruc( double number ){
      return new LengthStruc( number, true );
    }
    public override string ToString( ){
      return _isMeter ? _length + " m" : _length + " ft";
    }
  }
}