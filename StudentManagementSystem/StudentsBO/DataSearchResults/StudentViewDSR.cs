#region Reference
using System.ComponentModel.DataAnnotations;
#endregion Referrence

namespace StudentsBO.DataSearchResults
{
    public class StudentViewDSR
    {
        /// <summary>
        /// Gets or sets the roll number.
        /// </summary>
        /// <value>
        /// The roll number.
        /// </value>
        [Display(Name = "Roll Number")]
        [Required(ErrorMessage = "Register Number Required")]
        public int RollNumber { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Student Name is Required")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the standard.
        /// </summary>
        /// <value>
        /// The standard.
        /// </value>
        [Display(Name = "Standard")]
        [Required(ErrorMessage = "Enter the Standard")]
        public string Standard { get; set; }

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        [Display(Name = "Section")]
        [Required(ErrorMessage = "Enter the Student Section")]
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Enter the Student Gender")]
        public char Gender { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Enter the Student Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        //[RegularExpression=""]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address Cannot be Empty")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [Display(Name = "Language")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        public int Language { get; set; }

        /// <summary>
        /// Gets or sets the english.
        /// </summary>
        /// <value>
        /// The english.
        /// </value>
        [Display(Name = "English")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        public int English { get; set; }

        /// <summary>
        /// Gets or sets the maths.
        /// </summary>
        /// <value>
        /// The maths.
        /// </value>
        [Display(Name = "Maths")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        public int Maths { get; set; }

        /// <summary>
        /// Gets or sets the science.
        /// </summary>
        /// <value>
        /// The science.
        /// </value>
        [Display(Name = "Science")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        public int Science { get; set; }

        /// <summary>
        /// Gets or sets the social.
        /// </summary>
        /// <value>
        /// The social.
        /// </value>
        [Display(Name = "Social")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        public int Social { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        [Display(Name = "Total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>
        /// The percentage.
        /// </value>
        [Display(Name = "Percentage")]
        public float Percentage { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        [Display(Name = "Result")]
        public char Result { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Entering the ReMark is mandatory")]
        public string Remarks { get; set; }
    }
}
