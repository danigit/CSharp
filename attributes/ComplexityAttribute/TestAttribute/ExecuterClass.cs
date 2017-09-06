using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ComplexityAttribute;

namespace TestAttribute{
  class TestAttribute{
    static void Main( string[] args ){
      Dictionary<object, int> dic = GetComplexity( "../../../Executer/bin/Debug/Executer.dll" );
      foreach( var o in dic )
        Console.WriteLine( o.Key + " - " + o.Value );
      Console.WriteLine( "Il livello minimo e " +
                         AuthorMinLevel( "../../../Executer/bin/Debug/Executer.dll", "Class1 Method1" ) );
      Console.ReadKey( );
    }

    public static Dictionary<object, int> GetComplexity( string assembly ){
      var result = new Dictionary<object, int>( );
      var loadDll = Assembly.LoadFrom( assembly );
      var classes = loadDll.GetTypes( );
      foreach( var @class in classes ){
        var complexity = 0;
        var count = 0;
        foreach( var methodInfo in @class.GetMethods( ) )
          foreach( ComplexityClassAttribute customAttribute in methodInfo.GetCustomAttributes( typeof( ComplexityClassAttribute ),
                                                                                          false ) )
            if( customAttribute != null ){
              count++;
              complexity += customAttribute.Complexity;
            }
        try{
          if( count != 0 )
            result.Add( @class.Name, complexity / count );
        } catch( Exception e ){
          Console.WriteLine( e );
          throw;
        }
      }
      return result;
    }

    public static int AuthorMinLevel( string assembly, string name ){
      var minLevel = new List<int>( );
      var loadDll = Assembly.LoadFrom( assembly );
      var classes = loadDll.GetTypes( );
      foreach( var @class in classes ){
        foreach( var methodInfo in @class.GetMethods( ) )
          foreach( ComplexityClassAttribute customAttribute in methodInfo.GetCustomAttributes( typeof( ComplexityClassAttribute ),
                                                                                          false ) )
            if( customAttribute != null ){
              if( customAttribute.Author == name ){
                minLevel.Add( customAttribute.Complexity );
              }
            }
      }
      if( minLevel.Count == 0 )
        throw new ArgumentException( );
      return minLevel.OrderBy( x => x ).First( );
    }
  }
}