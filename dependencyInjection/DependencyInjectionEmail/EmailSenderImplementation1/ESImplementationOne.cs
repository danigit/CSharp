using EmailSenderInterface;
using System;

namespace EmailSenderImplementation1{
  public class ESImplementationOne: IEmailSender{
    private string tag;
    private int num;

    public ESImplementationOne( string tag ){
      this.tag = tag;
    }

    public ESImplementationOne( int num, string tag ){
      this.tag = tag;
      this.num = num;
    }

    public bool SendEmail( string to, string body ){
      if( to == null )
        throw new ArgumentNullException( nameof( to ) );
      if( body == null )
        throw new ArgumentNullException( nameof( body ) );
      Console.WriteLine( "Email sended to {0} from the implementation 1, with body {1}, and tag {2} with number{3}", to,
                         body, tag, num );
      return true;
    }
  }
}