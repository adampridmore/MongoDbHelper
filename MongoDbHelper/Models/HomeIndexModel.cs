using System.Collections.Generic;

namespace MongoDbHelper.Models
{
    public class HomeIndexModel
    {
        public HomeIndexModel()
        {
            ObjectIds = new List<ObjectIdModel>();
        }

        public List<ObjectIdModel> ObjectIds { get; set; }

        public string ObjectIdText { get; set; }
    }
}