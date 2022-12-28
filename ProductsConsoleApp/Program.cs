using Microsoft.Identity.Client;
using System.Net.Http.Headers;

IConfidentialClientApplication confidentialClientApplication;

//ThunderVsCode AppRegistration AKA ClientApp registration
string clientId = "";
string clientSecret = "";
string tenantId = "";

confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(clientId)
    .WithClientSecret(clientSecret)
    .WithTenantId(tenantId)
    .Build();

//ProductsAPI app registration AppID
string[] scopes = new string[] { "api://df00e79c-f0a1-42cb-8882-b5d32fce0ee4/.default" };

AuthenticationResult authResult = await confidentialClientApplication.AcquireTokenForClient(scopes).ExecuteAsync();

//authResult.AccessToken

string apiUrl = "https://kprproductsapi.azurewebsites.net/api/products";

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

var response = await client.GetAsync(apiUrl);

string content = await response.Content.ReadAsStringAsync();

Console.WriteLine(content);