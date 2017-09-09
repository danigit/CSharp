using System;
using System.Collections.Generic;
using System.Linq;

namespace Relations{
  public interface IRelations<T1, T2>{

    bool AddLink( T1 t1, T2 t2);
    bool RemoveLink( T1 t1, T2 t2 );
    IEnumerable<T1> GetDomain( );
    IEnumerable<T2> GetCodomain( );
    IEnumerable<T2> GetRelationsOfT1( T1 t1 );
    IRelations<T1, T2> Compose( Relations<T1, T2> t );
  }


  public class Relations<T1, T2>: IRelations<T1, T2>{

    public List<KeyValuePair<T1, T2>> relations { get; }

    public Relations( ){
      relations = new List<KeyValuePair<T1, T2>>();
    }

    public Relations( List<KeyValuePair<T1, T2>> list){
      relations = list;
    }

    public bool AddLink( T1 t1, T2 t2){
      foreach( var keyValuePair in relations ){
        if( !Equals( keyValuePair.Key, t1 ) && Equals( keyValuePair.Value, t2 ) )
          return false;
      }
      relations.Add( new KeyValuePair<T1, T2>( t1, t2 ) );
      return true;
    }

    public bool RemoveLink( T1 t1, T2 t2){
      return relations.Remove( new KeyValuePair<T1, T2>( t1, t2) );
    }

    public IEnumerable<T1> GetDomain( ){
      return relations.Select( keyValuePair => keyValuePair.Key ).Distinct().ToList(  );
    }

    public IEnumerable<T2> GetCodomain( ){
      return relations.Select( keyValuePair => keyValuePair.Value ).Distinct( ).ToList( );
    }

    public IEnumerable<T2> GetRelationsOfT1( T1 t1 ){
      foreach( var keyValuePair in relations ){
        if( keyValuePair.Key.Equals( t1 ) )
          yield return keyValuePair.Value;
      }
    }

    public IRelations<T1, T2> Compose( Relations<T1, T2> t ){
      var result = new List<KeyValuePair<T1, T2>>( );

      foreach( var keyValuePair in relations ){
        foreach( var tt in t.relations){
          if(keyValuePair.Value.Equals( tt.Key ))
            result.Add( new KeyValuePair<T1, T2>(keyValuePair.Key, tt.Value) );
        }
      }

      return new Relations<T1, T2>( result );
    }

    public override string ToString( ){
      var result = "";
      foreach( var keyValuePair in relations ){
        result += "Domain-> " + keyValuePair.Key + ":" + keyValuePair.Value + " <-Codomain\n";
      }
      return result;
    }
  }
}