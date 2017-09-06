using System;
using System.Collections.Generic;

namespace EventHandlingBroadcast{
  internal class Program{
    public static void Main( string[] args ){
      var generator = new Generator(  );
      var bank = new Bank(  );

      var police = new Police( generator, bank );

      generator.AlarmOn(  );
      bank.AlarmOn(  );
    }
  }

}