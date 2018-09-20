using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDecryption : Command
{
    private RSAAsymmetricCryptography rsa;
    private Encryption encryption = new Encryption();

    public override string action()
    {
        string keyName = getCommandInformation(commandDistributeds[1]);
        rsa = rSAController.getKey(keyName);

        if (rsa == null)
        {
            return THE_KEY_DOES_NOT_EXIST + keyName;
        }
        else
        {
            return keyAlreadyExists();
        }   
    }

    public override bool verifyCommand()
    {
        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 3)
            && checkTheTypeOfCommand(commandDistributeds[0], "MESSAGEDECRYPTION")
            && checkTheCommandAttribute(commandDistributeds[1], "KEY", 3)
            && checkTheCommandAttribute(commandDistributeds[2], NAME, NAME.Length);
    }

    private string keyAlreadyExists()
    {
        name = getCommandInformation(commandDistributeds[2]);
        if (messageController.getMessage(name) != null)
        {
            string text = encryption.decryption(messageController.getMessage(name).text, rsa.getPrivateKey());
            return "\n Message Decryption: " + name + ": " + text;
        }
        else
        {
            return "\nThe message does not exist: " + name;
        }
    }
}
