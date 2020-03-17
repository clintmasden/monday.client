# monday.client
A .NET Standard/C# implementation of Monday.com API.

| Name | Resources |
| ------ | ------ |
| APIs | https://monday.com/developers/ |

#### Getting Started:
```
using System;
using Monday.Client;

namespace Monday.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new MondayClient("APIKEY");

            var pulseList = client.GetPulses().Result;

            pulseList.ForEach(pulse => Console.WriteLine($"{pulse.Id}. {pulse.Name}"));
            Console.Read();
        }
    }
}
```
