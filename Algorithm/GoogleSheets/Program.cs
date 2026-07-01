using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace GoogleSheets;

class Program
{
    private static readonly string[] Scopes = [SheetsService.Scope.SpreadsheetsReadonly];
    private const string SpreadsheetId = "1XRg8HTGuqgF-q_jHUtz311rC8te6miV1XogxAvjVKmA";
    private const string GoogleCredentialsFileName = "google_credentials.json";
    private const string ReadRange = "Form Responses 1";

    static async Task Main(string[] args)
    {
        var serviceValues = GetSheetsService().Spreadsheets.Values;
        await ReadAsync(serviceValues);
    }

    private static SheetsService GetSheetsService()
    {
        using var stream = new FileStream(GoogleCredentialsFileName, FileMode.Open, FileAccess.Read);
        
        var saCredential = CredentialFactory.FromStream<ServiceAccountCredential>(stream);
        var googleCredential = saCredential.ToGoogleCredential().CreateScoped(Scopes);
        
        var serviceInitializer = new BaseClientService.Initializer
        {
            HttpClientInitializer = googleCredential
        };

        return new SheetsService(serviceInitializer);
    }

    private static async Task ReadAsync(SpreadsheetsResource.ValuesResource valuesResource)
    {
        var response = await valuesResource.Get(SpreadsheetId, ReadRange).ExecuteAsync();
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