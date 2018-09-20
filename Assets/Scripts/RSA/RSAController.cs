using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSAController {

    private List<RSAAsymmetricCryptography> rSAAsymmetricCryptographies = new List<RSAAsymmetricCryptography>();

    public void deleteKey(string name)
    {
        RSAAsymmetricCryptography rSAAsymmetricCryptographyRemoved = null;
        foreach (RSAAsymmetricCryptography rSAAsymmetricCryptography in rSAAsymmetricCryptographies)
        {
            if (rSAAsymmetricCryptography.name.Equals(name))
                rSAAsymmetricCryptographyRemoved = rSAAsymmetricCryptography;
        }
        rSAAsymmetricCryptographies.Remove(rSAAsymmetricCryptographyRemoved);
    }

    public void insertKey(string name)
    {
        rSAAsymmetricCryptographies.Add(new RSAAsymmetricCryptography(name));
    }

    public RSAAsymmetricCryptography getKey(string name)
    {
        foreach (RSAAsymmetricCryptography rSAAsymmetricCryptography in rSAAsymmetricCryptographies)
        {
            if (String.Equals(rSAAsymmetricCryptography.name, name))
                return rSAAsymmetricCryptography;
        }
        return null;
    }

    public string getAllKeys()
    {
        string keys = "";
        foreach (RSAAsymmetricCryptography rSAAsymmetricCryptography in rSAAsymmetricCryptographies)
        {
            keys +="\n" + rSAAsymmetricCryptography.name;
        }
        return keys;
    }
}
