using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.StorageClient;

namespace EmailMergeManagement.Models
{
    public class EmailMergeModel : TableServiceEntity
    {
        public EmailMergeModel(string partitionKey, string rowKey)
            : base(partitionKey, rowKey)
        {
        }

        public EmailMergeModel()
            : this(Guid.NewGuid().ToString(), string.Empty)
        {
        }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9_\\+-]+(\\.[a-z0-9_\\-]+)*\\.([a-z]{2,4})$",
            ErrorMessage = "Not a valid e-mail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string First { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string Last { get; set; }

        public DateTime LastEditStamp { get; set; }
    }
}