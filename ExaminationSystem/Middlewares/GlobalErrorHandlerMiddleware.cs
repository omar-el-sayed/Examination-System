using System.Diagnostics;

namespace ExaminationSystem.Middlewares
{
    public class GlobalErrorHandlerMiddleware(RequestDelegate _next)
    {
        #region before primary constructor
        //private readonly RequestDelegate _next;

        //public GlobalErrorHandlerMiddleware(RequestDelegate next)
        //{
        //    _next = next;
        //}
        #endregion

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Call the next middleware in the pipeline
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
