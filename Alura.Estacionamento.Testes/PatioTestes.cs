using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;
        private Patio estacionamento;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste) 
        { 
            veiculo = new Veiculo();
            estacionamento = new Patio();
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            estacionamento = new Patio();
            veiculo = new Veiculo();
            veiculo.Proprietario = "Fabricio Barbosa";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Celta Spirit";
            veiculo.Placa = "mst-1866";
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preta", "Gol")]
        [InlineData("Jose Silva", "POL-9241", "Cinza", "Fusca")]
        [InlineData("Maria Barbosa", "GDR-8566", "Cinza", "Fusca")]
        [InlineData("Fabricio Barbosa", "MST-1866", "Preta", "Celta")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
            string placa, string cor, string modelo)
        {
            //Arrange
            estacionamento = new Patio();
            veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "Preta", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario,
            string placa, string cor, string modelo)
        {
            //Arrange
            estacionamento = new Patio();
            veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Equal(veiculo.IdTicket, consultado.IdTicket);
        }

        [Theory(DisplayName = "Nao Localiza Veiculo")]
        [InlineData("André Silva", "ASD-1498", "Preta", "Gol", "MST-1866")]
        public void NaoLocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,
            string placa, string cor, string modelo, string placaDiferente)
        {
            //Arrange
            estacionamento = new Patio();
            veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placaDiferente);

            //Assert
            Assert.Null(consultado);
        }

        [Fact]
        public void AlterarDadosDoVeiculoOuDoProprietario()
        {
            //Arrange
            estacionamento = new Patio();
            veiculo = new Veiculo();
            veiculo.Proprietario = "Fabricio Barbosa";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Celta Spirit";
            veiculo.Placa = "MST-1866";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Fabricio Barbosa";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preta"; //Alterado
            veiculoAlterado.Modelo = "Celta Spirit";
            veiculoAlterado.Placa = "MST-1866";
            veiculoAlterado.IdTicket = veiculo.IdTicket;
            veiculoAlterado.Ticket = veiculo.Ticket;

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            Assert.Equal(veiculoAlterado.Placa, alterado.Placa);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
