using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


public class RSAAsymmetricCryptography
{
    RSACryptoServiceProvider rSACryptoServiceProvider;
    public string name { get; }

    public RSAAsymmetricCryptography(string name)
    {
        rSACryptoServiceProvider = new RSACryptoServiceProvider();
        this.name = name;
    }

    public string getPublicKey()
    {
        return rSACryptoServiceProvider.ToXmlString(false); 
    }

    public string getPrivateKey()
    {
        return rSACryptoServiceProvider.ToXmlString(true);
    }
}

