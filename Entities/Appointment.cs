using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Appointment : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }


    }
}
