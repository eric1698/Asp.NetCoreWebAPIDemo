using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Message { get; set; }
        public DateTime ModifyTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }

    }
}
