using Divisores.Infra.Services.Interface;

namespace Divisores.Infra.Services
{
    public class CalculoDivisorService : ICalculoDivisorService
    {
        public CalculoDivisorService()
        {

        }

        public List<int> RetornarDivisores(int numero)
        {
            List<int> lDivisores = new List<int>();

            for (int i = 1; i <= numero / 2; i++)
                if (numero % i == 0)
                    lDivisores.Add(i);

            return lDivisores;
        }

        public List<int> RetornarPrimos(List<int> lDivisores)
        {
            List<int> lPrimos = new List<int>();

            for (int i = 0; i < lDivisores.Count ; i++)
            {
                bool primo = true;
                int divisor = lDivisores[i];

                if (divisor == 1)
                    primo = true;
                else
                    for (int x = 2; x <= divisor / 2; x++)
                        if (divisor % x == 0)
                            primo = false;

                if (primo)
                    lPrimos.Add(divisor);
            }

            return lPrimos;
        }

        public string MontarMensagemRetorno(int numero, List<int> lDivisores, List<int> lPrimos)
        {
            var msgRetorno = "Número de Entrada: " + numero.ToString() + Environment.NewLine;
            msgRetorno += "Números divisores: ";

            for (int i = 0; i < lDivisores.Count; i++)
                msgRetorno += lDivisores[i].ToString() + " ";

            msgRetorno += Environment.NewLine + "Divisores Primos: ";
            for (int i = 0; i < lPrimos.Count; i++)
                msgRetorno += lPrimos[i].ToString() + " ";

            return msgRetorno;
        }
    }
}
