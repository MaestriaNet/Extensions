using System.Threading.Tasks;
using Maestria.Extensions.Test.CSharp.Interfaces;

namespace Maestria.Extensions.Test.CSharp.Models
{
    public class PaisCommandHandler : CommandHandler, IHandler<PaisSaveCommand, PaisDomain>
    {
        public Task<PaisDomain> HandlerAsync(PaisSaveCommand message)
        {
            return null;
        }
    }
}
