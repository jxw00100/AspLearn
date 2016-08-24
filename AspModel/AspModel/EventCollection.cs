using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspModel
{
    public enum EventSource
    {
        Application,
        Page,
        MasterPage,
        Control
    }

    public class EventDescription
    {
        public EventSource Source { get; set; }
        public string Type { get; set; }
    }
    public class EventCollection
    {
        private static List<EventDescription> _events = new List<EventDescription>();

        public static void Add(EventSource level, string type)
        {
            _events.Add(new EventDescription { Source = level, Type = type });
            System.Diagnostics.Debug.WriteLine("Event: {0}, {1}", level, type);
        }

        public static IEnumerable<EventDescription> Events
        {
            get { return _events; }
        }
    }
}