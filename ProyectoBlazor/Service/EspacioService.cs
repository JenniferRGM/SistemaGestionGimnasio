using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Service
{
    public class EspacioService
    {

        private EspacioRepository espacioRepository;
        private ClaseService claseService;

        public EspacioService(EspacioRepository espacioRepository, ClaseService claseService)
        {
            this.espacioRepository = espacioRepository;
            this.claseService = claseService;
        }


        public async Task CrearEspacio(int claseId, DateTime fecha, int Cupos)
        {
            await espacioRepository.CrearEspacio(claseId, fecha, Cupos);
            return;
        }

        public async Task<List<EspacioModel>> ListarEspaciosEntrenador(int entrenadorId)
        {
            List<ClasesModel> clases = await claseService.listarClasesPorEntrenador(entrenadorId);

            List<EspacioModel> espacios = new List<EspacioModel>();

            foreach (ClasesModel clasesModel in clases)
            {
                List<EspacioModel> espacios1 = await espacioRepository.ListarEspaciosPorClaseId(clasesModel.Id);

                espacios.AddRange(espacios1);
            }

            return espacios;
        }

        public async Task<List<EspacioModel>> ListarEspaciosPorClaseId(int ClaseId)
        {
            List<EspacioModel> espacios = await espacioRepository.ListarEspaciosPorClaseId(ClaseId);
            return espacios;
        }

        public async Task<EspacioModel> ObtenerEspacioPorId(int EspacioId)
        {
            return await espacioRepository.ObtenerEspacioPorId(EspacioId);
        }


        public async Task<List<Usuario>> ObtenerPersonasEnEspacioPorEspacioId(int EspacioId)
        {
            return await espacioRepository.ConsultarPersonasEnEspacioPorEspacioId(EspacioId);
        }


    }


}
