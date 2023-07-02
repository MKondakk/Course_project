using System;
using System.Xml.Serialization;


namespace CoorseProdject01.Classes
{
    [Serializable]
    public class Prisoner
    {
        public Prisoner()
        {
        }
        public Prisoner(string firstname, string lastname, DateTime birthday, string sex, string article, string term, DateTime startdate, 
            string hierarchy, int room, string relatives, string character, bool saved, string id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Birthday = birthday;
            Sex = sex;
            Article = article;
            Term = term;
            Startdate = startdate;
            Hierarchy = hierarchy;
            Room = room;
            Relatives = relatives;
            Character = character;
            Saved = saved;
            Id = id; 

        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string Article { get; set; }

        public string Term { get; set; }
        public DateTime Startdate { get; set; }
        public string Hierarchy { get; set; }
        public int Room { get; set; }

        public string Relatives { get; set; }
        public string Character { get; set; }
        public bool Saved { get; set; }
        public string Id { get; set; }


    }

}
