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
    /// Descripción resumida de ContainerServicio
    /// </summary>
    [TestClass]
    public class ContainerServicio
    {
        private ContainerRepository _containerRepository;
        private List<P2PContainer> _containerList;
        private List<P2PContainer> _containerListByEvent;

        public ContainerServicio()
        {
            _containerRepository = new ContainerRepository();
            _containerList = new List<P2PContainer>();
            _containerListByEvent = new List<P2PContainer>();

            P2PContainer container1 = _containerRepository.AddContainer(1, 1, "Event", "{test:1}", true, false, 2, 2, false);
            P2PContainer container2 = _containerRepository.AddContainer(2, 3, "Donation", "{test:2}", false, true, 2, 2, false);
            P2PContainer container3 = _containerRepository.AddContainer(3, 8, "Event", "{test:3}", true, false, 2, 2, false);
            P2PContainer container4 = _containerRepository.AddContainer(4, 2, "Donation", "{test:4}", true, true, 2, 2, false);
            P2PContainer container5 = _containerRepository.AddContainer(5, 8, "Event", "{test:5}", false, false, 2, 2, false);

            _containerList.Add(container1);
            _containerList.Add(container2);
            _containerList.Add(container3);
            _containerList.Add(container4);
            _containerList.Add(container5);
            _containerListByEvent.Add(container3);
            _containerListByEvent.Add(container5);
        }


        [TestMethod]
        public void GetContainerList_WhenSuccessful_ReturnAList()
        {
            //Arrange
            Mock<IContainerRepository> mockContainerRepository = new Mock<IContainerRepository>();
            mockContainerRepository.Setup(m => m.AllContainers()).Returns(_containerList);
            Container ContainerServicio = new Container(mockContainerRepository.Object);

            //Act
            List<P2PContainer> containers = ContainerServicio.AllContainers();

            //Assert
            Assert.AreEqual(_containerList, containers);
        }

        [TestMethod]
        public void GetContainerByEventList_WhenSuccessful_ReturnAList()
        {
            //Arrange
            Mock<IContainerRepository> mockContainerRepository = new Mock<IContainerRepository>();
            mockContainerRepository.Setup(m => m.ContainersByEvent(8,1)).Returns(_containerListByEvent);
            Container ContainerServicio = new Container(mockContainerRepository.Object);

            //Act
            List<P2PContainer> containers = ContainerServicio.ContainersByEvent(8,1);

            //Assert
            Assert.AreEqual(_containerListByEvent, containers);
        }
    }
}
