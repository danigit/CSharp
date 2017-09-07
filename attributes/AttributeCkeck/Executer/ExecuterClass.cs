using AttributeChaeck;

namespace Executer{
  public class ExecuterClass{

    [RangeChecked( "first", 10, 1 )]
    [RangeChecked( "second", 5, 2 )]
    public int Method1( int first, int second ){
      return first + second;
    }

    [RangeChecked( "first", 10, 1 )]
    [RangeChecked( "second", 5, 2 )]
    [RangeChecked( "third", 15, 12 )]
    public int Method2( int first, int second, int third ){
      return first + second + third;
    }
  }
}