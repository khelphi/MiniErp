using Dapper;
using MiniErp.Application.Contracts.v1.Partners.Request;
using MiniErp.Application.Data.MySql.Entities;
using MiniErp.Application.Data.MySql.StaticTypes;
using MiniErp.Application.Data.MySql.Views;
using MiniErp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniErp.Application.Data.MySql.Repositories
{
    public class PartnerRepository
    {

        private readonly MySqlContext _context;


        public PartnerRepository(MySqlContext context)
        {
            this._context = context;
        }

        public async Task<bool> ExecuteAsync(string _query)
        {
            bool _result = false;
            try
            {
                using (var cnx = _context.conexao())
                {
                    await cnx.ExecuteAsync(_query);
                    _result = true;
                }
            }
            catch (Exception)
            {
                _result = false;
            }
            return _result;
        }


        public async Task<PartnerEntity> CreateAsync(PartnerEntity request)
        {

            using (var cnx = _context.conexao())
            {

                // Montando string de script que irá ser executada pela conexão
                string _query = $@"insert into Partner(partnerId, name, document, situation, status, partnerCode)
                                values ('{request.PartnerId}',
                                        '{request.Name}',
                                        '{request.Document}',
                                         {request.Situation},
                                         {request.Status.GetHashCode()},
                                        '{request.PartnerCode}')";

                // Obtendo o resultado mapeado para PartnerEntity da conexão
                var result = await cnx.QueryAsync<PartnerEntity>(_query);

                // Retorno
                return new PartnerEntity(request.PartnerId, request.Name, request.Document, request.Situation, request.Status, request.PartnerCode);
            }
        }


        public async Task<PartnerEntity> UpdateAsync(PartnerEntity request)
        {

            using (var cnx = _context.conexao())
            {
                string _query = $@"Update Partner set name = '{request.Name}', document = '{request.Document}', situation = '{request.Situation}', status = {request.Status.GetHashCode()}, partnerCode = '{request.PartnerCode}'
                                where partnerId = '{request.PartnerId}'";

                var result = await cnx.QueryAsync<PartnerEntity>(_query);

                return new PartnerEntity(request.PartnerId, request.Name, request.Document, request.Situation, request.Status, request.PartnerCode);
            }
        }



        public async Task<PartnerEntity> GetById(Guid partnerId)
        {

            using (var cnx = _context.conexao())
            {
                // Montando string de script que irá ser executada pela conexão
                string _query = $@"select partnerId, name, document, situation, status, partnerCode from Partner where PartnerId = '{partnerId}'";

                // Obtendo o resultado mapeado para PartnerEntity da conexão
                var result = await cnx.QueryAsync<PartnerEntity>(_query);

                // Retorno
                return result.FirstOrDefault();
            }

        }

        public async Task<PartnerEntity> GetByDocument(string document)
        {
            using (var cnx = _context.conexao())
            {
                string _query = $@"select partnerId, name, document, situation, status, partnerCode from Partner where document = '{document}' Limit 1";
                var result = await cnx.QueryAsync<PartnerEntity>(_query);
                return result.FirstOrDefault();
            }

        }


        public async Task<bool> DeleteById(Guid partnerId)
        {
            bool result = true;

            using (var cnx = _context.conexao())
            {

                try
                {
                    string _query = $@"delete from Partner where PartnerId = '{partnerId}'";
                    await cnx.QueryAsync<PartnerEntity>(_query);
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }

                return result;
            }
        }


        public async Task<List<PartnerEntity>> GetAll()
        {
            using (var cnx = _context.conexao())
            {
                string _query = $@"select partnerId, name, document, situation, status, partnerCode from Partner Limit 20";
                var result = await cnx.QueryAsync<PartnerEntity>(_query);
                return result.ToList();
            }
        }

        public async Task<PaginationResponse<PartnerFilteredView>> GetByFilter(PartnerFilteredRequest filter)
        {

            using (var cnx = _context.conexao())
            {
                var _query = new StringBuilder($@"select * from Partner where 1=1");
                var where = new StringBuilder();


                if (!string.IsNullOrEmpty(filter.Name))
                    where.Append($" AND name like '%{filter.Name}%'");

                if (!string.IsNullOrEmpty(filter.Document))
                    where.Append($" AND document = '{filter.Document}'");

                if (!string.IsNullOrEmpty(filter.PartnerCode))
                    where.Append($" AND partnerCode = '{filter.PartnerCode}'");

                if (filter.Status != PartnerStatusType.All)
                    where.Append($" AND status = {filter.Status.GetHashCode()}");

                _query.Append(where);


                if (filter.page > 0 && filter.pageSize > 0)
                    _query.Append($" Limit {filter.pageSize * (filter.page - 1)}, {filter.pageSize}");

                var result = await cnx.QueryAsync<PartnerFilteredView>(_query.ToString());
                var totalRows = result.Count();

                return new PaginationResponse<PartnerFilteredView>
                {
                    Items = result.ToArray(),
                    _pageSize = filter.pageSize,
                    _page = filter.page,
                    _total = totalRows
                };

            }

        }

    }
}
