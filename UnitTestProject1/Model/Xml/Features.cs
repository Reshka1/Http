using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace UnitTestProject1.Model.Xml
{
    [XmlElement(ElementName = "Feature")]
    public class Features
    {
        [XmlElement(ElementName = "Feature")]
        public List<string> Feature { get; set; }
    }
}
