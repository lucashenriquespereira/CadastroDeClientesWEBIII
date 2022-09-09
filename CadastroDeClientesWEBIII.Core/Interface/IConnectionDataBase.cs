using System.Data;

namespace CadastroDeClientesWEBIII.Core.Interface
{
    public interface IConnectionDataBase
    {
        IDbConnection CreateConnection();
    }
}
