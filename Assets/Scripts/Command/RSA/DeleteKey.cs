using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteKey : Command
{
    public override string action()
    {
        name = getCommandInformation(commandDistributeds[1]);
        if (rSAController.getKey(name) == null)
        {
            return THE_KEY_DOES_NOT_EXIST + name;
        }
        else
        {
            rSAController.deleteKey(name);
            return "\nDeleted Key: " + name;
        }  
    }

    public override bool verifyCommand()
    {
        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 2) 
            && checkTheTypeOfCommand(commandDistributeds[0], "RSADELETE") 
            && checkTheCommandAttribute(commandDistributeds[1], NAME, NAME.Length);
    }
}
