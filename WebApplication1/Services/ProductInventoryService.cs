using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class ProductInventoryService : IProductInventoryInterface
    {
        public IList<RequestInventory> GetProductInventory()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(" https://mocki.io/v1/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("0077e191-c3ae-47f6-bbbd-3b3b905e4a60").Result;
            if (response.IsSuccessStatusCode)
            {
                var inventoryData = response.Content.ReadAsStringAsync().Result;
                var inventoryRequests = JsonConvert.DeserializeObject<ResultInventory>(inventoryData);
                var requestInventories = from p in inventoryRequests.requests
                                         join q in inventoryRequests.inventory on p.inventoryId equals q.id
                                         select new RequestInventory
                                         {
                                             requestId = p.id,
                                             inventoryId = p.inventoryId,
                                             inventoryName = q.name,
                                             totalKernels = q.kernels,
                                             requestedKernels = p.requestedKernels,
                                             status = p.requestedKernels > q.kernels ? "Not Sufficient" : "Sufficient"
                                         };
                return requestInventories.ToList();
            }
            return null;
        }
    }
}
