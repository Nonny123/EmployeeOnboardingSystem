﻿using Onboarding.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Onboarding.Domain.DTOs
{
    public class UserUpdateProfileDto : UserBase 
    {
        public DateTime LastModified { get; set; }
    }
}
