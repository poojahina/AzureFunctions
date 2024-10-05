using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FirstAzFunction.Model;
using Azure;
using System.Data.Entity;
using FirstAzFunction.Data;

namespace FirstAzFunction
{
    public static  class OnEmployeeUploadWriteToQueue
    {
       
        [FunctionName("OnEmployeeUploadWriteToQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, [Queue("EmployeeQueue",Connection = "AzureWebJobsStorage")] IAsyncCollector<Employee> employeeQueue, 
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string salary = req.Query["salary"];
            string department = req.Query["department"];

            Employee employee = new Employee()
            {
                Name = name,
                Salary = Convert.ToDecimal(salary),
                Department = department
            };
            await employeeQueue.AddAsync(employee);
            var responseMessage = employee;

            return new OkObjectResult(responseMessage);
        }
    }
}
