using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon_Financial_API.Data
{
    public class ReportRepositoryConnection : IDisposable
    {
        private readonly BangazonWebContext context;

        public ReportRepositoryConnection(BangazonWebContext ctx)
        {
            context = ctx;
        }

        public BangazonWebContext AppContext { get { return context; } }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
