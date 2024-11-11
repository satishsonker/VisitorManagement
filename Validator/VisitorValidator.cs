
using FluentValidation;
using System;
using VisitorManagement.DataModels;
using VisitorManagement.DTO;

namespace VisitorManagement.Validator
{

    public class VisitorValidator : AbstractValidator<Visitor>
    {
        public VisitorValidator()
        {
            RuleFor(v => v.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(v => v.GovernmentIdTypeId).GreaterThan(0).WithMessage("Government ID Type is required.");
            RuleFor(v => v.VisitDate)
                .NotEmpty().WithMessage("Visit date is required.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Visit date cannot be in the past.");
            RuleFor(v => v.VisitTime).NotEmpty().WithMessage("Visit time is required.");
            RuleFor(v => v.Gender).NotEmpty().WithMessage("Gender is required.");
            RuleFor(v => v.ContactNo).NotEmpty().WithMessage("Contact number is required.");
            RuleFor(v => v.Address).NotEmpty().WithMessage("Address is required.");
        }
    }

}
