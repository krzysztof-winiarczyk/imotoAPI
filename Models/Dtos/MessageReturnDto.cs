using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imotoAPI.Models
{
    public class MessageReturnDto
    {
        public string Message { get; set; }

        public MessageReturnDto(string message)
        {
            Message = message;
        }

        public MessageReturnDto()
        {

        }
    }
}
