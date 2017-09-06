using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorGenericList{
  class IteratorGenericList{
    static void Main( string[] args ){
      Stack<int> theStack = new Stack<int>( );

      for( int numb = 0; numb < 9; numb++ ){
        theStack.Push( numb );
      }

      foreach( int number in theStack ){
        Console.Write( "{0}, ", number );
      }

      Console.WriteLine( );

      foreach( int number in theStack.TopToBottom ){
        Console.Write( "{0} ", number );
      }

      Console.WriteLine( );

      foreach( int number in theStack.BottomToTop ){
        Console.Write( "{0} ", number );
      }

      Console.WriteLine( );

      foreach( int number in theStack.TopN( 7 ) ){
        Console.Write( "{0} ", number );
      }

      Console.ReadKey( );
    }
  }

  public class Stack<T>: IEnumerable<T>{
    private T[] values = new T[100];
    private int top = 0;

    public void Push( T t ){
      values[top] = t;
      top++;
    }

    public T Pop( ){
      top--;
      return values[top];
    }

    public IEnumerator<T> GetEnumerator( ){
      for( int index = top - 1; index >= 0; index-- ){
        yield return values[index];
      }
    }

    //override of the GetEnumerator method from the IEnumerable interface
    IEnumerator IEnumerable.GetEnumerator( ){
      return GetEnumerator( );
    }

    public IEnumerable<T> TopToBottom => this;

    public IEnumerable<T> BottomToTop {
      get{
        for( int index = 0; index < top; index++ ){
          yield return values[index];
        }
      }
    }

    public IEnumerable<T> TopN( int itemsFromTop ){
      int startIndex = itemsFromTop >= top ? 0 : top - itemsFromTop;

      for( int index = top - 1; index >= startIndex; index-- ){
        yield return values[index];
      }
    }
  }
}