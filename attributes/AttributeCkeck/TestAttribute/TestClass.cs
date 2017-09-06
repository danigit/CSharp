using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AttributeChaeck;
using Executer;

namespace TestAttribute{
  public class TestClass{
    public static void Main( string[] args ){

      var loadDll = Assembly.LoadFrom( "../../bin/Debug/Executer.dll" );
      var classes = loadDll.GetTypes( );

      foreach( var @class in classes ){
        var methods = @class.GetMethods( BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly );
        var obj = new ExecuterClass( );

        foreach( var method in methods ){
          if( VerifyRangeCheckedAttributes( method ) )
            Console.WriteLine( "The attributes are correct for method " + method.Name );
          else
            Console.WriteLine( "The attributes are incorrect for method " + method.Name );
          Console.WriteLine( CheckedIntParamInvocation<int>( method, obj, new[]{ 4, 3 } ) );
        }
      }
    }

    public static bool VerifyRangeCheckedAttributes( MethodInfo method ){

      var attributeValues = new List<string>( );
      foreach( RangeCheckedAttribute attribute in method.GetCustomAttributes( typeof( RangeCheckedAttribute ), false )
      )
        if( attribute != null )
          attributeValues.Add( attribute.ParamName );
      var parameters = new List<string>( );

      foreach( var parameter in method.GetParameters( ) )
        parameters.Add( parameter.Name );
      if( attributeValues.SequenceEqual( parameters ) )
        return true;
      return false;
    }

    public static T CheckedIntParamInvocation<T>( MethodInfo method, ExecuterClass obj, int[] parameters ){

      var attributeValues = new Dictionary<int, List<int>>( );
      var i = 1;
      foreach( RangeCheckedAttribute attribute in method.GetCustomAttributes( typeof( RangeCheckedAttribute ), false )
      )
        if( attribute != null ){
          var maxMin = new List<int>( );
          maxMin.Add( attribute.Minim );
          maxMin.Add( attribute.Maxim );
          attributeValues.Add( i, maxMin );
          i++;
        }
      foreach( var key in attributeValues )
        if( !( key.Value[0] < parameters[key.Key - 1] && parameters[key.Key - 1] < key.Value[1] ) )
          throw new ArgumentOutOfRangeException( );
      i = 0;
      var param = new object[parameters.Length];
      foreach( var parameter in parameters )
        param[i++] = parameter;
      return (T) method.Invoke( obj, param );
    }
  }
}