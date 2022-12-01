using CleanArch.Application.Models;

namespace CleanArch.Application.Contracts.Inftrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email); // el email es un objeto que se crea en el dominio; Hay que crear el model que soporte el email (local)
    }
}
