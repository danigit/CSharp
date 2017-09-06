namespace OnlusStorage{
  class Vestiti: IReliefGood{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Taglia { get; set; }
    public string Stagione { get; set; }
    public override string ToString( ){
      return Name + " con descrizione " + Description + " vestito con taglia " + Taglia + " per la stagione " +
             Stagione;
    }
  }
}