using System.Data.Common;
using FACDataMinerDAL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FACDataMinderDAL.Tests;

public class InMemoryFACDbContext: IDisposable
{

    private readonly DbConnection _connection;
    private readonly DbContextOptions<FACDbContext> _contextOptions;

    public FACDbContext Context { get; set; }

    public InMemoryFACDbContext()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite, including the connection opened above.
        _contextOptions = new DbContextOptionsBuilder<FACDbContext>()
            .UseSqlite(_connection)
            .Options;

        this.Context = new FACDbContext(_contextOptions);

        this.Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Dispose();
        _connection.Dispose();
    }
    
}