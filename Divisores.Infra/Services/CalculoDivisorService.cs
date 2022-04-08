using Divisores.Infra.Enum;
using Divisores.Infra.Services.Interface;

namespace Divisores.Infra.Services
{
    public class CalculoDivisorService : ICalculoDivisorService
    {
        public CalculoDivisorService()
        {

        }

        public Dictionary<string, string> CalcularDivisores(int numero)
        {
            string divisores = string.Empty;
            string numPrimos = string.Empty;

            Dictionary<string, string> dicInforNumero = new Dictionary<string, string>();

            for (int i = 1; i <= numero / 2; i++)
            {
                if (numero % i == 0)
                {
                    divisores += i.ToString() + " ";

                    if (VerificarPrimo(i))
                        numPrimos += i.ToString() + " ";
                }
            }

            dicInforNumero.Add(EnumDivisor.NumerosDivisores.ToString(), divisores);
            dicInforNumero.Add(EnumDivisor.DivisoresPrimos.ToString(), numPrimos);

            return dicInforNumero;
        }

        private bool VerificarPrimo(int numero)
        {
            if (numero == 1)
                return true;

            for (int i = 2; i <= (numero / 2); i++)
                if (numero % i == 0)
                    return false;

            return true;
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

            msgRetorno += "Divisores Primos: ";
            for (int i = 0; i < lPrimos.Count; i++)
                msgRetorno += lPrimos[i].ToString() + " ";

            return msgRetorno;
        }

        public string MsgRetorno(Dictionary<string, string> retorno, int numero)
        {
            string divisoresPrimos, numerosDivisores;

            retorno.TryGetValue(EnumDivisor.NumerosDivisores.ToString(), out numerosDivisores);
            retorno.TryGetValue(EnumDivisor.DivisoresPrimos.ToString(), out divisoresPrimos);

            var msgRetorno = "Número de Entrada: " + numero + Environment.NewLine;
            msgRetorno += "Números divisores: " + numerosDivisores + Environment.NewLine;
            msgRetorno += "Divisores Primos: " + divisoresPrimos + Environment.NewLine;

            return msgRetorno;
        }

    }
}
