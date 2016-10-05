using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using Core;
using NHibernate.Driver;
using NHibernate.Dialect;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using SQLiteRepositories.Mappings;
using System.Diagnostics;

namespace SQLiteRepositories
{
    public class Config
    {
        private static ISessionFactory _sessionFactory;

        public static void SetConfiguration(string connectionString)
        {
            _sessionFactory = Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .ConnectionString(connectionString)
                  .ShowSql()
              )
              .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<RecipeMap>())
              .ExposeConfiguration(cfg =>
              {
                  cfg.SetInterceptor(new SqlStatementInterceptor());

                  try
                  {
                      new SchemaValidator(cfg).Validate();
                  }
                  catch (HibernateException)
                  {
                      new SchemaUpdate(cfg).Execute(false, true);
                  }
              }).BuildSessionFactory(); ;
        }

        public static ISessionFactory GetSessionFactory()
        {
            return _sessionFactory;
        }
    }

    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Debug.Print(sql.ToString());
            return sql;
        }
    }
}
