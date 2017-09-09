using System;
using ClassAndInterfaceInheritance;

namespace Test{
  public class Test{
    public static void Main( string[] args ){
      var fruit = new Fruit( "pear" );
      var apple = new Apple( "fuji" );
      var apple1 = new Apple( "golden", 500 );

      Console.WriteLine( "The var apple has is of type " + apple.fruitName + " and has a stock of: " + apple.Stock);
      Console.WriteLine( "The var apple1 is of type " + apple1.fruitName + " and has a stock of: " + apple1.Stock);
      Console.WriteLine( "The var apple is ediable: " + apple.IsEdible(  ));
      Console.WriteLine( "The var apple1 is ediable: " + apple1.IsEdible(  ));

      var pineapple = new Pineapple( "pineapple" );

      Console.WriteLine( "The var pineapple is ediable: " + pineapple.IsEdible(  ));
      Console.WriteLine( "The var pineaple cams from " + pineapple.FromWhere(  ));

      Console.WriteLine("\n\nChanging to AppleAndPineapple ... ");

      var applePineapple = new AppleAndPineapple( "mix", 100, 200 );
      //becouse Sell is explicitly implemented can obly be accessed through his interface
      //applePineapple.Sell( 10 ) doesn't work becouse it doesn't know wich Sell() I'm talking
      ((IApple)applePineapple).Sell( 10 );

      Console.WriteLine("I seeld 10 apples and I have in stock " + applePineapple.Apple + " apples left");

      Console.WriteLine( "\n\nChanging to type checking and cast operations ...");

      Console.Write( "Control if Fruit is instance of Pears: ");
      Console.Write( fruit is Pears );
      Console.WriteLine( "\nAssingning a Pears variable to fruit ...");
      fruit = new Pears( "pear" );

      Console.Write( "Control if Fruit is instance of Pears: ");
      Console.Write( fruit is Pears );

      Console.WriteLine( "\nCasting from Fruit to Pears using AS ...");
      var cast = fruit as Pears;

      Console.Write( "Contoll if the variable converted is of type Pear: ");
      Console.WriteLine( cast is Pears);

    }
  }
}