using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using MyAttribute;
using ConstructorAttribute;

namespace Labo2{
  internal class Executer{
    public static void Main( string[] args ){
      var assembly = Assembly.LoadFrom( "../../../MyLibrary/bin/Debug/MyLibrary.dll" );
      Type[] classes = assembly.GetTypes( );
      object newObject = null;
      foreach( var clas in classes ){
        try{
          if( clas.IsClass ){
            foreach( var constructor in clas.GetConstructors( ) ){
              if( constructor.GetParameters( ).Length != 0 ){
                foreach( var constructorAttributes in constructor.GetCustomAttributes( false ) ){
                  var construct = constructorAttributes as ConstructMeAttribute;
                  if( construct != null )
                    newObject = Activator.CreateInstance( clas, construct.Param );
                }
              } else
                newObject = Activator.CreateInstance( clas );
              foreach( var methods in clas.GetMethods( ) ){
                foreach( var attribute in methods.GetCustomAttributes( false ) ){
                  var attr = attribute as ExecuteMeAttribute;
                  if( attr != null )
                    methods.Invoke( newObject, ( (ExecuteMeAttribute) attribute ).param );
                }
              }
            }
          }
        } catch( Exception e ){
          if( e is IOException || e is ArgumentException || e is TargetParameterCountException ||
              e is MissingMethodException ){
            Debug.WriteLine( "The ecception was " + e.Message );
          }
        }
      }
      Console.ReadLine( );
    }
  }
}