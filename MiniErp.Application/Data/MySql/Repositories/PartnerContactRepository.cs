using Dapper;
using MiniErp.Application.Data.MySql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniErp.Application.Data.MySql.Repositories
{
    public class PartnerContactRepository
    {
        private readonly MySqlContext _context;


        public PartnerContactRepository(MySqlContext context)
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

        public async Task<PartnerContactEntity> CreateAsync(PartnerContactEntity request)
        {

            using (var cnx = _context.conexao())
            {

                string _query = $@"insert into partnersContact(id, partnerId, contactName, description, contactType, phoneNumber1, phoneNumber2, information)
                                values (@_Id, @_PartnerId, @_ContactName, @_Description, @_ContactType, @_PhoneNumber1, @_PhoneNumber2, @_Information)";

                var result = await cnx.QueryAsync<PartnerContactEntity>(_query, new {
                    _Id = request.Id,
                    _PartnerId = request.PartnerId,
                    _ContactName = request.ContactName,
                    _Description = request.Description,
                    _ContactType = request.ContactType,
                    _PhoneNumber1 = request.PhoneNumber1,
                    _PhoneNumber2 = request.PhoneNumber2,
                    _Information = request.Information
                });

                return new PartnerContactEntity(request.Id, request.PartnerId, request.ContactName, request.Description, request.ContactType, request.PhoneNumber1, request.PhoneNumber2, request.Information);
            }
        }


        public async Task<PartnerContactEntity> UpdateAsync(PartnerContactEntity request)
        {

            using (var cnx = _context.conexao())
            {
                string _query = $@"Update partnersContact set contactName = '{request.ContactName}', description = '{request.Description}', contactType = '{request.ContactType}', phoneNumber1 = {request.PhoneNumber1}, phoneNumber2 = '{request.PhoneNumber2}' where id = '{request.Id}'";
                var result = await cnx.QueryAsync<PartnerEntity>(_query);
                return new PartnerContactEntity(request.Id, request.PartnerId, request.ContactName, request.Description, request.ContactType, request.PhoneNumber1, request.PhoneNumber2, request.Information);
            }
        }

        public async Task<PartnerContactEntity> GetById(Guid id)
        {

            using (var cnx = _context.conexao())
            {
                string _query = $@"select id, partnerId, contactName, description, contactType, phoneNumber1, phoneNumber2, information from partnersContact where id = '{id}'";
                var result = await cnx.QueryAsync<PartnerContactEntity>(_query);
                return result.FirstOrDefault();
            }
        }

        public async Task<List<PartnerContactEntity>> GetByPartnerId(Guid partnerId)
        {

            using (var cnx = _context.conexao())
            {
                string _query = $@"select id, partnerId, contactName, description, contactType, phoneNumber1, phoneNumber2, information from partnersContact where partnerId = '{partnerId}'";
                var result = await cnx.QueryAsync<PartnerContactEntity>(_query);
                return result.ToList();
            }

        }

        public async Task<bool> DeleteById(Guid id)
        {
            bool result = true;

            using (var cnx = _context.conexao())
            {

                try
                {
                    string _query = $@"delete from partnersContact where PartnerId = '{id}'";
                    await cnx.QueryAsync<PartnerContactEntity>(_query);
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }

                return result;
            }
        }




    }
}
