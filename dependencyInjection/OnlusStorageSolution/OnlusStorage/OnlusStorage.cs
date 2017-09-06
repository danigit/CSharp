using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace OnlusStorage{
  class OnlusStorage<T>{
    public List<T> Beni;
    public string Nome { get; set; }
    public string Indirizzo { get; set; }
    public OnlusStorage( List<T> beni ){
      Beni = beni;
    }
    public void GetDonation( List<T> ricevuti ){
      Beni.AddRange( ricevuti );
    }
    public int GetAvailability( ){
      return Beni.Count;
    }
    public void GiveItem( int number ){
      if( number > Beni.Count )
        throw new ArgumentOutOfRangeException( );
      Beni.RemoveRange( 0, number );
    }
    public string GetState( ){
      return "Ci sono " + Beni.Count + " di tipo " + Beni.GetType( ).GetProperty( "Item" ).PropertyType;
    }
  }
}