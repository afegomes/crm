using CRM.Cadastro.API;
using CRM.Cadastro.Dominio.Clientes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRM.Cadastro.IntegrationTests
{
    public class ClienteControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ClienteControllerTest()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.Development.json");

            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((ctx, config) =>
                {
                    config.AddJsonFile(configPath);
                });

            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestGetClientes()
        {
            var response = await _client.GetAsync("/api/cliente");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("[]", responseString);
        }

        [Fact]
        public async Task TestPostCliente()
        {
            var command = new InclusaoClienteCommand
            {
                Nome = "Bruno Lage",
                Sexo = "M",
                Logradouro = "Av. João Paulino Vieira Filho",
                Complemento = "2º piso",
                Cep = "87020-015",
                Bairro = "Zona 01",
                Cidade = "Maringá",
                Estado = "PR",
                Numero = "190",
                DataNascimento = DateTime.ParseExact("28/02/1904", "dd/MM/yyyy", CultureInfo.InvariantCulture)
            };

            using var content = ToContent(command);

            var response = await _client.PostAsync("/api/cliente", content);
            response.EnsureSuccessStatusCode();

            // TODO: Fazer a consulta na base para verificar se o cliente realmente foi cadastrado

            // TODO: Implementar um mecanismo de rollback após o teste
        }

        private StringContent ToContent(object o)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(o, settings);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}