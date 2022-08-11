using Portafolio_Curso.Interfaces;
using Portafolio_Curso.Models;

namespace Portafolio_Curso.Services
{
    public class ProjectRepository: IProjectRepository
    {
        public List<ProjectDTO> ObtenerProyectos()
        {
            return new List<ProjectDTO>(){
                new ProjectDTO { Titulo= "Amazon", Descripcion="E-commerce hecho en ASP.NET Core", ImagenURL="/img/amazon.png", Link="https://amazon.com"},
                new ProjectDTO { Titulo= "New York Times", Descripcion="Página de noticias con Angular", ImagenURL="/img/nyt.png", Link="https://nytimes.com"},
                new ProjectDTO { Titulo= "Steam", Descripcion="Tienda en línea para comprar videojuegos", ImagenURL="/img/steam.png", Link="https://store.steampowered.com"},
                new ProjectDTO { Titulo= "Reddit", Descripcion="Red social para la comunidad", ImagenURL="/img/reddit.png", Link="https://reddit.com"}
            };
        }
    }
}
