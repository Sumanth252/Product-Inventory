using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public class Inventory
    {
        public int id { get; set; }

        public string name { get; set; }

        public int kernels { get; set; }
    }

    public class InventoryRequests
    {
        public int id { get; set; }
        public int inventoryId { get; set; }
        public int requestedKernels { get; set; }
    }

    public class ResultInventory
    {
        public List<Inventory> inventory { get; set; }
        public List<InventoryRequests> requests { get; set; }
    }

    public class RequestInventory
    {
        public int requestId { get; set; }
        public int inventoryId { get; set; }
        public string inventoryName { get; set; }
        public int totalKernels { get; set; }
        public int requestedKernels { get; set; }
        public string status { get; set; }
    }
}
