using DomainSuperhero.Interfaces;
using DomainSuperhero.Models;
using SuperheroDapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SuperheroConnection
{
    public class SuperheroDataConnection : ISuperheroRepository
    {
        private readonly DapperContext _context;

        public SuperheroDataConnection(DapperContext context)
        {
            _context = context;
        }

        public async Task<SuperheroModel> DeleteSuperhero(int id)
        {
            var query = "DeleteSuperhero";
            DynamicParameters param = new DynamicParameters();
            param.Add("@SuperheroID", id);

            using (var conn = _context.GetConnectionString())
            {
                conn.Open();
                var result = await conn.QueryAsync<SuperheroModel>(query, param, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result.First();
            }
        }

        public async Task<IEnumerable<SuperheroModel>> GetAllSuperherores()
        {
            var query = "GetAllSuperheroes";
            DynamicParameters param = new DynamicParameters();

            using (var conn = _context.GetConnectionString())
            {
                conn.Open();
                var result = await conn.QueryAsync<SuperheroModel>(query, param, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result.ToList();
            }
        }

        public async Task<SuperheroModel> GetOneSuperhero(int id)
        {
            var query = "GetOneSuperhero";
            DynamicParameters param = new DynamicParameters();
            param.Add("@SuperheroID", id);

            using (var conn = _context.GetConnectionString())
            {
                conn.Open();
                var result = await conn.QuerySingleOrDefaultAsync<SuperheroModel>(query, param, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;
            }
        }

        public async Task<SuperheroModel> InsertSuperhero(SuperheroModel model)
        {
            var query = "InsertSuperhero";
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", model.Name);
            param.Add("@SuperheroName", model.SuperheroName);
            param.Add("@City", model.City);

            using (var conn = _context.GetConnectionString())
            {
                conn.Open();
                var result = await conn.QuerySingleAsync<SuperheroModel>(query, param, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;
            }
        }

        public async Task<SuperheroModel> UpdateSuperhero(SuperheroModel model)
        {
            var query = "InsertSuperhero";
            DynamicParameters param = new DynamicParameters();
            param.Add("@SuperheroID", model.SuperheroID);
            param.Add("@Name", model.Name);
            param.Add("@SuperheroName", model.SuperheroName);
            param.Add("@City", model.City);

            using (var conn = _context.GetConnectionString())
            {
                conn.Open();
                var result = await conn.QuerySingleAsync<SuperheroModel>(query, param, commandType: CommandType.StoredProcedure);
                conn.Close();
                return result;
            }
        }
    }
}
