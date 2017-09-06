using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCovarianceControvarianc{
  class Mammals{ }

  class Dogs: Mammals{ }

  //Covariance -> the return type of the method is a derived type from the return type in the delegate signature
  //Contravariance -> the tyepes of parameters of a method are base types of the delegate signature parameter type
  class CovarianceControvariance{
    public delegate Mammals HandlerMethod( );

    public static Mammals MammalsHandler( ){
      return null;
    }

    public static Dogs DogsHandler( ){
      return null;
    }

    static void Test( ){
      HandlerMethod handlerMammals = MammalsHandler;

      //covariance enables this assignment
      HandlerMethod handlerdogs = DogsHandler;
    }

    static void Main( string[] args ){ }
  }
}