 System.Xml.Serialization.XmlSerializer deserializer = new System.Xml.Serialization.XmlSerializer(stg.GetType());
stg = (Settings)deserializer.Deserialize(new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "stg.xml", FileMode.Open))
