using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using RealEstate.Data.Contexts;
using RealEstate.Data.Repository;
using RealEstate.Data.Repository.IRepository;
using RealEstate.Infrastructure.MailHelper;
using RealEstate.Model;
using RealEstate.Model.QueueMessage;

namespace RealEstate.Notification.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("realestatenotificationqueue")] string message, TextWriter log)
        {
            var queueMessage = JsonConvert.DeserializeObject<PropertyChangeNotificationMessage>(message);
            HandlePropertyChangeNotificationMessage(queueMessage);

            log.WriteLine(message);
        }

        private static void HandlePropertyChangeNotificationMessage(PropertyChangeNotificationMessage propertyChangeNotificationMessage)
        {
            IRealEstateContext context = new RealEstateContext(ConfigurationManager.ConnectionStrings["RealEstateConnection"].ToString());
            IRealEstatePropertyInterestRepository realEstatePropertyInterestRepository = new RealEstatePropertyInterestRepository(context);
            IRealEstateNotificationRepository realEstateNotificationRepository = new RealEstateNotificationRepository(context);
            var propertyInterests = realEstatePropertyInterestRepository.GetRealEstatePropertyInterests(propertyChangeNotificationMessage.PropertyId);
            foreach (var propertyInterest in propertyInterests)
            {
                //Create Notification
                var notification = new RealEstateNotification
                {
                    Message = "Property Modification. Please check",
                    PropertyId = propertyChangeNotificationMessage.PropertyId,
                    UserId = propertyInterest.UserId
                };
                realEstateNotificationRepository.CreateRealEstateNotification(notification);

                //Send Email Notification
                MailHelper mailHelper = new MailHelper();
                mailHelper.Recipient = propertyInterest.User.UserName;
                mailHelper.Subject = "Property Change Notification";
                mailHelper.Sender = ConfigurationManager.AppSettings["EmailFromAddress"];
                mailHelper.Body = $"Property - {propertyInterest.Property.PropertyName} is modified. Please check the app for details";
                mailHelper.Send();
            }
        }
    }
}
