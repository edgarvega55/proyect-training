using System;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Modelos;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Proyecto_de_entrenamiento.Repositorios;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IEventRepository
    {
        List<Event> AllEvents();
        Event FindEvent(int EventID, int PageType);
    }

    class EventRepository : IEventRepository
    {
        private SqlConnection conn;

        public EventRepository()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public Event addEvent(int EventID, int OrganizationID, List<P2PContainer> Containers)
        {
            Event newEvent = new Event
            {
                EventID = EventID,
                OrganizationID = OrganizationID,
                Description = "Event " + EventID,
                Containers = Containers
            };

            return newEvent;
        }

        public List<Event> AllEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            IContainerRepository servicioContainer = new ContainerRepository();
            List<Event> events = new List<Event>();

            conn.Open();

            string sql = "EXECUTE AllEvents";
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AllEvents";
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                int EventID = int.Parse(dataReader.GetValue(0).ToString());
                int OrganizationID = int.Parse(dataReader.GetValue(1).ToString());
                //List<P2PContainer> container = servicioContainer.ContainersByEvent(EventID, 0);
                List<P2PContainer> container = new List<P2PContainer>();
                Event newEvent = addEvent(EventID, OrganizationID, container);
                events.Add(newEvent);
            }
            return events;
        }

        public Event FindEvent(int EventID, int PageType)
        {

            IContainerRepository servicioContainer = new ContainerRepository();
            IEventRepository eventRepository = new EventRepository();

            Event newEvent;

            string sql = "EXECUTE EventByID;";
            SqlCommand command = new SqlCommand(sql, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "EventByID"
            };
            command.Parameters.Add("@EvenID", SqlDbType.Int);
            command.Parameters["@EvenID"].Value = EventID;
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int eventId = int.Parse(dataReader.GetValue(0).ToString());
                int OrganizationID = int.Parse(dataReader.GetValue(1).ToString());
                //List<P2PContainer> containers = servicioContainer.ContainersByEvent(eventId, PageType);
                List<P2PContainer> containers = new List<P2PContainer>();
                newEvent = addEvent(eventId, OrganizationID, containers);
                conn.Close();
                return newEvent;
            }

            conn.Close();
            return null;
        }
    }
}