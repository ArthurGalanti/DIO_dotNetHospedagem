namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        private bool FlagSuite = false;

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (FlagSuite)
            {
                if (hospedes.Count() <= Suite.Capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    throw new Exception("A quantidade de hóspedes não pode exceder a capacidade da suíte");
                }
            }
            else
            {
                throw new Exception("Você deve casdastrar um suíte primeiro!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
            FlagSuite = true;
        }

        public int ObterQuantidadeHospedes()
        {
            try
            {
                return Hospedes.Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = 0;
            if (FlagSuite)
            {
                valor = Suite.ValorDiaria * DiasReservados;
                if (DiasReservados >= 10)
                {
                    valor = valor - (valor * 0.10M);
                }
            }
            else
            {
                throw new Exception("Você deve casdastrar um suíte primeiro!");
            }
            return valor;
        }
    }
}