using AttributeChaeck;

namespace Executer{
  public class ExecuterClass{
    [RangeChecked( "first", 10, 1 )]
    [RangeChecked( "second", 5, 2 )]
    public int Method1( int first, int second ){
      return first + second;
    }
  }
}