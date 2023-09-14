using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Runtime.ConstrainedExecution;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste) 
        {
            veiculo = new Veiculo();
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste Ignorar", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            veiculo = new Veiculo();
            veiculo.Proprietario = "Fabricio Barbosa";
            veiculo.Placa = "MST-1866";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preta";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres() 
        {
            //Arrange
            string nomeProprietario = "Ab";
            
            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
                );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "MSTF1866";

            //Act
            var erro = Assert.Throws<System.FormatException>(

                () => new Veiculo().Placa = placa

                );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", erro.Message);

        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Disposable invocado.");
            GC.SuppressFinalize(this);
        }
    }
}