using Elections.Backend.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.UnitTests.Shared
{
    public class ExceptionalDBUpdateDataContextWithInnerException : DataContext
    {
        public ExceptionalDBUpdateDataContextWithInnerException(DbContextOptions<DataContext> options) :
        base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var innerException = new Exception("duplicate record");
            throw new DbUpdateException("Test Exception", innerException);
        }
    }
}
