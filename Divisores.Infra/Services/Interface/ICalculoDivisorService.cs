namespace Divisores.Infra.Services.Interface
{
    public interface ICalculoDivisorService
    {
        Dictionary<string, string> CalcularDivisores(int numero);

        List<int> RetornarDivisores(int numero);
        List<int> RetornarPrimos(List<int> lDivisores);
        string MontarMensagemRetorno(int numero, List<int> lDivisores, List<int> lPrimos);
        string MsgRetorno(Dictionary<string, string> retorno, int numero);
    }
}
