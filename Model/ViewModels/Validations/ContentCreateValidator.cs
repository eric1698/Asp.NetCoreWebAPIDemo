using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels.Validations
{
    public class ContentCreateValidator : AbstractValidator<ContentCreateViewModel>
    {
        public ContentCreateValidator()
        {
            //ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure; 是宣告一個 RuleFor 有多個檢查條件時，只要檢查到第一個錯就停止往下檢查。
            RuleFor(vm => vm.Name).NotEmpty().WithMessage("姓名不能為空").MaximumLength(128);
            RuleFor(vm => vm.Message).NotEmpty().WithMessage("訊息不能為空").MaximumLength(1024);
        }
    }
}
