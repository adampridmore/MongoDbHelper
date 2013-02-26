namespace MongoDbHelper.Models
{
    public class ObjectIdModel
    {
        public string CreationDateTimeText { get; set; }
        public string ObjectIdText { get; set; }

        public bool Valid { get; set; }

        public int? Machine { get; set; }

        public short? Pid { get; set; }

        public int? Increment { get; set; }

        public int? Timestamp { get; set; }
    }
}