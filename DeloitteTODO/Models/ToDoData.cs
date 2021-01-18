using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.Models
{
    public class ToDoData : BaseEntity
    {
        public string UserId { set; get; }
        public string Describtion { set; get; }
        public bool IsChecked { set; get; }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = DateTime.Now; }
        }
    }
}


