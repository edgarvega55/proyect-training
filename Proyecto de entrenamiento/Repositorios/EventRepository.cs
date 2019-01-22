using System;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Modelos;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Proyecto_de_entrenamiento.Repositorios;

namespace Proyecto_de_entrenamiento.Repositorios
{
    public interface IEventRepository
    {
        List<Event> AllEvents();
        Event FindEvent(int EventID, int PageType);
    }

    public class EventRepository : IEventRepository
    {
        private SqlConnection conn;

        public EventRepository()
        {
            
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
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
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
                List<P2PContainer> container = servicioContainer.ContainersByEvent(EventID, 1);
                Event newEvent = addEvent(EventID, OrganizationID, container);
                events.Add(newEvent);
            }
            return events;
        }

        public Event FindEvent(int EventID, int PageType)
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
            IContainerRepository servicioContainer = new ContainerRepository();
            IEventRepository eventRepository = new EventRepository();
            Event newEvent;

            conn.Open();

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
                List<P2PContainer> containers = servicioContainer.ContainersByEvent(eventId, PageType);
                newEvent = addEvent(eventId, OrganizationID, containers);
                conn.Close();
                return newEvent;
            }

            conn.Close();
            return null;
        }
    }
}