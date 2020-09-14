using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaPruba1.Models
{
    public enum CategoryType
    {
        Estudiante=10,
        Docente=20,
        Administrativo=30,
        Coordinador_Academico=40,
        Seguridad=50
    }
    public class Pruba1
    {
        [Key]
        public int ZambranaID { get; set; }

        [Required(ErrorMessage ="You must enter the field {0}")]
        [StringLength(24,ErrorMessage ="The field {0} must contain between {2} and {1} characters", MinimumLength =2)]
        [Display(Name ="Nombre Completo")]
        public string FriendofZambrana { get; set; }

        [Required(ErrorMessage = "You must enter the field {0}")]
        public CategoryType Place { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        
        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }


    }
}