using PTST.UiPath.Orchestrator.API;
using PTST.UiPath.Orchestrator.Models;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uip = new Orchestrator(Environment.GetEnvironmentVariable("PTST_UIP_TENANT")!.ToString(), Environment.GetEnvironmentVariable("PTST_UIP_APPID")!.ToString(), Environment.GetEnvironmentVariable("PTST_UIP_APPSECRET")!.ToString(), "offline_access OR.Tasks OR.Webhooks OR.ML OR.Monitoring OR.Folders OR.BackgroundTasks OR.TestSets OR.TestSetExecutions OR.TestSetSchedules OR.TestDataQueues OR.Audit OR.License OR.Settings OR.Robots OR.Machines OR.Execution OR.Assets OR.Administration OR.Users OR.Jobs OR.Queues");
            var newFolder = new Folder()
            {
                DisplayName = "Test123",
                ProvisionType = FolderProvisionType.Manual,
                PermissionModel = FolderPermissionModel.InheritFromTenant
            };
            //var newF = uip.Create(newFolder).Result;



            var folders = uip.GetAll<Folder>().Result;
            var folder = folders[0];
            var qds = uip.GetAll<QueueDefinition>(folder).Result;
            foreach (var queue in qds)
            {
                IUipathResponseSingle[] test = new IUipathResponseSingle[] { queue };
                var queueItems = uip.GetAll<QueueItem>(folder, filters: test).Result;
            }
        }
    }
}