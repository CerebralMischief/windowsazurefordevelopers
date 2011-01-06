using System.Collections.Generic;
using System.Linq;

namespace EmailMergeManagement.Models
{
    public class NameRepository
    {
        public static IList<PersonName> GetPersonNames()
        {
            using (var namesModelRepository = new namesEntities())
            {
                IList<PersonName> names = (from personNames in namesModelRepository.PersonNames
                                               select personNames).ToList();

                foreach (var personName in names)
                {
                    personName.SexOf = personName.SexOf.Trim();
                }

                return names;
            }
        }
    }
}