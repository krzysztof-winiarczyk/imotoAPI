using imotoAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace imotoAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch(ResourceExsistsException resourceExsistsException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(resourceExsistsException.Message);
            }
            catch (IncorrectLoggingException incorrectLoginException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(incorrectLoginException.Message);
            }
            catch (LoginNotUniqueException loginNotUniqueException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(loginNotUniqueException.Message);
            }
            catch (OldNewPasswordException oldNewPasswordException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(oldNewPasswordException.Message);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException dbUpdateException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(dbUpdateException.Message);
            }
        }
    }
}
