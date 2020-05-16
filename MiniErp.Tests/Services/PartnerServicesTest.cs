using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniErp.Application.Contracts.v1.Partners.Request;
using MiniErp.Application.Data.MySql.Repositories;
using MiniErp.Application.Data.MySql.StaticTypes;
using MiniErp.Application.Errors;
using MiniErp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniErp.Tests.Services
{
    
    
    [TestClass]
    public class PartnerServicesTest: MiniErpTests
    {


        [TestInitialize]
        public void BeforeEveryUnitTest()
        {
            var _result = Repository.ExecuteAsync("Delete from partner");
            //var _result2 = Repository.ExecuteAsync("Delete from contactPartner");
        }


        public void Builder(int count)
        {

            for (int cont = 0; cont < count; cont++)
            {
                // Arrange
                string _document = "0"+(cont*10).ToString();

                var _request = new PartnerPostRequest
                {
                    Name = "Registro Nome ("+ cont.ToString()+")",
                    Document = _document,
                    PartnerCode = "000"+ cont.ToString(),
                    Situation = 0,
                    Status = PartnerStatusType.Active
                };

                Service.CreateAsync(_request).GetAwaiter();
            }

        }



        [TestMethod]
        public async Task Partner_Post_Must_Create_List()
        {
            Builder(50);
            
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task Partner_Post_Must_Return_Success()
        {
            // Arrange
            string _document = "26456424895";

            var _request = new PartnerPostRequest { Name ="Denis Rodrigues Fernandes",
                                                    Document = _document,
                                                    PartnerCode = "0001",
                                                    Situation = 0,
                                                    Status = PartnerStatusType.Active
                                                   };

            // Action
            var _responsePartner = await Repository.GetByDocument(_document);
            if (_responsePartner != null)
                await Repository.DeleteById(_responsePartner.PartnerId);

            var _response = await Service.CreateAsync(_request);

            // Assert
            Assert.IsTrue(_response.Success);
        }


        [TestMethod]
        public async Task Partner_Post_Must_Return_Error_Name_Cannot_Be_Null_Or_Empty()
        {
            // Arrange
            string _document = "123456987";

            var _request = new PartnerPostRequest
            {
                Name = "",
                Document = _document,
                PartnerCode = "0001",
                Situation = 0,
                Status = PartnerStatusType.Active
            };

            // Action
            var _responsePartner = await Repository.GetByDocument(_document);
            if (_responsePartner != null)
                await Repository.DeleteById(_responsePartner.PartnerId);

            var _response = await Service.CreateAsync(_request);

            // Assert
            Assert.IsTrue(!_response.Success);
            Assert.IsTrue(_response.GetListErrors()[0].Message == MiniErpErrors.Partner_Post_400_Name_Cannot_Be_Null_Or_Empty.Description());
        }


        [TestMethod()]
        public async Task Partner_Post_Must_Return_Error_Document_Cannot_Be_Null_Or_Empty()
        {
            // Arrange
            string _document = "";

            var _request = new PartnerPostRequest
            {
                Name = "Denis Rodrigues Fernandes",
                Document = _document,
                PartnerCode = "0001",
                Situation = 0,
                Status = PartnerStatusType.Active
            };

            // Action
            var _response = await Service.CreateAsync(_request);

            // Assert
            Assert.IsTrue(!_response.Success);
            Assert.IsTrue(_response.GetListErrors()[0].Message == MiniErpErrors.Partner_Post_400_Document_Cannot_Be_Null_Or_Empty.Description());
        }


        [TestMethod()]
        public async Task Partner_Delete_Must_Return_Success()
        {
            // Arrange
            string _document = "26456424895";

            var _request = new PartnerPostRequest
            {
                Name = "Denis Rodrigues Fernandes",
                Document = _document,
                PartnerCode = "0001",
                Situation = 0,
                Status = PartnerStatusType.Active
            };

            // Action
            var _responsePartner = await Repository.GetByDocument(_document);

            if (_responsePartner == null)
                await Service.CreateAsync(_request);

            var _partnerGetResponse = await Repository.GetByDocument(_document);
            var _deleteResponse = await Repository.DeleteById(_partnerGetResponse.PartnerId);
            
            // Assert
            Assert.IsTrue(_deleteResponse);


        }

        }
}
