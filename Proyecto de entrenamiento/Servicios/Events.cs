using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IEvents
    {
        List<Event> AllEvents();
        Event FindEvent(int eventId);
    }

    public class Events : IEvents
    {
        private SqlConnection conn;

        public Events()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public List<Event> AllEvents()
        {
            conn.Open();

            IContainer servicioContainer = new Container();
            string sql = "EXECUTE AllEvents;";
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AllEvents";
            SqlDataReader dataReader = command.ExecuteReader();

            IEventRepository eventRepository = new EventRepository();
            List<Event> events = new List<Event>();

            while (dataReader.Read())
            {
                int EventID = int.Parse(dataReader.GetValue(0).ToString());
                int OrganizationID = int.Parse(dataReader.GetValue(1).ToString());
                List<P2PContainer> container = servicioContainer.ContainersByEvent(EventID);
                Event newEvent = eventRepository.addEvent(EventID, OrganizationID, container);
                events.Add(newEvent);
            }
            conn.Close();
            return events;
        }

        public Event FindEvent (int EventID)
        {
            conn.Open();

            IContainer servicioContainer = new Container();
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
                List<P2PContainer> containers = servicioContainer.ContainersByEvent(eventId);

                newEvent = eventRepository.addEvent(eventId, OrganizationID, containers);
                conn.Close();
                return newEvent;
            }

            conn.Close();
            return null;
        }

    }
}