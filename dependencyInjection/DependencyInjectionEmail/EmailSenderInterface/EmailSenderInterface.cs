namespace EmailSenderInterface{
  public interface IEmailSender{
    bool SendEmail( string to, string body );
  }
}