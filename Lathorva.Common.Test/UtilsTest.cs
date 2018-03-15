using Lathorva.Common.Extensions;
using Lathorva.Common.Utils.Encryption;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lathorva.Common.Test
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void SimpleEncryptorTest()
        {
            ISimpleEncryptor simpleEncryptor = new SimpleEncryptor(StringExtensions.GetRandomString(10));

            var data = StringExtensions.GetRandomString(20);
            var cypher = simpleEncryptor.Encrypt(data);

            var data2 = simpleEncryptor.Decrypt(cypher);

            Assert.AreEqual(data, data2);
        }
    }
}
