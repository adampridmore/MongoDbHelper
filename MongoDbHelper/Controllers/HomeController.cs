using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDbHelper.Models;

namespace MongoDbHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string objectIds)
        {
            var homeIndexModel = new HomeIndexModel();

            if (string.IsNullOrWhiteSpace(objectIds))
            {
                return View(homeIndexModel);
            }

            var objectIdsList = objectIds
                .Split(',')
                .Where(s => !String.IsNullOrWhiteSpace(s));

            homeIndexModel.ObjectIdText = string.Join("\n", objectIdsList);

            var lines = new List<ObjectIdModel>();
            foreach (var objectIdText in objectIdsList)
            {
                lines.Add(ObjectIdToFormattedText(objectIdText));
            }

            homeIndexModel.ObjectIds = lines;
            return View(homeIndexModel);
        }

        private ObjectIdModel ObjectIdToFormattedText(string objectIdText)
        {
            var objectIdModel = new ObjectIdModel
            {
                ObjectIdText = objectIdText
            };

            try
            {
                var objectId = new ObjectId(objectIdText);
                objectIdModel.CreationDateTimeText = objectId
                    .CreationTime
                    .ToString("o");

                objectIdModel.Machine = objectId.Machine;
                objectIdModel.Pid = objectId.Pid;
                objectIdModel.Increment = objectId.Increment;
                objectIdModel.Timestamp = objectId.Timestamp;

                objectIdModel.Valid = true;
            }
            catch (Exception)
            {
                objectIdModel.Valid = false;
            }

            return objectIdModel;
        }
    }
}
