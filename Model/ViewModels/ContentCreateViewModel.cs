using FluentValidation.Attributes;
using Model.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class ContentCreateViewModel
    {
        public int ContentId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
