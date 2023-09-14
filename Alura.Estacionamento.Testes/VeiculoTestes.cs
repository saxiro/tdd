using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Acelerar")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Frear")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste Ignorar", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
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
    }
}