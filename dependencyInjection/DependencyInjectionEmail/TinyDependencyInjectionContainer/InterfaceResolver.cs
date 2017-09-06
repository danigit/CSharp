using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TinyDependencyInjectionContainer{
  public class InterfaceResolver{
    private readonly Dictionary<Type, Type> dictuinary = new Dictionary<Type, Type>( );
    private readonly Type[] types = new Type[2];

    public InterfaceResolver( string fileName ){
      ControlFile( fileName );
      try{
        dictuinary.Add( types[0], types[1] );
      } catch( NullReferenceException e ){
        Debug.WriteLine( "Error: Null reference exception occured!\nStackTrace: {0}", e.StackTrace );
      }
    }

    void ControlFile( string file ){
      if( ( file == null ) || file.Equals( "" ) )
        throw new ArgumentException( nameof( file ) );
      var fileAsArrayStrings = File.ReadAllLines( "../../ConfigurationFile.txt" );
      var count = 0;
      foreach( var line in fileAsArrayStrings )
        if( !line.StartsWith( "#" ) ){
          var substrings = line.Split( '*' );
          if( substrings.Length != 4 )
            throw new FormatException( );
          for( var i = 0; i <= substrings.Length - 2; i += 2 )
            types[count++] = IsValidFile( substrings[i], substrings[i + 1] );
        }
    }

    public T Instantiate<T>( params object[] param ) where T : class{
      if( typeof( T ).IsClass )
        return (T) Activator.CreateInstance( typeof( T ), param );
      if( !dictuinary.ContainsKey( typeof( T ) ) )
        return null;
      var returnValue = dictuinary[typeof( T )];
      return (T) Activator.CreateInstance( returnValue, "antaniScapelli" );
    }

    Type IsValidFile( string name, string type ){
      Type returnType = null;
      try{
        var assembly = Assembly.LoadFrom( name );
        returnType = assembly.GetType( type );
      } catch( ArgumentException e ){
        Debug.WriteLine( "Error: Wrong argument!\nStackTrace: {0}", e.StackTrace );
      }
      if( returnType == null )
        throw new TypeLoadException( );
      return returnType;
    }
  }
}