using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteTODO.ApiModels
{
    public class ToDoItemDTO
    {
        public int Id { set; get; }
        public string UserId { set; get; }
        public string Describtion { set; get; }
        public bool IsChecked { set; get; }
        public DateTime Date { set; get; }
    }
}
