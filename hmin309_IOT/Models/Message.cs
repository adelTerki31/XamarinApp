using System;

namespace hmin309_IOT.Models
{
    public class Message
    {
        public long id { get; set; }

        public long student_id { get; set; }

        public string student_message { get; set; }
        public double gps_lat { get; set; }

        public double gps_long { get; set; }
    }
}