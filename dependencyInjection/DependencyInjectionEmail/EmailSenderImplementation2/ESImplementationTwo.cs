using EmailSenderInterface;
using System;

namespace EmailSenderImplementation2{
  public class ESImplementationTwo: IEmailSender{
    private string tag;

    public ESImplementationTwo( string tag ){
      this.tag = tag;
    }

    public bool SendEmail( string to, string body ){
      if( to == null )
        throw new ArgumentNullException( nameof( to ) );
      if( body == null )
        throw new ArgumentNullException( nameof( body ) );
      Console.WriteLine( "Email sended to {0} from the implementation 2 with body {1}, and tag {2}", to, body, tag );
      return true;
    }
  }
}