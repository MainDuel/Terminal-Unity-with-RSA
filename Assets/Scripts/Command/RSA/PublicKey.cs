using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicKey : Command
{
    private RSAAsymmetricCryptography rsa;

    public override string action()
    {
        name = getCommandInformation(commandDistributeds[1]);
        rsa = rSAController.getKey(name);
        if (rsa == null)
        {
            return THE_KEY_DOES_NOT_EXIST + name;
        }
        else
        {
            return "\n Key public: " + rsa.getPublicKey();
        }
    }

    public override bool verifyCommand()
    {
        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 2)
            && checkTheTypeOfCommand(commandDistributeds[0], "RSAPUBLIC")
            && checkTheCommandAttribute(commandDistributeds[1], NAME, NAME.Length);
    }
}
