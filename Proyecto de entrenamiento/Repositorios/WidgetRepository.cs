using System;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IWidgetRepository
    {
        P2PWidget AddWidget(int WidgetID);
        List<P2PWidgetContent> AddWidgetContent(int WidgetID);
    }

    class WidgetRepository : IWidgetRepository
    {
        public P2PWidget AddWidget(int WidgetID)
        {
            P2PWidget widget = new P2PWidget
            {
                WidgetID = WidgetID,
                ContainerID = 1,
                Locked = false,
                Properties = "{'type':'video'}",
                SortOrder = 1,
                P2PWidgetTypeID = 1,
                IsRequired = true,
                IsVisible = true,
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