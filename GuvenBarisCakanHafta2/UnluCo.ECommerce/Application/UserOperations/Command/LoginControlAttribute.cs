using System;
using System.Linq;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using UnluCo.ECommerce.DbOperations;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Application.UserOperations.Command
{

    //User login kontrol işlemini için tanımlanmış Attribute
    public class VerifyUserAttribute :ActionFilterAttribute
    {
        //Attribute 'un tanımlı olduğu method un actionu çalıştığında method çalışacaktır
        //Method'un Action olurken ki parametrelerinden de userName ve password bilgilerini alabildik. 
        //Çünkü biz kullanıcıdan o bilgileri istedik ve bunları da Login class'ı mıza match ettik.
        public override void OnActionExecuting(ActionExecutingContext httpContext)
        {
            Login login = (Login)httpContext.ActionArguments["login"];


            bool result = VerifyUserAndPassword(login);

            if (!result)
            {
                throw new AuthenticationException("Username or password is wrong check again please.");

            }
            Console.WriteLine("Login is successfull");
        }

        //User password ve UserName kontrolü yapılan method.
        public bool VerifyUserAndPassword(Login login)
        {
            var user = DataGenerator.Users.SingleOrDefault(u => u.UserName == login.UserName);

            if (user is null)
            {
                throw new AuthenticationException("Username or password is wrong check again please.");
            }

            if (user.UserName == login.UserName && user.Password == login.Password)
            {
                return true;
            }
            return false;
        }

    }
}
