using System;

namespace EventHandlingBroadcast{
  public class Police{
    private Generator Generator;
    private Bank Bank;

    public Police( Generator generator, Bank bank ){
      Generator = generator;
      Bank = bank;
      Generator.Spread += Intervent;
      Generator.Spread += Arestato;
      Bank.Spread += Intervent;
      Bank.Spread += Arestato;
    }

    public void Intervent( object sender, EventArgs e ){
      Console.WriteLine("Sto intervenendo per la segnalazione da parte di " + sender);
    }

    public void Arestato( object sender, EventArgs e ){
      Console.WriteLine("Ho arestato il ladro di " + sender);
    }
  }
}