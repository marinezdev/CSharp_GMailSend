using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

try
{
    /// Envio de correo electrónico desde GMAIL 
    var email = new MimeMessage();
    email.From.Add(MailboxAddress.Parse("ASAE" + " <correoOrigen@gmail.com>"));
    email.To.Add(MailboxAddress.Parse("correopara@gmail.com"));
    email.Subject = "Asunto de prueba";
    email.Body = new TextPart(TextFormat.Html)
    {
        Text = "Testing email sending at: " + DateTime.Now.ToString("dd MMM yyyy")
    };
    email.Headers.Add("Title", "Title from mail");
    var smtp2 = new SmtpClient();
    smtp2.Connect(
        "smtp.gmail.com",
       Convert.ToInt32("587"),
       SecureSocketOptions.StartTls
        );
    smtp2.Authenticate("correoOrigen@gmail.com", "passworddecorreo");
    string resultSending = smtp2.Send(email);
    smtp2.Disconnect(true);

    Console.WriteLine($"EMail Sended at {DateTime.Now.ToString("ddMMyyyyHHmmss")}");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Worker error on service review at: {DateTime.Now.ToString("ddMMyyyyHHmmss")} {ex.Message}");
}