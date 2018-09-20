using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;
using NUnit.Framework.Constraints;

public class EncryptionTest
{
    public static readonly string TEXT = "Hello World";
    public RSAAsymmetricCryptography asymmetricCryptography = new RSAAsymmetricCryptography("");

    [Test]
    public void encryptUsingPublicKeyAndDecryptUsingPrivateKey()
    {
        Encryption encryption = new Encryption();
        byte[] encryptedText = encryption.encrypt(TEXT, asymmetricCryptography.getPublicKey());
        string dectyptedText = encryption.decryption(encryptedText, asymmetricCryptography.getPrivateKey());
        Assert.AreEqual(TEXT, dectyptedText);
    }

    [Test]
    public void encryptUsingPublicKeyAndDoesNotDecryptUsingDifferentPrivateKey()
    {
        RSAAsymmetricCryptography asymmetricCryptographyOther = new RSAAsymmetricCryptography("");
        Encryption encryption = new Encryption();
        byte[] encryptedText = encryption.encrypt(TEXT, asymmetricCryptography.getPublicKey());

        var ex = Assert.Throws<Exception>(() => encryption.decryption(encryptedText, 
            asymmetricCryptographyOther.getPrivateKey()));
        Assert.That(ex.Message, Is.EqualTo("Private key wrong"));
    }
    
}
