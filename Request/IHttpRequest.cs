using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request
{
    public interface IHttpRequest : IDisposable
    {
        string GetBody(string url);
    }
}
