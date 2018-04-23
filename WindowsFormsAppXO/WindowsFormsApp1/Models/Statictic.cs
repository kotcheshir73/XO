using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    [XmlType("stat")]
    public class Statistic
    {
        [XmlElement("date")]
        public DateTime Date { get; set; }

        [XmlElement]
        public GameState Result { get; set; }

        [XmlAttribute("step")]
        public int StepCounter { get; set; }
        
        [XmlIgnore]
        public bool UserFirst { get; set; }
    }
}
