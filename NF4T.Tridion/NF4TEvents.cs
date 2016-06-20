using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using NF4T.Models;
using NF4T.OData.Models;
using Tridion.ContentManager;
using Tridion.ContentManager.ContentManagement;
using Tridion.ContentManager.Extensibility;
using Tridion.ContentManager.Extensibility.Events;

namespace NF4T.Tridion
{
    [TcmExtension("NF4TEvents Events")]
    public class NF4TEvents : TcmExtension
    {
        public NF4TEvents()
        {
            Subscribe();
        }

        public void Subscribe()
        {
            //Workflow Related Events
            EventSystem.SubscribeAsync<IdentifiableObject, EventArgs>(EventHandler, EventPhases.All);
        }

        private void EventHandler(IdentifiableObject subject, EventArgs eventArgs, EventPhases phase)
        {
            var record = new Record();

            //Set Environment
            record.Environment = new CMEnvironment
            {
                Name = ConfigurationManager.AppSettings.Get("NF4T_CMEnvironmentKey")
            };

            //Set Subject
            record.Subject = new Subject
            {
              TcmId = subject.Id,
              Title = subject.Title,
              Type = subject.GetType(),
              CreationDate = subject.CreationDate,
              LastModifiedDate = subject.RevisionDate
            };

            //Extract ItemTypeSpecifics
            if (subject is Component)
            {
                var component = subject as Component;
                record.Subject.SchemaTcmId = component.Schema.Id.ToString();
            }

            //Set Event
            record.Event = new Event
            {
                Type = eventArgs.GetType(),
                TimeStamp = DateTime.Now
            };

            //Extract ItemTypeSpecifics
            if (eventArgs is SaveEventArgs)
            {
                var saveEventArgs = eventArgs as SaveEventArgs;
                record.Event.IsNewItem = saveEventArgs.IsNewItem;
            }

            //Extract EventType Specifics
            switch (eventArgs.GetType().Name)
            {
                case "SaveEventArgs":

                    break;
                default:
                    break;
            }

            var events = eventArgs as SaveEventArgs;
        }

        private void Post(Event @event)
        {
            string url = ConfigurationManager.AppSettings.Get("NF4T_PostUrl");

            HttpClient client = new HttpClient();
            HttpContent content = new ObjectContent<Event>(@event, new JsonMediaTypeFormatter());
            client.PostAsync(url, content);
        }
    }
}
