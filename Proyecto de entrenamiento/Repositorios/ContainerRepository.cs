using System;
using Proyecto_de_entrenamiento.Enums;
using Proyecto_de_entrenamiento.Modelos;
using Proyecto_de_entrenamiento.Servicios;

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
                P2PPageTypeID = AssignAPageType(ContainerID),
                Properties = "{'title':'test'}",
                IsHero = false,
                IsHeroLocked = false,
                SortOrder = 1,
                ColumnOrder = 1
            };

            IWidgets widgets = new Widgets();
            widgets.CreateWidgets(container);

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

        private string AssignAPageType (int ContainerID)
        {
            string P2PPageTypeID = "";

            if (ContainerID == 1 || ContainerID == 3)
            {
                P2PPageTypeID = pageType.Event.ToString();
            }
            else if (ContainerID == 2 || ContainerID == 4)
            {
                P2PPageTypeID = pageType.Donation.ToString();
            }
            else if (ContainerID == 5)
            {
                P2PPageTypeID = pageType.DonationThankYou.ToString();
            }

            return P2PPageTypeID;
        }
    }
}