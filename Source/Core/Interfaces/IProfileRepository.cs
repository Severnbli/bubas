using bubas.Source.Core.Entities;

namespace bubas.Source.Core.Interfaces;

public interface IProfileRepository : IRepository<Profile>
{
    public Task<Profile?> GetByChatId(long chatId);
}