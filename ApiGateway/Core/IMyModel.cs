using System.Collections.Generic;

namespace ApiGateway.Core
{
    public interface IMyModel
    {
        IEnumerable<object> Get();

        IEnumerable<object> Create();

        IEnumerable<object> Delete();

        IEnumerable<object> Update();

        IEnumerable<object> Prefright();
    }
}