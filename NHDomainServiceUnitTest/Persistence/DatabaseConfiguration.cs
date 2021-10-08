using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Persistence.Mappings;

namespace Persistence
{
    public class DatabaseConfiguration : Configuration
    {
        public DatabaseConfiguration()
        {
            this.DataBaseIntegration(db =>
            {
                db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                db.Timeout = 30;
            });

            SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName);
            SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName);
            SetProperty(Environment.ConnectionString, @"Server=LAPTOP-SUHAS\SQLEXPRESS;Database=EmployeeBenefits;Trusted_Connection=True;");
            SetProperty(Environment.BatchSize, "1");

            this.Cache(cache =>
            {
                cache.UseQueryCache = true;
                //cache.QueryCache<StandardQueryCache>();
                cache.Provider<HashtableCacheProvider>();
            });

            this.CurrentSessionContext<WebSessionContext>();

            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<EmployeeMappings>();
            modelMapper.AddMapping<AddressMappings>();
            modelMapper.AddMapping<BenefitMappings>();
            modelMapper.AddMapping<LeaveMappings>();
            modelMapper.AddMapping<SkillsEnhancementAllowanceMappings>();
            modelMapper.AddMapping<SeasonTicketLoanMappings>();
            modelMapper.AddMapping<CommunityMappings>();

            AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities());
        }
    }
}