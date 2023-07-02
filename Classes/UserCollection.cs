using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CoorseProdject01.Classes
{
    [Serializable]
    class UserCollection
    {
        public List<User> Users { get; set; } = new List<User>();

        public void SerializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                //new XmlRootAttribute("user_list"));

            using (FileStream fs = new FileStream(Const.UserFileName, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, Users);
            }
        }

        public void DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<User>));
                //new XmlRootAttribute("user_list"));

            using (FileStream fs = new FileStream(Const.UserFileName, FileMode.OpenOrCreate))
            {
                Users.Clear();
                //User OneUser = new User();
                //q = (User)xml.Deserialize(fs);
                Users = (List<User>)xml.Deserialize(fs);
            }
        }
    }
}
