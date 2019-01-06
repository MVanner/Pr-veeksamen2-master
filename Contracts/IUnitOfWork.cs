using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGiftRepository GiftRepository { get; }
        int Complete();
        
    }
}
