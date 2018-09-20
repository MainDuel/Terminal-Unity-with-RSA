using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMessage : Command
{
    private string text;
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

        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 4)
            && checkTheTypeOfCommand(commandDistributeds[0], "MESSAGECREATE")
            && checkTheCommandAttribute(commandDistributeds[1], "KEY", 3)
            && checkTheCommandAttribute(commandDistributeds[2], NAME, NAME.Length)
            && checkTheCommandAttribute(commandDistributeds[3], "TEXT", 4);
    }

    private string keyAlreadyExists()
    {
        name = getCommandInformation(commandDistributeds[2]);
        if (messageController.getMessage(name) == null)
        {
            return createMessage();
        }
        else
        {
            return "\nThis message already exists: " + name;
        }
    }

    private string createMessage()
    {
        text = getCommandInformation(commandDistributeds[3]);
        byte[] byteText = encryption.encrypt(this.text, rsa.getPublicKey());
        messageController.insertMessage(name, byteText);
        return "\nCreate message: " + name;
    }    
}
