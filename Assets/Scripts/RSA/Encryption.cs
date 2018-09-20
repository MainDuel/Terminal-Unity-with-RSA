using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


public class Encryption
{
    public byte[] encrypt(string text, string publicKey)
    {
        byte[] dataToEncrypt = convertStringToByte(text);
        RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
        rSACryptoServiceProvider.FromXmlString(publicKey);
        return rSACryptoServiceProvider.Encrypt(dataToEncrypt, false);
    }

    public string decryption(byte[] text, string privateKey)
    {
        byte[] decryptedData;
        RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
        rSACryptoServiceProvider.FromXmlString(privateKey);
        try
        {
            decryptedData = rSACryptoServiceProvider.Decrypt(text, false);
        }
        catch (CryptographicException e)
        {
            throw new System.Exception("Private key wrong");
        }
        return convertByteToString(decryptedData);
    }

    private string convertByteToString(byte[] text)
    {
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        return unicodeEncoding.GetString(text);
    }

    private byte[] convertStringToByte(string text)
    {
        UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
        return unicodeEncoding.GetBytes(text);
    }
}

