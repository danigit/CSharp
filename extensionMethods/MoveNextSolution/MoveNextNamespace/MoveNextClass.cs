using System.Collections.Generic;
using System.Linq;
namespace MoveNextNamespace{
  public class MoveNextClass{
    public static bool MoveNext_OutCurr<T>( IEnumerator<T>[] enumerators, out T[] currents ){
      currents = new T[enumerators.Length];
      for( var i = 0; i < enumerators.Length; i++ ){
        if( enumerators[i].MoveNext( ) ){
          currents[i] = enumerators[i].Current;
        } else
          return false;
      return true;
    }
     IEnumerator<T>[] GetEnumeratorList<T>( ){
      var first = Enumerable.Range( 10, 1000 ).Where( x => x == 10 || x == 100 || x == 1000 ).GetEnumerator( );
      var second = Enumerable.Range( 20, 200 ).Where( x => x == 20 || x == 200 ).ToString( ).GetEnumerator( );
      var third = Enumerable.Range( 30, 1000 ).Where( x => x == 30 || x == 300 || x == 3000 ).GetEnumerator( );
      var list = new IEnumerator<T>[3];
      list[0] = (IEnumerator<T>) first;
      list[1] = second as IEnumerator<T>;
      list[2] = (IEnumerator<T>) third;
      return list;
    }
  }
  public class Test{
    static void Main( string[] args ){
      foreach( var current in currents ){
        MoveNextClass.MoveNext_OutCurr( list, out currents );
      }
    }
  }
}