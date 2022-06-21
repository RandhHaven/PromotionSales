using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSales.Api.Domain.Helpers.AppSettings;

internal class AppSettingsAzureBlob
{
    public string ConnectionString { get; set; }
    public string BaseUrl { get; set; }
    public string ContainerReference { get; set; }
    public bool IsDev { get; set; }
}
