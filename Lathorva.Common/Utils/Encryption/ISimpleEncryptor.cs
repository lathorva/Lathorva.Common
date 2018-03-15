using System;
using System.Collections.Generic;
using System.Text;

namespace Lathorva.Common.Utils.Encryption
{
    public interface ISimpleEncryptor
    {
        string Encrypt(string clearText);
        string Decrypt(string cipherText);
    }
}
