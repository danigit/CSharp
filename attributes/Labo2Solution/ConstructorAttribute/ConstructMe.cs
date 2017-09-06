using System;
namespace ConstructorAttribute{
  [AttributeUsage( AttributeTargets.Constructor, AllowMultiple = true )]
  public class ConstructMeAttribute: Attribute{
    public object[] Param;
    public ConstructMeAttribute( params object[] param ){
      Param = param;
    }
  }
}