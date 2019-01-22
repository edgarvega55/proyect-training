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
        IContainerRepository _containerRepository;

        public Container()
        {
            _containerRepository = new ContainerRepository();
        }

        public Container(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public List<P2PContainer> ContainersByEvent(int EventID, int PageType)
        {
            List<P2PContainer> containers = _containerRepository.ContainersByEvent(EventID, PageType);
            return containers;
        }

        public List<P2PContainer> AllContainers()
        {
            List<P2PContainer> containers  = _containerRepository.AllContainers();
            return containers;
        }
        
    }
}
