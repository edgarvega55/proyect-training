using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;
using System.Data;
using Proyecto_de_entrenamiento.Enums;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IContainer
    {
        List<P2PContainer> ContainersByEvent(int EventID, int PageType);
        List<P2PContainer> AllContainers();
    }

    public class Container : IContainer
    {
        private SqlConnection conn;

        public Container()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public List<P2PContainer> ContainersByEvent(int EventID, int PageType)
        {
            IContainerRepository containerRepository = new ContainerRepository();
            List<P2PContainer> containers = containerRepository.ContainersByEvent(EventID, PageType);
            return containers;
        }

        public List<P2PContainer> AllContainers()
        {
            IContainerRepository containerRepository = new ContainerRepository();
            List<P2PContainer> containers  = containerRepository.AllContainers();
            return containers;
        }
        
    }
}
