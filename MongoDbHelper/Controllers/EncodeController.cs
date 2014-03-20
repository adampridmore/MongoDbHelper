using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDbHelper.Models;

namespace MongoDbHelper.Controllers
{
    public class EncodeController : Controller
    {
        //
        // GET: /Encode/

        public ActionResult Index(string timestamps)
        {
            var encodeIndexModel = new EncodeIndexModel();

            if (string.IsNullOrWhiteSpace(timestamps))
            {
                return View(encodeIndexModel);
            }

            var timestampList = timestamps
                .Split(',')
                .Where(s => !String.IsNullOrWhiteSpace(s));

            encodeIndexModel.Timestamps = string.Join("\n", timestampList.ToArray());

            var lines = new List<string>();
            foreach (var timestampText in timestampList)
            {
                lines.Add(TimeStampToObjectId(timestampText));
            }

            encodeIndexModel.ObjectIds = lines;
            encodeIndexModel.ObjectIdsText = String.Join(Environment.NewLine, lines);
            
            return View(encodeIndexModel);
        }

        private string TimeStampToObjectId(string timestampText)
        {
            DateTime dateTime;
            if (DateTime.TryParse(timestampText, out dateTime))
            {
                return new ObjectId(dateTime, 0, 0, 0).ToString();
            }

            return "Invalid DateTime: " + timestampText;
        }
    }
}
