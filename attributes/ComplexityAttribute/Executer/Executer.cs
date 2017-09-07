
using ComplexityAttribute;

namespace Executer{
  public class ExecuterClass{
    [ComplexityClass( "Class1 Method1", 10 )]
    [ComplexityClass( "Class1 Method1", 5 )]
    public string Method1( string str ){
      return "Hello form Method1 Class1";
    }
  }
}