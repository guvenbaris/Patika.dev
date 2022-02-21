using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.ECommerce.Services
{
    //İleriki zamanlarda Loglama türümüzü değiştirebilmek için ILoggerService interface'ı tanımlanmıştır.
    public interface ILoggerService
    {
        public void Log(string message);
    }
}
