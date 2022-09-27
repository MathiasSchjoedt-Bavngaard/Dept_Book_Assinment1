using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using Debt_Book.Model;

namespace Debt_Book.Data
{
    // Serializer metoderne herunder er taget fra agent assignment 4 løsningen.
    // https://brightspace.au.dk/d2l/le/lessons/54785/topics/816823 
    public class Repository
    {
        internal static ObservableCollection<Debtor> ReadFile(string fileName)
        {
            // XmlSerializer kan serialize og de-serialize
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>)); 
            TextReader reader = new StreamReader(fileName); // TextReader er en abstrakt klasse som StreamReader nedarver fra
            // Deserialize all the debtors. 
            var debtors = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
            reader.Close();
            return debtors;
        }
        internal static void SaveFile(string fileName, ObservableCollection<Debtor> debtors)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, debtors);
            writer.Close();
        }

    }
}
