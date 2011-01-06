using System.ComponentModel.DataAnnotations;

namespace EmailMergeManagement.Models
{
    public class DataCreationParametersModel
    {
        /// <summary>
        /// Total number of names to pick.
        /// </summary>
        [Required(ErrorMessage = "You must enter a number of names to pick.")]
        [Range(0, 1000001, ErrorMessage = "Must be greater than zero and less than 1,000,001.")]
        public int Rows { get; set; }
        /// <summary>
        /// If true, males names, if false, female names.
        /// </summary>
        [Required(ErrorMessage = "You must select male or female.")]
        public SexOfName SexOfName { get; set; }
        /// <summary>
        /// Deletes all existing rows in the table store if true.
        /// </summary>
        public bool DeleteExistingRows { get; set; }
    }
}