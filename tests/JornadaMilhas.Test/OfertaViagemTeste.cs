using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTeste
    {
        [Fact]
        public void TestandoOfertaValida()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var validacao = true;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void TestandoOfertaComRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void TestandoOfertaComDataInicialMaiorQueFinal()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 6), new DateTime(2024, 2, 5));
            double preco = 100.0;
            
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void TestandoOfertaComRotaOrigemNula()
        {
            Rota rota = new Rota(null, "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 6), new DateTime(2024, 2, 5));
            double preco = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void TestandoOfertaComRotaDestinoNula()
        {
            Rota rota = new Rota("OrigemTeste", null);
            Periodo periodo = new Periodo(new DateTime(2024, 2, 6), new DateTime(2024, 2, 5));
            double preco = 100.0;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.False(oferta.EhValido);
        }
    }
}