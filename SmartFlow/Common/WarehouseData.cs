using System;

namespace SmartFlow.Common
{
    public class WarehouseData : EventArgs
    {
        public int WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public WarehouseData(int id, string name)
        {
            WarehouseId = id;
            WarehouseName = name;
        }
    }
}
