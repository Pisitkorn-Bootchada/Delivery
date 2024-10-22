using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korntest.ViewModel
{
    public class DeliveryCostViewModel
    {
        public int DeliveryCostID { get; set; }
        public string DeliveryCostPlant { get; set; }
        public string DeliveryCostSapST { get; set; }
        public string DeliveryCostST { get; set; }
        public string DeliveryCostProvince { get; set; }
        public string DeliveryCostDistrict { get; set; }
        public string DeliveryCostTambon { get; set; }
        public string DeliveryCostDistance { get; set; }
        public string DeliveryCostY4 { get; set; }
        public string DeliveryCostY3 { get; set; }
        public string DeliveryCostY2 { get; set; }
        public string DeliveryCostVendor { get; set; }
        public string DeliveryCostSapEn { get; set; }
        public string DeliveryCostDateCreate { get; set; }
        public string DeliveryCostDateEdit { get; set; }
        public string DeliveryCostStatus { get; set; }
    }
    public class DeliveryCostAllViewModel
    {
        public int AutoID { get; set; }
        public string Division { get; set; }
        public string Plant { get; set; }
        public string PlantZoneStartID { get; set; }
        public string DescriptionStart { get; set; }
        public string ShipToZone { get; set; }
        public string ShipToZoneID { get; set; }
        public string Y4 { get; set; }
        public string Y3 { get; set; }
        public string Y2 { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string EditDate { get; set; }
        public string Remark { get; set; }
    }

}