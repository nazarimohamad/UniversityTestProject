using Xunit;
using System;
using PersistanceEF;

namespace SpecTest.Infrastractures
{
    
    [Collection(nameof(ConfigurationFixture))]
    public class EFDataContextDatabaseFixture : DatabaseFixture
    {
        //readonly ConfigurationFixture _configuration;

        public EFDataContextDatabaseFixture(/*ConfigurationFixture configuration*/)
        {
            //_configuration = configuration;
        }

        public EFDataContext CreateDataContext()
        {
            return new EFDataContext("server=.;database=University;trusted_connection=true;");
        }
    }
}

