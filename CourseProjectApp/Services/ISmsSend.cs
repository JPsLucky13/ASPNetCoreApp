using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Services
{
    public interface ISmsSend
    {
        Task SendSmsAsync(string number, string message);
    }
}
