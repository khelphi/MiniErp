using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniErp.Application.Contracts.v1.Partners.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniErp.Tests.Services
{
    
    
    [TestClass]
    public class PartnerServicesTest: MiniErpTests
    {



        [TestMethod]
        public async Task Post_Success()
        {
            var request = new PartnerPostRequest {Name="Deninho",Document="1789654" };

            var response = await Service.CreateAsync(request);
            Assert.IsTrue(response.Success);
        }

    }
}
