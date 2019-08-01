using Microsoft.EntityFrameworkCore;

namespace PTCGLottoLibrary.Interfaces
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}
