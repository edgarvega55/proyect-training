using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IContainer
    {
        List<P2PContainer> createContainers();
        P2PContainer FindContainer(List<P2PContainer> containers, int containerId);
    }

    public class Container : IContainer
    {
        public List<P2PContainer> createContainers()
        {
            List<P2PContainer> listContainer = new List<P2PContainer>();
            IContainerRepository containerRepository = new ContainerRepository();

            for (int i = 1; i <= 5; i++)
            {
                P2PContainer container = containerRepository.AddContainer(i);
                container.widgets.Reverse();

                for (var a = 0; a < container.widgets.Count; a++)
                {
                   if (container.widgets[a].Locked == "y")
                   {
                        container.widgets.Remove(container.widgets[a]);
                   }
                }

                P2PContainerContent containerContent = containerRepository.AddContainerContent(i);
                listContainer.Add(container);
            }

            return listContainer;
        }

        public P2PContainer FindContainer(List<P2PContainer> containers, int containerId)
        {
            foreach (P2PContainer container in containers)
            {
                if (container.ContainerID == containerId)
                {
                    return container;
                }
            }

            return null;
        }
    }
}
