using imotoAPI.Exceptions;
using imotoAPI.Models;
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
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(notFoundException.Message));
            }
            catch (ForbidException forbidException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(forbidException.Message));
            }
            catch (NotAllowedException notAllowedException)
            {
                context.Response.StatusCode = 405;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(notAllowedException.Message));
            }
            catch(ResourceExsistsException resourceExsistsException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(resourceExsistsException.Message));
            }
            catch (IncorrectLoggingException incorrectLoginException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(incorrectLoginException.Message));
            }
            catch (LoginNotUniqueException loginNotUniqueException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(loginNotUniqueException.Message));
            }
            catch (OldNewPasswordException oldNewPasswordException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(oldNewPasswordException.Message));
            }
            catch (WatchedUserException watchedUserException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto(watchedUserException.Message));
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException dbUpdateException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new MessageReturnDto("Bad request"));
            }
        }
    }
}
