using Portafolio_Curso.Interfaces;
using Portafolio_Curso.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio_Curso.Services
{
    public class EmailSendGridService: IEmailService
    {

        private readonly IConfiguration _configuration;

        public EmailSendGridService(IConfiguration configuration)
        {
            _configuration = configuration;
        }  
        
        public async Task Send(ContactDTO contactDTO)
        {
            //Origin configuration
            var apiKey = _configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = _configuration.GetValue<string>("SENDGRID_API_FROM");
            var myName = _configuration.GetValue<string>("SENDGRID_API_NAME");

            //Destination configuration
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, myName);
            var subject = $"{contactDTO.Email}";
            var to= new EmailAddress(email, myName);
            var plainText = contactDTO.Mensaje;
            var htmlContent = @$"De: {contactDTO.Nombre} - 
                                Email: {contactDTO.Email}
                                Mensaje: {contactDTO.Mensaje}";

            //Sending Email through SendGrid
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, plainText, htmlContent);
            var answer= await client.SendEmailAsync(singleEmail);

        }
    }
}
