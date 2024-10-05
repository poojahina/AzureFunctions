using System;
using FirstAzFunction.Data;
using FirstAzFunction.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FirstAzFunction
{
    public class OnQueueTriggerDBUpdate
    {
        private readonly EmployeeDBContext employeeDBContext;

        public OnQueueTriggerDBUpdate(EmployeeDBContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }
        [FunctionName("OnQueueTriggerDBUpdate")]
        public void Run([QueueTrigger("EmployeeQueue", Connection = "QueueConnStr")]Employee myQueueItem, ILogger log)
        {
            try
            {
                log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
                employeeDBContext.Add(myQueueItem);
                employeeDBContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
