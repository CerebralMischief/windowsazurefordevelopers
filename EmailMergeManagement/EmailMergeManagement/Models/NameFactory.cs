using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmailMergeManagement.Models
{
    public class NameFactory
    {
        private readonly int _numberOfnames;
        private readonly string _sexOfNames;

        public NameFactory(int numberOfnames)
        {
            _numberOfnames = numberOfnames;
            _sexOfNames = "both";
        }

        public int NumberOfnames
        {
            get { return _numberOfnames; }
        }

        public string SexOfNames
        {
            get { return _sexOfNames; }
        }

        public IEnumerable<FullNameModel> BuildFullNames()
        {
            var myLog = new EventLog {Source = "MySource"};
            myLog.WriteEntry("Building Names: " + DateTime.Now.ToLongTimeString());

            var listOfNames = NameRepository.GetPersonNames() as List<PersonName>;
            
            var bytesFirst = new byte[20];
            var bytesLast = new byte[10];
            var randomFirst = new Random();
            var randomLast = new Random();

            randomFirst.NextBytes(bytesFirst);
            randomLast.NextBytes(bytesLast);

            var finalListOfNames = new List<FullNameModel>();

            for (int i = 0; i < NumberOfnames; i++)
            {
                var fullName = new FullNameModel();
                var randomNumberFromFirst = randomFirst.Next(0, listOfNames.Count);
                var firstNameAndSex = listOfNames[randomNumberFromFirst];
                
                switch (firstNameAndSex.SexOf)
                {
                    case "female":
                        fullName.SexOf = SexOfName.Female;
                        break;
                    case "male":
                        fullName.SexOf = SexOfName.Male;
                        break;
                    default:
                        fullName.SexOf = SexOfName.Both;
                        break;
                }

                fullName.First = firstNameAndSex.Name;
               var  randomNumberFromLast = randomLast.Next(0, listOfNames.Count);
                fullName.Last = listOfNames[randomNumberFromLast].Name;
                finalListOfNames.Add(fullName);
            }
            
            myLog.WriteEntry("Building Names: " + DateTime.Now.ToLongTimeString());
            return finalListOfNames;
        }
    }
}