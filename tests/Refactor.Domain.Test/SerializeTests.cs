using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refactor.Domain.Entities;

namespace Refactor.Domain.Test
{
    public class SerializeTests
    {
        [Fact]
        public void DeveDeserializarUmaListaDePlays()
        {
            var json = File.ReadAllText(@"..\..\..\..\JSON\plays.json");
            var result = JsonConvert.DeserializeObject<List<Plays>>(json);

            Assert.IsType<List<Plays>>(result);
        }

        [Fact]
        public void DeveConterDadosEmPlays()
        {
            var json = File.ReadAllText(@"..\..\..\..\JSON\plays.json");
            var result = JsonConvert.DeserializeObject<List<Plays>>(json);

            Assert.NotEmpty(result!);
        }

        [Fact]
        public void DeveDeserializarUmaInvoice()
        {
            var json = File.ReadAllText(@"..\..\..\..\JSON\invoices.json");
            var result = JsonConvert.DeserializeObject<Invoices>(json);

            Assert.IsType<Invoices>(result);
        }

        [Fact]
        public void DeveConterDadosNoInvoices()
        {
            var json = File.ReadAllText(@"..\..\..\..\JSON\invoices.json");
            var result = JsonConvert.DeserializeObject<Invoices>(json);

            Assert.Equal("BigCo", result!.Customer);
            Assert.NotEmpty(result!.Performances);
        }
    }
}