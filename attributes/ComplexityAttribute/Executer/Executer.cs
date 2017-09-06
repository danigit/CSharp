
using ComplexityAttribute;

namespace Executer{
  public class ComplexityTest{
    [ComplexityClass( "Class1 Method1", 10 )]
    public string Method1( string str ){
      return "ciao da Method1 Class1";
    }
  }
}