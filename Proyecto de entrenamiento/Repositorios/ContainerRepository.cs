using System;
using Proyecto_de_entrenamiento.Enums;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IContainerRepository
    {
        P2PContainer AddContainer(int ContainerID);
        P2PContainerContent AddContainerContent(int ContainerID);
    }

    class ContainerRepository : IContainerRepository
    {
        public P2PContainer AddContainer(int ContainerID)
        {
            P2PContainer container = new P2PContainer
            {
                ContainerID = ContainerID,
                EventID = 1,
                P2PPageTypeID = pageType.Donation.ToString(),
                Properties = "{'title':'test'}",
                IsHero = false,
                IsHeroLocked = false,
                SortOrder = 1,
                ColumnOrder = 1
            };

            return container;
        }

        public P2PContainerContent AddContainerContent(int ContainerID)
        {
            P2PContainerContent containerContent = new P2PContainerContent
            {
                ContainerID = ContainerID,
                LenguageCode = "en-CA",
                Content = "{..}"
            };

            return containerContent;
        }

        public void testInterface()
        {

        }
    }
}