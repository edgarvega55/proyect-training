using System;
using Proyecto_de_entrenamiento.Enums;
using Proyecto_de_entrenamiento.Modelos;
using Proyecto_de_entrenamiento.Servicios;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IContainerRepository
    {
        P2PContainer AddContainer(int ContainerID, int EventID, string P2PPageTypeID, string Properties, bool IsHero, bool IsHeroLocked, int SortOrder, int ColumnOrder, bool widget);
        P2PContainerContent AddContainerContent(int ContainerID);
    }

    class ContainerRepository : IContainerRepository
    {
        public P2PContainer AddContainer(int ContainerID, int EventID, string P2PPageTypeID, string Properties, bool IsHero, bool IsHeroLocked, int SortOrder, int ColumnOrder, bool widget)
        {
            P2PContainer container = new P2PContainer
            {
                ContainerID = ContainerID,
                EventID = EventID,
                P2PPageTypeID = P2PPageTypeID,
                Properties = Properties,
                IsHero = IsHero,
                IsHeroLocked = IsHeroLocked,
                SortOrder = SortOrder,
                ColumnOrder = ColumnOrder
            };

            if (widget)
            {
                IWidgets widgets = new Widgets();
                container.widgets = widgets.WidgetsByContainer(ContainerID);
            }

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