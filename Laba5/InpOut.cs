using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Laba5.Classes;

namespace Laba5
{

    [Serializable]
    public class Save
    {
        public CSt<Library> data;

        [NonSerialized]
        public static string ext = ".ls";

        public void SaveItem(string name, CSt<Library> _data)
        {
            data = _data;
            Stream stream = null;
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(name + ext, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            if (stream != null)
            {
                stream.Close();
            }
        }

        public CSt<Library> LoadItem(string name)
        {
            try
            {
                Save container = null;
                Stream stream = null;
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(name + ext, FileMode.Open, FileAccess.Read, FileShare.None);
                container = (Save)formatter.Deserialize(stream);

                if (stream != null)
                {
                    stream.Close();
                    return container.data;
                }
            }
            catch (Exception exp)
            {
                string message = "Запрашиваемый файл не существует.";
                string caption = "Не найден файл";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult res;
                res = MessageBox.Show(message, caption, button);
            }
            return null;
        }
    }
}
