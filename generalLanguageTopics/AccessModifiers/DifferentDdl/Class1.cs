
using System;

namespace DifferentDdl{
  public class DifferentClass{
    public AccessModifiers.AccessModifiers accessModifiers;

    public DifferentClass( AccessModifiers.AccessModifiers accessModifiers ){
      this.accessModifiers = accessModifiers;
    }

    public void AccessPublicVar( ){
      Console.WriteLine( "Public var accessed directly from different dll: " + accessModifiers.GetType(  ).Namespace);
    }

    public void AccessOtherThanPublicVar( ){
      Console.WriteLine("The variables with a modifier different than public can not be accessed directly from different dll");
    }
  }
}