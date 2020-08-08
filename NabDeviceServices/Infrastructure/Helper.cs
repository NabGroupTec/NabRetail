using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NabDeviceServices.Models;

namespace NabDeviceServices.Infrastructure
{
    public class Helper
    {
        
        public static List<T> RawSqlQuery<T>(DbContext contextDbContext,string query, Func<DbDataReader, T> map)
        {
                using (var command = contextDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    contextDbContext.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }

                        return entities;
                    }
                }
        }
    }
}