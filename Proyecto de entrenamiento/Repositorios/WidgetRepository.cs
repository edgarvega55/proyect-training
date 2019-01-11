using System;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IWidgetRepository
    {
        P2PWidget AddWidget(int WidgetID, int ContainerID);
        List<P2PWidgetContent> AddWidgetContent(int WidgetID);
    }

    class WidgetRepository : IWidgetRepository
    {
        public P2PWidget AddWidget(int WidgetID, int ContainerID)
        {
            P2PWidget widget = new P2PWidget
            {
                WidgetID = WidgetID,
                ContainerID = ContainerID,
                Locked = WidgetID % 2 == 0 ? "n" : "y",
                Properties = "{'type':'video'}",
                SortOrder = 1,
                P2PWidgetTypeID = 1,
                IsRequired = true,
                IsVisible = WidgetID % 2 == 0 ? "n" : "y",
                VisibilityConditionTypeID = 0
            };

            return widget;
        }

        public List<P2PWidgetContent> AddWidgetContent(int WidgetID)
        {
            List<P2PWidgetContent> WidgetContentList = new List<P2PWidgetContent>();

            P2PWidgetContent widgetContentEn = new P2PWidgetContent
            {
                WidgetID = WidgetID,
                LenguageCode = "en-CA",
                Content = "{..}"
            };

            P2PWidgetContent widgetContentFR = new P2PWidgetContent
            {
                WidgetID = WidgetID,
                LenguageCode = "fr-CA",
                Content = "{..}"
            };

            WidgetContentList.Add(widgetContentEn);
            WidgetContentList.Add(widgetContentFR);

            return WidgetContentList;
        }
    }
}