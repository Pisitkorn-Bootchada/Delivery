using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Korntest.Models;
using Korntest.ViewModel;
using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Korntest.Services
{
    public class NetworkServices
    {
        // private readonly IOptions<ApiOptions> _options;
        private readonly string _apiSapSd;
        public NetworkServices(IConfiguration config)
        {
            // _options = options;
            _apiSapSd = config["ApiSapSd:UriApiSapSd"];
        }

        public async Task<MasterCCPViewModel> LoginMasterCCP(string username, string password)
        {
            var result = new MasterCCPViewModel();
            using (var client = new HttpClient())
            {

                try
                {
                    const string baseUrl = "http://ccp-info2.com/";
                    string function = "/APIMasterCCP/api/GetData/CheckLoginMasterCCP?" + $"username={username}&password={password}&programId={"WB2024-015"}";
                    client.BaseAddress = new Uri(baseUrl);
                    var response = await client.GetAsync(function);  // Get http method
                    response.EnsureSuccessStatusCode();
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<MasterCCPViewModel>(stringResponse);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            return result;
        }
        // public async Task<EDCViewModel> LoginEDC(string userName, string password)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "http://ccp-info2.com/";
        //             string function = "/APIMasterCCP/api/GetData/StdLoginCCP" +
        //             $"?username={userName}&password={password}";
        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             EDCViewModel result = JsonConvert.DeserializeObject<EDCViewModel>(stringResponse);
        //             return result;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return null;
        // }

        // public async Task<List<MasterAutorizeViewModel>> GetMasterAutorizeCCP()
        // {
        //     var result = new List<MasterAutorizeViewModel>();
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "http://ccp-info2.com/";
        //             string function = "/APIMasterCCP/api/GetData/GetMasterAuthorizeCCP";
        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             var respond = JsonConvert.DeserializeObject<List<MasterAutorizeViewModel>>(stringResponse);
        //             foreach (var item in respond)
        //             {
        //                 if (item.programID == "WB2024-015")
        //                 {
        //                     result.Add(item);
        //                 }
        //             }
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return result;
        // }
        // public async Task<List<EmployeeViewModel>> GetEmployeeCCP()
        // {
        //     var result = new List<EmployeeViewModel>();
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "http://ccp-info2.com/";
        //             string function = "/APIMasterCCP/api/GetData/GetEmployeeCCP";
        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             var respond = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(stringResponse);
        //             result = respond;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return result;
        // }

        public async Task<List<DeliveryCostViewModel>> GetAPIDeliveryCost()
        {
            var result = new List<DeliveryCostViewModel>();
            using (var client = new HttpClient())
            {
                try
                {
                    const string baseUrl = "http://ccp-info.com/";
                    string function = "/APIDeliveryCost/api/DeliveryCost/getdata";
                    client.BaseAddress = new Uri(baseUrl);
                    var response = await client.GetAsync(function);  // Get http method
                    response.EnsureSuccessStatusCode();
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var respond = JsonConvert.DeserializeObject<List<DeliveryCostViewModel>>(stringResponse);
                    result = respond;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            return result;
        }

        public async Task<List<DeliveryCostAllViewModel>> GetAPIDeliveryCostAll()
        {
            var result = new List<DeliveryCostAllViewModel>();
            using (var client = new HttpClient())
            {
                try
                {
                    const string baseUrl = "http://ccp-info2.com/";
                    string function = "/APIDeliveryCost/api/Get/GetAPIDeliveryCostAll";
                    client.BaseAddress = new Uri(baseUrl);
                    var response = await client.GetAsync(function);  // Get http method
                    response.EnsureSuccessStatusCode();
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var respond = JsonConvert.DeserializeObject<List<DeliveryCostAllViewModel>>(stringResponse);
                    result = respond;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            return result;
        }


        // public async Task<SapResponse> PostSapCompany(ApiPostSapCompany request)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        //             string function = "/APISapSDCCP/api/Customer/Create/CompanyData";
        //             client.BaseAddress = new Uri(_apiSapSd);
        //             var json = JsonConvert.SerializeObject(request);
        //             var content = new StringContent(json, Encoding.UTF8, "application/json");
        //             var response = await client.PostAsync(function, content);

        //             if (!response.IsSuccessStatusCode)
        //             {
        //                 var errorResponse = await response.Content.ReadAsStringAsync();
        //                 Console.WriteLine($"Request failed: {response.StatusCode}, Error: {errorResponse}");
        //                 throw new Exception("SAP API returned an error: " + errorResponse);
        //             }

        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             SapResponse result = JsonConvert.DeserializeObject<SapResponse>(stringResponse);
        //             return result;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             // Log error or handle it as needed
        //             Console.WriteLine($"Request exception: {e.Message}");
        //             throw;
        //         }
        //     }
        // }
        // public async Task<SapResponse> PostSapPerson(ApiPostSapPersonal request)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {

        //             Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        //             string function = "/APISapSDCCP/api/Customer/Create/PersonalData";
        //             client.BaseAddress = new Uri(_apiSapSd);
        //             var json = JsonConvert.SerializeObject(request);
        //             var content = new StringContent(json, Encoding.UTF8, "application/json");
        //             var response = await client.PostAsync(function, content);
        //             if (!response.IsSuccessStatusCode)
        //             {
        //                 var errorResponse = await response.Content.ReadAsStringAsync();
        //                 Console.WriteLine($"Request failed: {response.StatusCode}, Error: {errorResponse}");
        //                 throw new Exception("SAP API returned an error: " + errorResponse);
        //             }

        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             SapResponse result = JsonConvert.DeserializeObject<SapResponse>(stringResponse);
        //             return result;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             // Log error or handle it as needed
        //             Console.WriteLine($"Request exception: {e.Message}");
        //             throw;
        //         }
        //     }
        // }

        // public async Task<List<SoldToDetail>> FindSoldToName(string name)
        // {
        //     var result = new List<SoldToDetail>();
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "https://ccpnext.com/";
        //             string function = $"/APIApproveDeduction/api/Get/GETSoldTo?Description={name}";
        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             result = JsonConvert.DeserializeObject<List<SoldToDetail>>(stringResponse);
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return result;
        // }
        // public async Task<List<Datas>> GetTaxIdSAP()
        // {
        //     var result = new List<Datas>();
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "https://ccpnext.com/";
        //             string function = $"/APISapSDCCP/api/Customer/GetListCustomer";
        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             var respond = JsonConvert.DeserializeObject<ListCustomerSAP>(stringResponse);
        //             result = respond.data;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return result;
        // }

        // public async Task<GetCusDatailByNoViewModel> GetCustomerDetailByNumber(string CustomerNo)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "https://ccpnext.com/";
        //             string function = $"/APISapSDCCP/api/Master/GetCustomerDetailByNumber" +
        //             $"?CustomerNo={CustomerNo}";

        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             GetCusDatailByNoViewModel result = JsonConvert.DeserializeObject<GetCusDatailByNoViewModel>(stringResponse);
        //             return result;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return null;
        // }

        //   public async Task<APICustomerMasterViewModel> GetCustomerMaster(string CustomerNo)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "https://ccpnext.com/";
        //             string function = $"/APISapSDCCP/api/Customer/GetCustomerMaster" +
        //             $"?CustomerNo={CustomerNo}";

        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             APICustomerMasterViewModel result = JsonConvert.DeserializeObject<APICustomerMasterViewModel>(stringResponse);
        //             return result;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return null;
        // }

        //   public async Task<ApiCustomerGenralDetail> GetCustomerGenralDetail(string CustomerNo)
        // {
        //     using (var client = new HttpClient())
        //     {
        //         try
        //         {
        //             const string baseUrl = "https://ccpnext.com/";
        //             string function = $"/APISapSDCCP/api/Master/GetCUSTOMERGENERALDETAIL" +
        //             $"?CustomerNo={CustomerNo}";

        //             client.BaseAddress = new Uri(baseUrl);
        //             var response = await client.GetAsync(function);  // Get http method
        //             response.EnsureSuccessStatusCode();
        //             var stringResponse = await response.Content.ReadAsStringAsync();
        //             ApiCustomerGenralDetail result = JsonConvert.DeserializeObject<ApiCustomerGenralDetail>(stringResponse);
        //             return result;
        //         }
        //         catch (HttpRequestException e)
        //         {
        //             Console.WriteLine($"Request exception: {e.Message}");
        //         }
        //     }
        //     return null;
        // }
    }
}