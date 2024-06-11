using Newtonsoft.Json;
using Refactor.Domain.Entities;

namespace Refactor.Domain.Test
{
    public class SerializeTests
    {
        [Fact]
        public void DeveDeserializarUmaListaDePlays()
        {
            var json = File.ReadAllText(@"D:\Dev\devs-csharp\refactor-martin-fowler\tests\JSON\plays.json");
            var result = JsonConvert.DeserializeObject<List<Plays>>(json);

            Assert.IsType<List<Plays>>(result);
        }

        [Fact]
        public void DeveDeserializarUmaInvoice()
        {
            var json = File.ReadAllText(@"D:\Dev\devs-csharp\refactor-martin-fowler\tests\JSON\invoices.json");
            var result = JsonConvert.DeserializeObject<Invoices>(json);

            Assert.IsType<Invoices>(result);
        }
    }
}