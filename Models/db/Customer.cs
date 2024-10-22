using System;
using System.Collections.Generic;

namespace Korntest.Models.db;

public partial class Customer
{
    public int TrAutoId { get; set; }

    public int SdAutoId { get; set; }

    public string? Name1 { get; set; }

    public int? Tel { get; set; }

    public int? TransportZone { get; set; }

    public string? TransportDescription { get; set; }

    public DateOnly? CreateDate { get; set; }

    public TimeOnly? CreateTime { get; set; }

    public string? CreateBy { get; set; }

    public string? Status { get; set; }
}
