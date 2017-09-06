using ConstructorAttribute;
using MyAttribute;
using System;
namespace MyLibrary{
  public class Foo{
    public string Str;
    public int Num;
    [ConstructMe( "Ciao", 10 )]
    public Foo( string str, int num ){
      Str = str;Num = num;
    }
    [ExecuteMe]
    public void M1( ){
      Console.WriteLine( "M1 with " + Str + " " + Num );
    }
    [ExecuteMe( 45 )]
    [ExecuteMe( 0 )]
    [ExecuteMe( 3 )]
    public void M2( int a ){
      Console.WriteLine( "M2 a={0}", a );
    }
    [ExecuteMe( "hello", "reflection", Number = 25 )]
    public void M3( string s1, string s2 ){
      Console.WriteLine( "M3 s1={0} s2={1}", s1, s2 );
    }
  }
  public class Too{
    private int Param;
    [ConstructMe( 3 )]
    public Too( int param ){
      this.Param = param;
    }
    [ExecuteMe]
    public void T1( ){
      Console.WriteLine( "T1" );
    }
    [ExecuteMe( 45 )]
    [ExecuteMe( 0 )]
    [ExecuteMe( 3 )]
    [ExecuteMe( "tre" )]
    public void T2( int a ){
      Console.WriteLine( "T2 a={0}, Param={1}", a, Param );
    }
    [ExecuteMe( "hello", "reflection" )]
    public void T3( string s1, string s2 ){
      Console.WriteLine( "T3 s1={0} s2={1}", s1, s2 );
    }
  }
  public class Three{
    public Three( ){ }
    [ExecuteMe]
    public void R1( ){
      Console.WriteLine( "R1" );
    }
    [ExecuteMe( 45 )]
    [ExecuteMe( 0 )]
    [ExecuteMe( 3 )]
    public void R2( int a ){
      Console.WriteLine( "R2 a={0}", a );
    }
    [ExecuteMe( "hello", "reflection" )]
    public void R3( string s1, string s2 ){
      Console.WriteLine( "R3 s1={0} s2={1}", s1, s2 );
    }
  }
}