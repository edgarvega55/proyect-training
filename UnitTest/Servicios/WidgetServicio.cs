using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_de_entrenamiento.Modelos;
using Proyecto_de_entrenamiento.Servicios;
using Proyecto_de_entrenamiento.Repositorios;
using Moq;

namespace UnitTest.Repositorios
{
    /// <summary>
    /// Descripción resumida de WidgetServicio
    /// </summary>
    [TestClass]
    public class WidgetServicio
    {
        private WidgetRepository widgetsRepository;
        private List<P2PWidget> _widgetsList;
        private List<P2PWidget> _widgetsListByContainer;

        public WidgetServicio()
        {
            widgetsRepository = new WidgetRepository();
            _widgetsList = new List<P2PWidget>();
            _widgetsListByContainer = new List<P2PWidget>();
            P2PWidget widget1 = widgetsRepository.AddWidget(1, 2, "y", "{test : 1}", 1, "Donation", true, "y", "n");
            P2PWidget widget2 = widgetsRepository.AddWidget(2, 9, "y", "{test : 2}", 1, "Event", false, "y", "n");
            P2PWidget widget3 = widgetsRepository.AddWidget(3, 10, "n", "{test : 3}", 1, "Donation", false, "y", "y");
            P2PWidget widget4 = widgetsRepository.AddWidget(4, 8, "y", "{test : 4}", 1, "Event", true, "y", "n");
            P2PWidget widget5 = widgetsRepository.AddWidget(5, 2, "n", "{test : 5}", 1, "DonationThankYou", true, "y", "n");
            _widgetsList.Add(widget1);
            _widgetsList.Add(widget2);
            _widgetsList.Add(widget3);
            _widgetsList.Add(widget4);
            _widgetsList.Add(widget5);
            _widgetsListByContainer.Add(widget1);
            _widgetsListByContainer.Add(widget5);
        }

      
        [TestMethod]
        public void GetWidgetsList_WhenSuccessful_ReturnAList()
        {
            //Arrange
            Mock<IWidgetRepository> mockWidgetRepository = new Mock<IWidgetRepository>();
            mockWidgetRepository.Setup(m => m.AllWidgets()).Returns(_widgetsList);
            Widgets widgetServicio = new Widgets(mockWidgetRepository.Object);

            //Act
            List<P2PWidget> widgets = widgetServicio.AllWidgets();

            //Assert
            Assert.AreEqual(_widgetsList, widgets);
        }

        [TestMethod]
        public void GetWidgetsListByContainer_WhenSuccessful_ReturnAList()
        {
            //Arrange
            Mock<IWidgetRepository> mockWidgetRepository = new Mock<IWidgetRepository>();
            mockWidgetRepository.Setup(m => m.WidgetsByContainer(2)).Returns(_widgetsListByContainer);
            Widgets widgetServicio = new Widgets(mockWidgetRepository.Object);

            //Act
            List<P2PWidget> widgets = widgetServicio.WidgetsByContainer(2);

            //Assert
            Assert.AreEqual(_widgetsListByContainer, widgets);
        }
    }
}
