using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Servicios
{
    interface IContainer
    {
        void createContainers();
    }

    class Container : IContainer
    {
        public void createContainers()
        {
            IContainerRepository containerRepository = new ContainerRepository();
            Console.WriteLine("");
            Console.WriteLine("**** Containers ****");
            for (int i = 1; i <= 5; i++)
            {
                P2PContainer container = containerRepository.AddContainer(i);
                Console.WriteLine("Container ID: {0}", container.ContainerID);
                Console.WriteLine("Container Page Type: {0}", container.P2PPageTypeID);

                P2PContainerContent containerContent = containerRepository.AddContainerContent(i);
                Console.WriteLine("Container Content ID: {0}", containerContent.ContainerID);
                Console.WriteLine("Container Content LenguageCode: {0}", containerContent.LenguageCode);
            }
        }
    }
}
