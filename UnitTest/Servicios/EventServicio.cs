using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_de_entrenamiento.Modelos;
using Proyecto_de_entrenamiento.Servicios;
using Proyecto_de_entrenamiento.Repositorios;
using Moq;


namespace UnitTest.Servicios
{
    /// <summary>
    /// Descripción resumida de EventServicio
    /// </summary>
    [TestClass]
    public class EventServicio
    {
        private EventRepository _eventRepository;
        private List<Event> _eventsList;
        private Event _eventByID;

        public EventServicio()
        {
            _eventRepository = new EventRepository();
            _eventsList = new List<Event>();
            var containerList = new List<P2PContainer>();

            _eventByID = new Event {
                EventID = 1,
                Containers = new List<P2PContainer>(),
                Description = "Event1",
                OrganizationID = 1
            };

            _eventsList.Add(_eventRepository.addEvent(1, 1, containerList));
            _eventsList.Add(_eventRepository.addEvent(2, 6, containerList));
            _eventsList.Add(_eventRepository.addEvent(3, 15, containerList));
            _eventsList.Add(_eventRepository.addEvent(4, 3, containerList));
            _eventsList.Add(_eventRepository.addEvent(5, 8, containerList));
        }

        [TestMethod]
        public void GetEventList_WhenSuccessful_ReturnAList()
        {
            //Arrange
            Mock<IEventRepository> mockEventRepository = new Mock<IEventRepository>();
            mockEventRepository.Setup(m => m.AllEvents()).Returns(_eventsList);
            Events EventServicio = new Events(mockEventRepository.Object);

            //Act
            List<Event> events = EventServicio.AllEvents();

            //Assert
            Assert.AreEqual(_eventsList, events);
        }

        [TestMethod]
        public void GetEventByID_WhenSuccessful_ReturnAList()
        {
            //Arrange
            Mock<IEventRepository> mockEventRepository = new Mock<IEventRepository>();
            mockEventRepository.Setup(m => m.FindEvent(1,1)).Returns(_eventByID);
            Events EventServicio = new Events(mockEventRepository.Object);

            //Act
            Event NewEvent = EventServicio.FindEvent(1,1);

            //Assert
            Assert.AreEqual(_eventByID, NewEvent);
        }
    }
}
