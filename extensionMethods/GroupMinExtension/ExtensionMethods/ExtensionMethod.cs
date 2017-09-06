using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace ExtensionMethods {
  public class ExtensionMethod {

    static void Main( string[] args ) {

      foreach (var i in new List<int>() {3, 3, 6, 4, -3, 6, 12, 2, 7, 11, 3, 1}.GroupMin(3))
      {
        Console.Write("{0} ", i);
      }
      Console.WriteLine();
      Console.Read();
    }
  }
}
