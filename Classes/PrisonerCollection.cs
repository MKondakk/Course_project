using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace CoorseProdject01.Classes
{
    [Serializable]
    class PrisonerCollection
    {
        public List<Prisoner> Prisoners { get; set; } = new List<Prisoner>();

        public void SerializeXML()
        {
            File.Delete(Const.PrisonerFileName);
            XmlSerializer xml = new XmlSerializer(typeof(List<Prisoner>));

            using (FileStream fs = new FileStream(Const.PrisonerFileName, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, Prisoners);
            }
        }

        public void DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Prisoner>));

            using (FileStream fs = new FileStream(Const.PrisonerFileName, FileMode.OpenOrCreate))
            {
                Prisoners.Clear();
                Prisoners = (List<Prisoner>)xml.Deserialize(fs);
            }
        }
    }
}
