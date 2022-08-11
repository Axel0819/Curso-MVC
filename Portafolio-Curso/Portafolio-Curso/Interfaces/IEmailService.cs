using Portafolio_Curso.Models;

namespace Portafolio_Curso.Interfaces
{
    public interface IEmailService
    {
        Task Send(ContactDTO contactDTO);
    }
}
