using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hmin309_IOT.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddMessageAsync(T message);
        Task<bool> UpdateMessageAsync(T message);
        Task<bool> DeleteMessageAsync(long id);
        Task<T> GetMessageAsync(long id);
        Task<IEnumerable<T>> GetMessagesAsync(bool forceRefresh = false);
    }
}
