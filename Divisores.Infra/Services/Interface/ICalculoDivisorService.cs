namespace Divisores.Infra.Services.Interface
{
    public interface ICalculoDivisorService
    {
        List<int> RetornarDivisores(int numero);
        List<int> RetornarPrimos(List<int> lDivisores);
        string MontarMensagemRetorno(int numero, List<int> lDivisores, List<int> lPrimos);
    }
}
