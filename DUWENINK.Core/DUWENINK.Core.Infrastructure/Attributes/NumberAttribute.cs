using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace DUWENINK.Core.Infrastructure.Attributes
{
        public class NumberAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                return value!=null&& !string.IsNullOrEmpty(value.ToString()) && Regex.IsMatch(value.ToString(), @"^(\d)|(\d\.0{*})$");
            }
        }
    }

