using System;
using System.Collections.Generic;
namespace OnlusStorage{
  class TestOnlus{
    static void Main( string[] args ){
      var vestiti = new List<Vestiti>( );
      var libri = new List<Libri>( );
      for( int i = 0; i < 10; i++ ){
        vestiti.Add( new Vestiti( ){
          Name = "VestitiOnlus",
          Description = "Onlus per verstiti",
          Stagione = "primavera" + i,
          Taglia = ( i * 10 ).ToString( )
        } );
        libri.Add( new Libri( ){
          Name = "OnlusLibri",
          Description = "Onlus per libri",
          Autore = "antani" + i,
          Titolo = "scapelli" + i,
          Anno = ( i * 100 )
        } );
      }
      var onlusStorageVestiti =
        new OnlusStorage<Vestiti>( vestiti ){ Nome = "OnlusSavona", Indirizzo = "Via antani 1/10" };
      var onlusStorageLibri = new OnlusStorage<Libri>( libri ){ Nome = "OnlusGenova", Indirizzo = "Via scapelli 2/5" };
      onlusStorageVestiti.GetDonation( vestiti );
      Console.WriteLine( "Disponibilita " + onlusStorageVestiti.GetAvailability( ) );
      onlusStorageVestiti.GiveItem( 3 );
      Console.WriteLine( "Disponibilita" + onlusStorageVestiti.GetAvailability( ) );
      Console.WriteLine( onlusStorageVestiti.GetState( ) );
      onlusStorageLibri.GetDonation( libri );
      Console.WriteLine( "Disponibilita " + onlusStorageLibri.GetAvailability( ) );
      onlusStorageLibri.GiveItem( 5 );
      Console.WriteLine( "Disponibilita" + onlusStorageLibri.GetAvailability( ) );
      Console.WriteLine( onlusStorageLibri.GetState( ) );
      foreach( var vestiti1 in vestiti )
        Console.WriteLine( vestiti1 );
      foreach( var libri1 in libri )
        Console.WriteLine( libri1 );
      Console.ReadKey( );
    }
  }
}