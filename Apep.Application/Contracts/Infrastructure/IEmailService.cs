﻿using Apep.Application.Models.Mail;
using System.Threading.Tasks;

namespace Apep.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
