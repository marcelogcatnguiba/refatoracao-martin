using Newtonsoft.Json;
using Refactor.Domain.Entities;

namespace Refactor.Domain.Test
{
    public class SerializeTests : IDisposable
    {
        private readonly string _caminhoPlays;
        private readonly string _caminhoInvoices;
        public SerializeTests()
        {
            string plays = 
            """
                [
                    {
                        "name": "Hamlet",
                        "type": "tragedy"
                    },
                    {
                        "name": "As You Like It",
                        "type": "comedy"
                    },
                    {
                        "name": "Othello",
                        "type": "tragedy"
                    }
                ]
            """;

            string invoices = 
            """
            {
                "customer": "BigCo",
                "performances": [
                    {
                        "playID": "Hamlet",
                        "audience": 55
                    },
                    {
                        "playID": "As You Like It",
                        "audience": 35
                    },
                    {
                        "playID": "Othello",
                        "audience": 40
                    }
                ]
            }
            """;

            File.WriteAllText("plays.json", plays);
            File.WriteAllText("invoices.json", invoices);
            
            _caminhoInvoices = Path.GetFullPath("invoices.json");
            _caminhoPlays = Path.GetFullPath("plays.json");
        }

        [Fact]
        public void DeveDeserializar_Plays()
        {
            var json = File.ReadAllText("plays.json");
            var result = JsonConvert.DeserializeObject<List<Plays>>(json);

            Assert.IsType<List<Plays>>(result);
        }

        [Fact]
        public void DeveConterDados_Plays()
        {
            var json = File.ReadAllText("plays.json");
            var result = JsonConvert.DeserializeObject<List<Plays>>(json);

            Assert.NotEmpty(result!);
        }

        [Fact]
        public void DeveDeserializar_Invoice()
        {
            var json = File.ReadAllText("invoices.json");
            var result = JsonConvert.DeserializeObject<Invoices>(json);

            Assert.IsType<Invoices>(result);
        }

        [Fact]
        public void DeveConterDados_Invoices()
        {
            var json = File.ReadAllText("invoices.json");
            var result = JsonConvert.DeserializeObject<Invoices>(json);

            Assert.Equal("BigCo", result!.Customer);
            Assert.NotEmpty(result!.Performances);
        }

        public void Dispose()
        {
            File.Delete(_caminhoPlays);
            File.Delete(_caminhoInvoices);

            //Para nao invocar o GC novamente pois eu ja limpei ele da memoria aqui
            GC.SuppressFinalize(this);
        }
    }
}