using System.Collections.Generic;

namespace MongoDbHelper.Models
{
    public class EncodeIndexModel
    {
        public string Timestamps { get; set; }
        public List<string> ObjectIds { get; set; }
        public string ObjectIdsText { get; set; }

        public EncodeIndexModel()
        {
            ObjectIds = new List<string>();
        }
    }
}