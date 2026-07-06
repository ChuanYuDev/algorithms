using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace GoogleApiTest.GoogleSheetsApi;

public class GoogleSheetsApi
{
    private static readonly string[] Scopes = [SheetsService.Scope.SpreadsheetsReadonly];
    private const string GoogleCredentialsFileName = "google_credentials.json";
    private const string ReadRange = "Form Responses 1";

    private readonly SheetsService _sheetsService;

    public GoogleSheetsApi()
    {
        using var stream = new FileStream(GoogleCredentialsFileName, FileMode.Open, FileAccess.Read);
        
        var saCredential = CredentialFactory.FromStream<ServiceAccountCredential>(stream);
        var googleCredential = saCredential.ToGoogleCredential().CreateScoped(Scopes);
        
        var serviceInitializer = new BaseClientService.Initializer
        {
            HttpClientInitializer = googleCredential
        };

        _sheetsService = new SheetsService(serviceInitializer);
    }
    
    public async Task ReadAsync(string spreadsheetId)
    {
        var response = await _sheetsService.Spreadsheets.Values.Get(spreadsheetId, ReadRange).ExecuteAsync();
        var values = response.Values;
        if (values == null || !values.Any())
        {
            Console.WriteLine("No data found.");
            return;
        }
        var header = string.Join("|", values.First().Select(r => r.ToString()));
        Console.WriteLine($"Header: {header}");

        foreach (var row in values.Skip(1))
        {
            var res = string.Join("|", row.Select(r => r.ToString()));
            Console.WriteLine(res);
        }
    }
}

class MainProgram
{
    static async Task Main(string[] args)
    {
        var googleSheetsApi = new GoogleSheetsApi();
        const string clientSpreadsheetId = "1XRg8HTGuqgF-q_jHUtz311rC8te6miV1XogxAvjVKmA";
        await googleSheetsApi.ReadAsync(clientSpreadsheetId);
        
        const string volunteerSpreadsheetId = "1Xv3kyox5skadQk198sQMq4YFjr3wDphUn-t0qbB0TYQ";
        await googleSheetsApi.ReadAsync(volunteerSpreadsheetId);
    }
}