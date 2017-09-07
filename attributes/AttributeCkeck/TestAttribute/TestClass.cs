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
        var executer = (ExecuterClass) Activator.CreateInstance( @class );

        foreach( var method in methods ){
          if( VerifyRangeCheckedAttributes( method ) )
            Console.WriteLine( "The attributes are correct for method " + method.Name );
          else
            Console.WriteLine( "The attributes are incorrect for method " + method.Name );

          if(method.GetParameters(  ).Length == 2)
            Console.WriteLine( "The invocation of the method returns " + CheckedIntParamInvocation<int>( method, executer, new[]{ 4, 3 } ) );
          if(method.GetParameters(  ).Length == 3)
            Console.WriteLine( "The invocation of the method returns " + CheckedIntParamInvocation<int>( method, executer, new[]{ 4, 3, 13 } ) );
        }
      }
    }

    public static bool VerifyRangeCheckedAttributes( MethodInfo method ){

      var attributeValues = new List<string>( );
      foreach( RangeCheckedAttribute attribute in method.GetCustomAttributes( typeof( RangeCheckedAttribute ), false )
      )
        if( attribute != null )
          attributeValues.Add( attribute.ParamName );

      var parameters = method.GetParameters( ).Select( parameter => parameter.Name ).ToList( );

      return attributeValues.SequenceEqual( parameters );
    }

    public static T CheckedIntParamInvocation<T>( MethodInfo method, ExecuterClass obj, int[] parameters ){

      var attributeValues = new Dictionary<int, List<int>>( );
      var i = 1;

      foreach( RangeCheckedAttribute attribute in method.GetCustomAttributes( typeof( RangeCheckedAttribute ), false )
      )
        if( attribute != null )
          attributeValues.Add( i++, new List<int>{ attribute.Minim, attribute.Maxim} );

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