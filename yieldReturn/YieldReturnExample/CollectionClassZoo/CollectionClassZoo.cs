using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionClassZoo{
  class CollectionClassZoo{
    static void Main( string[] args ){
      Zoo theZoo = new Zoo( );

      theZoo.AddMammal( "Whale" );
      theZoo.AddMammal( "Rhinoceros" );
      theZoo.AddBird( "Penguin" );
      theZoo.AddBird( "Warbler" );

      foreach( string name in theZoo ){
        Console.Write( name + " " );
      }

      Console.WriteLine( );

      foreach( string name in theZoo.Birds ){
        Console.Write( name + " " );
      }

      Console.WriteLine( );

      foreach( string name in theZoo.Mammals ){
        Console.Write( name + " " );
      }

      Console.WriteLine( );

      Console.ReadKey( );
    }
  }

  public class Zoo: IEnumerable{
    private List<Animal> animals = new List<Animal>( );

    //method that add a mammal to the list
    public void AddMammal( string name ){
      animals.Add( new Animal{ Name = name, Type = Animal.TypeEnum.Mammal } );
    }

    //method that add a bird to the list
    public void AddBird( string name ){
      animals.Add( new Animal{ Name = name, Type = Animal.TypeEnum.Bird } );
    }

    //getEnumerator that return all the animals from the list
    public IEnumerator GetEnumerator( ){
      foreach( Animal theAnimal in animals ){
        yield return theAnimal.Name;
      }
    }

    //method that returns the mammals from the list
    //is the implementation of the getter for mammals
    //if I don't define this I can do theAnimals.Mammals
    public IEnumerable Mammals {
      get{ return AnimalsForType( Animal.TypeEnum.Mammal ); }
    }

    //method that returns the birds from the list
    //is the implementation of the getter for birds
    public IEnumerable Birds {
      get{ return AnimalsForType( Animal.TypeEnum.Bird ); }
    }

    //method that returns the animals which type is passed as parameter
    private IEnumerable AnimalsForType( Animal.TypeEnum type ){
      foreach( Animal theAnimal in animals ){
        if( theAnimal.Type == type ){
          yield return theAnimal.Name;
        }
      }
    }
  }


  public class Animal{
    public enum TypeEnum{
      Bird,
      Mammal
    }

    public string Name { get; set; }
    public TypeEnum Type { get; set; }
  }
}