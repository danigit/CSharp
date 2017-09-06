using System;

namespace ComplexityAttribute{
  [AttributeUsage( AttributeTargets.Method, Inherited = true, AllowMultiple = true )]
  public class ComplexityClassAttribute: Attribute{
    public string Author;
    public int Complexity;

    public ComplexityClassAttribute( string author, int complexity ){
      Author = author;
      Complexity = complexity;
    }
  }
}