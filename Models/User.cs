using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AB_Test_Real_TestWork.Models
{
    public class User
    {
        /// <summary>
        /// ID Пользователя
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Required(ErrorMessage = "Не указана дата регистрации")]
        [DataType(DataType.DateTime)]
        public DateTime DateRegistration { get; set; }
        /// <summary>
        /// Дата последней активности
        /// </summary>
        [Required(ErrorMessage = "Не указана дата последне активности")]
        [DataType(DataType.DateTime)]
        public DateTime DateLastActivity { get; set; }
    }
}
