using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CadastroDeClientesWEBIII.Filters
{
    public class LogResourceFilter
    {
        Stopwatch stopWatch = new Stopwatch();
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.Keys.Contains("Code"))
            {
                context.HttpContext.Request.Headers.Add("Code", Guid.NewGuid().ToString());
            }
            stopWatch.Start();
            Console.WriteLine("Filtro de Resource LogResourceFilter (ANTES) OnResourceExecuted.");
            
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource LogResourceFilter (APÓS) OnResourceExecuted.");
            stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(stopWatch.Elapsed);// "RunTime " + elapsedTime);
        }
        
        
        
        

    }
}
