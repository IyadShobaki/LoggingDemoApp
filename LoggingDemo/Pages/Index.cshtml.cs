using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LoggingDemo.Pages
{
    public class IndexModel : PageModel
    {



        //// The standard way of capturing the category
        //private readonly ILogger<IndexModel> _logger;
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        // Another way to do it
        private readonly ILogger _logger;
        public IndexModel(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("DemoCategory");
        }

        public void OnGet()
        {


            // Different levels of logging
            // The first two are for pretty heavy debugging 
            _logger.LogTrace("This is a trace log");
            _logger.LogDebug("This is a debug log");
            // A flow of how your application is being used
            _logger.LogInformation("This is an information log");
            // Catch exceptions (ex: the user try to open a file and the file wasn't there)
            _logger.LogWarning("This is a warning log");
            // Unexpected or unhandled (ex: the database wasn't available temporarily)
            _logger.LogError("This is an error log");
            // Massive issue/s. The application crash. (ex: lossing data, server out of disk space)  
            _logger.LogCritical("This is a critical log");

            // The most two are used (LogInforamtion and LogWarning)

            //_logger.LogInformation(LoggingId.DemoCode ,"This our first logged message.");


            //// Advanced logging messages
            //_logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow);

            //try
            //{
            //    throw new Exception("You forget to catch me");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogCritical(ex, "There was a bad exception at {Time}", DateTime.UtcNow);
            //}

        }
    }
    public class LoggingId // If we need to create an Id
    {
        public const int DemoCode = 1001;
    }
}

//Someone question
//Debug logs are not getting printed. Any suggestion , I am using 3.1 . Please suggest .
// IAmTimCorey answer:
//The main functionality, no.The only change is that 
//Kestrel(one option for launching a web application) 
//has some updated restrictions in the appsettings.json 
//and appsettings.developer.json files that will limit what you see 
//for logging from the Microsoft side of things (they reduced the chattiness of the app).

//Another question: Tim, do you know if there's any updates to this from core 3.0 to 3.1?
// IAmTimCorey answer:
//The main functionality, no. The only change is that Kestrel
//(one option for launching a web application) has some updated
//restrictions in the appsettings.json and appsettings.developer.json
//files that will limit what you see for logging from the Microsoft side
//of things (they reduced the chattiness of the app).