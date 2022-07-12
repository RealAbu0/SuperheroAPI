using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroDapper
{
    public class DapperContext 
    {
        public IConfiguration _config;
        private readonly string _connString;

        public DapperContext(IConfiguration context)
        {
            _config = context;
            _connString = _config.GetConnectionString("Default");
        }

        public IDbConnection GetConnectionString()
            => new SqlConnection(_connString);



    }
}
