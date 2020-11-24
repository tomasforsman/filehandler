using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Newtonsoft.Json;

namespace FileHandler.ConsoleApp
{
  //ToDo: Get this to work!
  internal class Program
  {
    private static HttpClient _client;

    private static readonly Random _random = new Random();

    private static async Task Main(string[] args)
    {
      _client = new HttpClient {Timeout = TimeSpan.FromMinutes(1)};

      while (true)
      {
        Console.Write("Enter # of files to send, or empty to quit: ");
        var line = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(line))
          break;

        int limit;
        var loops = 1;
        var segments = line.Split(',');
        if (segments.Length == 2)
        {
          loops = int.TryParse(segments[1], out var result) ? result : 1;
          limit = int.TryParse(segments[0], out result) ? result : 1;
        }
        else if (!int.TryParse(line, out limit))
        {
          limit = 1;
        }

        for (var pass = 0; pass < loops; pass++)
        {
          var tasks = new List<Task>();

          for (var i = 0; i < limit; i++)
          {
            var file = new FileInfoSubmitted
            {
              FileId = NewId.NextGuid(),
              FileName = $"svefakt{i}.xml",
              Folder = "c:/FileId",
              OriginFolder = "c:/origin",
              Timestamp = DateTime.Now
            };

            tasks.Add(Execute(file));
          }

          await Task.WhenAll(tasks.ToArray());

          Console.WriteLine();
          Console.WriteLine("Results {0}/{1}", pass + 1, loops);

          foreach (var task in tasks.Cast<Task<string>>())
            Console.WriteLine(task.Result);
        }
      }
    }

    private static async Task<string> Execute(FileInfoSubmitted file)
    {
      try
      {
        var json = JsonConvert.SerializeObject(file);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var responseMessage = await _client.PostAsync("https://localhost:5001/File", data);

        responseMessage.EnsureSuccessStatusCode();

        var result = await responseMessage.Content.ReadAsStringAsync();

        if (responseMessage.StatusCode == HttpStatusCode.Accepted)
        {
          await Task.Delay(2000);
          await Task.Delay(_random.Next(6000));

          var fileAddress = $"https://localhost:5001/File?id={file.FileId:D}";

          var patchResponse = await _client.PatchAsync(fileAddress, data);

          patchResponse.EnsureSuccessStatusCode();

          var patchResult = await patchResponse.Content.ReadAsStringAsync();

          do
          {
            await Task.Delay(5000);

            var getResponse = await _client.GetAsync(fileAddress);

            getResponse.EnsureSuccessStatusCode();

            var getResult = await getResponse.Content.ReadAsAsync<FileStatus>();

            if (getResult.State == "Completed" || getResult.State == "Faulted")
              return $"FILE: {file.FileId:D} STATUS: {getResult.State}";

            Console.Write(".");
          } while (true);
        }

        return result;
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);

        return exception.Message;
      }
    }
  }


  public class FileInfoSubmitted
  {
    public DateTime Timestamp { get; set; }
    public Guid FileId { get; set; }
    public string FileName { get; set; }
    public string Folder { get; set; }
    public string OriginFolder { get; set; }
  }


  public class FileStatus
  {
    public Guid FileId { get; }
    public string State { get; }
  }
}