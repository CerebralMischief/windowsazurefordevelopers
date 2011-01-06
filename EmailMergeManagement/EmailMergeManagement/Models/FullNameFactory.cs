using System.Collections.Generic;

namespace EmailMergeManagement.Models
{
    public class FullNameFactory
    {
        private readonly int _numberOfnames;
        private readonly SexOfName _sexOfNameOfNames;

        public int NumberOfnames
        {
            get { return _numberOfnames; }
        }

        public SexOfName SexOfNameOfNames
        {
            get { return _sexOfNameOfNames; }
        }

        public FullNameFactory(int numberOfnames, SexOfName sexOfNameOfNames)
        {
            _numberOfnames = numberOfnames;
            _sexOfNameOfNames = sexOfNameOfNames;
        }

        public IEnumerable<FullNameModel> BuildFullNames()
        {
            var listOfNames = new List<FullNameModel>();
            


            return listOfNames;
        }
    }
}