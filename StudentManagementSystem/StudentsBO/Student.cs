/****************************************************************************************
                         CREATED BY  : Prasana
                         DESCRIPTION : Student Class
                         CREATED ON  : 16.07.2013 
 ****************************************************************************************/

#region References
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

#region Student Class
namespace StudentsBO
{
    public class Student
    {
        public Student()
        {
            StudentMarks = new List<StudentMark>();
        }

        /// <summary>
        /// Gets or sets the roll number.
        /// </summary>
        /// <value>
        /// The roll number.
        /// </value>
        /// ^[0-9]*$
        
        [Display(Name = "Roll Number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only Number")]
        [Required(ErrorMessage = "Register Number Required")]
        public int RollNumber { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Student Name")]
        [RegularExpression(@"^[A-z]+$", ErrorMessage = "Only Char")]
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
        [RegularExpression(@"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", ErrorMessage = "Enter only in Character")]
        public string Standard { get; set; }

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        [Display(Name = "Section")]
        [Required(ErrorMessage = "Enter the Student Section")]
        [RegularExpression(@"[A-Z]", ErrorMessage = "Only Upper Case")]
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [Display(Name="Gender")]
        [Required(ErrorMessage = "Enter the Student Gender")]
        [RegularExpression(@"^M(ale)?$|^F(emale)?$", ErrorMessage = "Enter only in Roman letter")]
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
        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "Enter Phone Number Starts with 7/8/9")]
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
        public DateTime Modified_At { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the student marks.
        /// </summary>
        /// <value>
        /// The student marks.
        /// </value>
        public List<StudentMark> StudentMarks { get; set; }

    }
}
#endregion Student Class