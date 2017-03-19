using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Xml;
using JsonXmlConvertParserToDB.Database;

namespace JsonXmlConvertParserToDB.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string _stream;
        private string _filename;
        private string _fileparse;
        private string _filecontent;
        private string _fileparseLastName;
        private string _fileparseAge;
        private string _fileparseAddressStreet;
        private string _fileparseAddressCity;
        private string _fileparseAddressState;
        private string _fileparsePhone;
        private string _fileparsePhoneF;
        private string _fileparseName;
        private string _fileparseAddressCode;
        private string _fileparseType;
        private string _fileparseTypeF;
        private string _parseresults;
        private string _parseresults2;
        private string text;
        private string fileName;
        private string fileParse;
        private string fileContent;
        private string parseResults;
        private string parseResults2;

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;

            }
        }

        public string FileName
        {
            get
            {
                return string.IsNullOrEmpty(this.fileName) ? "No file selected" : this.fileName;
            }

            set
            {
                this.fileName = value;

            }
        }

        public string FileParse
        {
            get
            {
                return string.IsNullOrEmpty(this.fileParse) ? "No file selected" : this.fileParse;
            }

            set
            {
                this.fileParse = value;

            }
        }

        public string FileContent
        {
            get
            {
                return string.IsNullOrEmpty(this.fileContent) ? "No file selected" : this.fileContent;
            }

            set
            {
                this.fileContent = value;

            }
        }
        public string ParseResults
        {
            get
            {
                return string.IsNullOrEmpty(this.parseResults) ? "No file selected" : this.parseResults;
            }

            set
            {
                this.parseResults = value;

            }
        }

        public string ParseResults2
        {
            get
            {
                return string.IsNullOrEmpty(this.parseResults2) ? "No file selected" : this.parseResults2;
            }

            set
            {
                this.parseResults2 = value;

            }
        }


        public string StreamA
        {
            get { return _stream; }
            set { SetProperty(ref _stream, value); }
        }

        public string FilenameA
        {
            get { return _filename; }
            set
            { SetProperty(ref _filename, value); }
        }

        public string FileparseA
        {
            get { return _fileparse; }
            set { SetProperty(ref _fileparse, value); }
        }
        public string FileparseLastName
        {
            get { return _fileparseLastName; }
            set { SetProperty(ref _fileparseLastName, value); }
        }
        public string FileparseAge
        {
            get { return _fileparseAge; }
            set { SetProperty(ref _fileparseAge, value); }
        }
        public string FileparseAddressStreet
        {
            get { return _fileparseAddressStreet; }
            set { SetProperty(ref _fileparseAddressStreet, value); }
        }
        public string FileparseAddressCode
        {
            get { return _fileparseAddressCode; }
            set { SetProperty(ref _fileparseAddressCode, value); }
        }

        public string FileparsePhone
        {
            get { return _fileparsePhone; }
            set { SetProperty(ref _fileparsePhone, value); }
        }
        public string FileparsePhoneF
        {
            get { return _fileparsePhoneF; }
            set { SetProperty(ref _fileparsePhoneF, value); }
        }
        public string FileparseType
        {
            get { return _fileparseType; }
            set { SetProperty(ref _fileparseType, value); }
        }
        public string FileparseTypeF
        {
            get { return _fileparseTypeF; }
            set { SetProperty(ref _fileparseTypeF, value); }
        }

        public string FileparseAddressState
        {
            get { return _fileparseAddressState; }
            set { SetProperty(ref _fileparseAddressState, value); }
        }
        public string FileparseAddressCity
        {
            get { return _fileparseAddressCity; }
            set { SetProperty(ref _fileparseAddressCity, value); }
        }

        public string FileparseFirstName
        {
            get { return _fileparseName; }
            set { SetProperty(ref _fileparseName, value); }
        }

        public ICommand SumCommand { get; private set; }
        public ICommand OpenCommandString { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand ParseCommand { get; private set; }
        public string FilecontentP
        {
            get { return _filecontent; }
            set { SetProperty(ref _filecontent, value); }
        }
        public string FilecontentA
        {
            get { return _filecontent; }
            set { SetProperty(ref _filecontent, value); }
        }
        public string FilecontentT
        {
            get { return _filecontent; }
            set { SetProperty(ref _filecontent, value); }
        }

        public string ParseresultsA
        {
            get { return _parseresults; }
            set { SetProperty(ref _parseresults, value); }
        }

        public string ParseresultsA2
        {
            get { return _parseresults2; }
            set { SetProperty(ref _parseresults2, value); }
        }
        public MainWindowViewModel()
        {
            OpenCommandString = new DelegateCommand(onOpenString);
            ParseCommand = new DelegateCommand(onParse);
            SaveCommand = new DelegateCommand(onSave);
        }

        private void onSave()
        {

            using (var dc = new CustomerDB())
            {
                string mvFirstName = FileparseFirstName;
                string mvLastName = FileparseLastName;
                string mvAge = FileparseAge;
                string mvAddressStreet = FileparseAddressStreet;
                string mvAddressCity = FileparseAddressCity;
                string mvAddressState = FileparseAddressState;
                string mvAddressCode = FileparseAddressCode;
                string mvPhone = FileparsePhone;
                string mvPhoneF = FileparsePhoneF;
                var mv = new CustomerSet() { FirstName = mvFirstName, LastName = mvLastName, Age = mvAge };
                var address = new Address() { StreetAddress = FileparseAddressStreet, City = FileparseAddressCity, State = FileparseAddressState, PostalCode = FileparseAddressCode };
                var pone = new PhoneNumber() { Type = FileparseType, Number = FileparsePhone };
                var phoneF = new PhoneNumber() { Type = FileparseTypeF, Number = FileparsePhoneF };
                mv.Addresses.Add(address);
                mv.PhoneNumbers.Add(pone);
                mv.PhoneNumbers.Add(phoneF);
                dc.CustomerSet.Add(mv);
                dc.SaveChanges();
                MessageBox.Show("snimljeno");
            }
        }
        public Stream Stream
        {
            get;
            set;
        }

        public string Extension
        {
            get;
            set;
        }

        public string Filter
        {
            get;
            set;
        }

        private void onOpenString()
        {
            FilenameA = string.Empty;
            FilecontentA = string.Empty;
            FileparseA = string.Empty;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.Filter = "xml files (*.xml)|*.xml|JSON files (*.json)|*.json";
            dlg.Filter = "JSON, XML files (*.json,*.xml)|*.json; *.xml";
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                //string filename = dlg.FileName;
                // string filecontent = dlg.Title;
                FilenameA = dlg.FileName;
                FilecontentA = File.ReadAllText(dlg.FileName);
                FilecontentT = FilecontentT.Trim();
                FilecontentP = FilecontentT.Trim();
                if
           (FilecontentA.StartsWith("<") && FilecontentA.EndsWith(">"))
                {
                    //XML
                    // To convert an XML node contained in string xml into a JSON string   
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(FilecontentA);
                    dynamic jsonDe3 = JsonConvert.SerializeXmlNode(doc);
                    FilecontentP = jsonDe3;
                }
            }
        }

        private void onParse()
        {
            try
            {
                dynamic jsonDe = JsonConvert.DeserializeObject(FilecontentP);
                var FirstName = jsonDe.root.firstName;
                var LastName = jsonDe.root.lastName;
                FileparseFirstName = jsonDe.root.firstName;
                FileparseLastName = jsonDe.root.lastName;
                FileparseAge = jsonDe.root.age;
                FileparseAddressStreet = jsonDe.root.address.streetAddress;
                FileparseAddressCity = jsonDe.root.address.city;
                FileparseAddressState = jsonDe.root.address.state;
                FileparseAddressCode = jsonDe.root.address.postalCode;
                FileparsePhone = jsonDe.root.phoneNumber[0].number;
                FileparsePhoneF = jsonDe.root.phoneNumber[1].number;
                FileparseType = jsonDe.root.phoneNumber[0].type;
                FileparseTypeF = jsonDe.root.phoneNumber[1].type;
                FileparseA = jsonDe.root.firstName + Environment.NewLine + jsonDe.root.lastName + Environment.NewLine + FileparseAge + Environment.NewLine + FileparseAddressStreet + Environment.NewLine + FileparseAddressCity + Environment.NewLine + FileparseAddressState + Environment.NewLine + FileparseAddressCode + Environment.NewLine + FileparsePhone + Environment.NewLine + FileparsePhoneF;
            }
            catch (Exception)
            {
                MessageBox.Show("Nije moguće parsirati odabrani fajl");
            }

        }
    }
}
