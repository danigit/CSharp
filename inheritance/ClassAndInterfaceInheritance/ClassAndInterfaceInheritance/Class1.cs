using System;

namespace ClassAndInterfaceInheritance{

  public abstract class Food{
    internal bool edible;

    public abstract bool IsEdible( );
  }

  public class Fruit : Food{

    public string fruitName;

    public Fruit( string fruitName ){
      this.fruitName = fruitName;
    }

    public sealed override bool IsEdible( ){
      return edible;
    }
  }

  public interface IApple{

    void Sell( int howMany );
  }

  public interface IPineapple{

    string FromWhere( );
    void Sell( int howMany );
  }

  public class Apple : Fruit, IApple{
    private int _stock;
    public int Stock => _stock;

    //calling the superclass constructor
    public Apple( string fruitName ): base( fruitName ){
      edible = true;
      _stock = 0;
    }

    //calling another constructor from this class
    public Apple( string str, int stock ): this( str ){
      //the cals in this constructor override the cals in the this constructor
      _stock = stock;
      edible = false;
    }

    public void Sell( int howMany ){
      if( _stock >= howMany )
        _stock -= howMany;
    }

    //Here I can override the IsEdiable() method because I declared sealed in the superclass
    //public override IsEdiable(){}
  }

  public class Pineapple: Fruit, IPineapple{

    public Pineapple( string fruitName ): base( fruitName ){ }

    public string FromWhere( ){
      return "Pineapple";
    }

    public void Sell( int howMany ){
      throw new NotImplementedException( );
    }
  }

  public class AppleAndPineapple: Fruit, IApple, IPineapple{

    private int _apple;
    private int _pineapple;

    public int Apple => _apple;
    public int Pineapple => _pineapple;

    public AppleAndPineapple( string fruitName, int apple, int pineapple ): base( fruitName ){
      _apple = apple;
      _pineapple = pineapple;
    }

    public string FromWhere( ){
      return "Pineapples are from Brasil";
    }

    void IPineapple.Sell( int howMany ){
      if( _pineapple >= howMany ) _pineapple -= howMany;
    }

    void IApple.Sell( int howMany ){
      if( _apple >= howMany ) _apple -= howMany;
    }

  }

  public class Pears : Fruit{
    public Pears( string fruitName ): base( fruitName ){ }
  }
}