/****************************************************************************************

                         CREATED BY  : Prasana
                         DESCRIPTION : StudentMark Class
                         CREATED ON  : 16.07.2013 
 ****************************************************************************************/

#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
#endregion

#region StudentMark CLass
namespace StudentsBO
{
    public class StudentMark
    {
        /// <summary>
        /// Gets or sets the student mark id.
        /// </summary>
        /// <value>
        /// The student mark id.
        /// </value>
        public int StudentMarkId { get; set; }

        /// <summary>
        /// Gets or sets the roll number.
        /// </summary>
        /// <value>
        /// The roll number.
        /// </value>
        [Display(Name = "Roll Number")]
        public int RollNumber { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>"^\\d{1,3}$"
        [Display(Name = "Language")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Enter only in Number with Max 2 Numbers ")]
        public int Language { get; set; }

        /// <summary>
        /// Gets or sets the english.
        /// </summary>
        /// <value>
        /// The english.
        /// </value>
        [Display(Name = "English")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Enter only in Number with Max 2 Numbers ")]
        public int English { get; set; }

        /// <summary>
        /// Gets or sets the maths.
        /// </summary>
        /// <value>
        /// The maths.
        /// </value>
        [Display(Name = "Maths")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Enter only in Number with Max 2 Numbers ")]
        public int Maths { get; set; }

        /// <summary>
        /// Gets or sets the science.
        /// </summary>
        /// <value>
        /// The science.
        /// </value>
        [Display(Name = "Science")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Enter only in Number with Max 2 Numbers ")]
        public int Science { get; set; }

        /// <summary>
        /// Gets or sets the social.
        /// </summary>
        /// <value>
        /// The social.
        /// </value>
        [Display(Name = "Social")]
        [Required(ErrorMessage = "Entering the Mark is mandatory")]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Enter only in Number with Max 2 Numbers ")]
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
        [RegularExpression(@"^(?!\s*$)[-a-zA-Z ]*$", ErrorMessage = "Enter only in Character")]
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the created_ by.
        /// </summary>
        /// <value>
        /// The created_ by.
        /// </value>
        public int Created_By { get; set; }

        /// <summary>
        /// Gets or sets the modified_ by.
        /// </summary>
        /// <value>
        /// The modified_ by.
        /// </value>
        public int Modified_By { get; set; }

        /// <summary>
        /// Gets or sets the created_ at.
        /// </summary>
        /// <value>
        /// The created_ at.
        /// </value>
        public DateTime Created_At { get; set; }

        /// <summary>
        /// Gets or sets the modified_ at.
        /// </summary>
        /// <value>
        /// The modified_ at.
        /// </value>
        public String Modified_At { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }
    }
}
#endregion StudentMark CLass