using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AB_Test_Real_TestWork.Models
{
    public class UserLifeSpan
    {
        /// <summary>
        /// Сколько дней прожил пользователь в днях
        /// </summary>
        public int LifeSpanDays { get; set; }
        /// <summary>
        /// Количество таких пользователей
        /// </summary>
        public int Count { get; set; }
    }
}
