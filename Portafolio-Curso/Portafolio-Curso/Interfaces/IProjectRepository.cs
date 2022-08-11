using Portafolio_Curso.Models;

namespace Portafolio_Curso.Interfaces
{
    public interface IProjectRepository
    {
        List<ProjectDTO> ObtenerProyectos();
    }
}
