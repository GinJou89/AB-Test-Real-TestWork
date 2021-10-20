using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AB_Test_Real_TestWork.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано Имя")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана дата регистрации")]
        [DataType(DataType.DateTime)]
        public DateTime DateRegistration { get; set; }

        [Required(ErrorMessage = "Не указана дата последне активности")]
        [DataType(DataType.DateTime)]
        public DateTime DateLastActivity { get; set; }
    }
}
