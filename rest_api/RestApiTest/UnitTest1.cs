using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using rest_api;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace RestApiTest
{
    public class qwertyas
    {
        Iapi_helper _api;
        public qwertyas(Iapi_helper api)
        {
            _api = api;
        }
        public dynamic result()
        {
            var t = Task.Run(() => _api.PhoneApiAsync("7171"));
            t.Wait();
            return t.Result;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var valid = "\"valid\":false,\"number\":\"5\",\"local_format\":\"\",\"international_format\":\"\",";

            Mock<Iapi_helper> obj = new Mock<Iapi_helper>();
            obj
                .Setup(call => call.PhoneApiAsync("7171"))
                .Returns(
                Task.Run(() =>
                {
                    return ("\"valid\":false,\"number\":\"5\",\"local_format\":\"\",\"international_format\":\"\",");
                }));
            qwertyas helperis = new qwertyas(obj.Object);
            Assert.AreEqual(valid, helperis.result());
        }
    }
}

/*{
  "valid":false,
  "number":"5",
  "local_format":"",
  "international_format":"",
  "country_prefix":"",
  "country_code":"",
  "country_name":"",
  "location":"",
  "carrier":"",
  "line_type":null
}*/
