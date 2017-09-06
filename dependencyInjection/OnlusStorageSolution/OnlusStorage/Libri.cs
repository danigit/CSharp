namespace OnlusStorage {
  class Libri : IReliefGood {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Autore { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public override string ToString( ) {
      return Name + " con descrizione " + Description + " libro con autore " + Autore + " con titolo " + Titolo + " dell'anno" + Anno;
    }
  }
}
