﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Services.Mail
{
    public interface IMailManager
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
