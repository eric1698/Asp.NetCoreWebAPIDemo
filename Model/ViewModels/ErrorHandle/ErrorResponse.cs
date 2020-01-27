using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels.ErrorHandle
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
