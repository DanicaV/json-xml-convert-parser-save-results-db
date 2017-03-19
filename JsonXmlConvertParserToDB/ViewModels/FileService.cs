using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonXmlConvertParserToDB.ViewModels
{
    public sealed class FileService
    {
        public Stream onOpenString(string defaultExtension, string filter)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.DefaultExt = defaultExtension;
            fd.Filter = filter;
            bool? result = fd.ShowDialog();
            return result.Value ? fd.OpenFile() : null;
        }

        public Stream SaveFile(string defaultExtension, string filter)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = defaultExtension;
            fd.Filter = filter;
            bool? result = fd.ShowDialog();
            return result.Value ? fd.OpenFile() : null;
        }

    }
}
