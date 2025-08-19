namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade é suficiente
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade da suíte insuficiente para o número de hóspedes");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null || DiasReservados <= 0)
            {
                return 0;
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% para reservas com 10 ou mais dias
            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // 10% de desconto
            }

            return valor;
        }
    }
}