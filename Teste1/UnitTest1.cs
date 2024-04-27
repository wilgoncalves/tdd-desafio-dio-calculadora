using System;
using Xunit;
using Calculadora;

namespace Teste1
{
    public class UnitTest1
    {
        public CalculadoraClass construirClasse()
        {
            CalculadoraClass calc = new CalculadoraClass("27/04/24");
            return calc;
        }

        [Theory]
        [InlineData (1, 2, 3)]
        [InlineData (4, 5, 9)]
        public void TesteSomar(int valor1, int valor2, int resultado)
        {
            CalculadoraClass calc = construirClasse();

            int resultadoCalculadora = calc.somar(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TesteMultiplicar(int valor1, int valor2, int resultado)
        {
            CalculadoraClass calc = construirClasse();

            int resultadoCalculadora = calc.multiplicar(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TesteDividir(int valor1, int valor2, int resultado)
        {
            CalculadoraClass calc = construirClasse();

            int resultadoCalculadora = calc.dividir(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TesteSubtrair(int valor1, int valor2, int resultado)
        {
            CalculadoraClass calc = construirClasse();

            int resultadoCalculadora = calc.subtrair(valor1, valor2);

            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TesteDivisaoPorZero() 
        {
            CalculadoraClass calc = construirClasse();

            Assert.Throws<DivideByZeroException>(() => calc.dividir(3, 0));
        }

        [Fact]
        public void TesteHistorico()
        {
            CalculadoraClass calc = construirClasse();

            calc.somar(1, 2);
            calc.somar(2, 2);
            calc.somar(8, 2);
            calc.somar(5, 2);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
