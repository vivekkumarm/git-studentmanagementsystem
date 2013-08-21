/****************************************************************************************
                         CREATED BY  : VIVEK
                         DESCRIPTION : StudentDSR Class
                         CREATED ON  : 16.07.2013 
 ****************************************************************************************/

#region References
using System.ComponentModel.DataAnnotations;
#endregion

#region StudentDSR Class
namespace StudentsBO.DataSeachResults
{
    public class StudentDSR
    {
        /// <summary>
        /// Gets or sets the roll_number.
        /// </summary>
        /// <value>
        /// The roll_number.
        /// </value>
        [Required(ErrorMessage = "Register Number")]
        [Display(Name = "Register Number")]
        public int roll_number { get; set; }

        /// <summary>
        /// Gets or sets the student_name.
        /// </summary>
        /// <value>
        /// The student_name.
        /// </value>
        [Required(ErrorMessage = "Student Name")]
        [Display(Name = "Students Name")]
        public string student_name { get; set; }

        /// <summary>
        /// Gets or sets the standard.
        /// </summary>
        /// <value>
        /// The standard.
        /// </value>
        [Required(ErrorMessage = "Standard")]
        [Display(Name = "Standard")]
        public string standard { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [Display(Name = "Language")]
        [Required(ErrorMessage = "Language")]
        public int language { get; set; }

        /// <summary>
        /// Gets or sets the english.
        /// </summary>
        /// <value>
        /// The english.
        /// </value>
        public int english { get; set; }

        /// <summary>
        /// Gets or sets the maths.
        /// </summary>
        /// <value>
        /// The maths.
        /// </value>
        public int maths { get; set; }

        /// <summary>
        /// Gets or sets the science.
        /// </summary>
        /// <value>
        /// The science.
        /// </value>
        public int science { get; set; }

        /// <summary>
        /// Gets or sets the social.
        /// </summary>
        /// <value>
        /// The social.
        /// </value>
        public int social { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        [Display(Name = "Result")]
        [Required(ErrorMessage = "Result Required")]
        public char result { get; set; }
    }
}
#endregion StudentDSR Class