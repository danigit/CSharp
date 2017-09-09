using System;

namespace ElementaryExamples{

  public class Fruit{
    internal string _type;

    public Fruit( string _type ){

    }
  }

  public class Apple : Fruit{

    public Apple( string type ) : base(type){
    }
  }
}