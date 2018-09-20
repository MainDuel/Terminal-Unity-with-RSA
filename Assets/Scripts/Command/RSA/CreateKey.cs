using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKey : Command{

    public override string action()
    {
        name = getCommandInformation(commandDistributeds[1]);
        if (rSAController.getKey(name) == null)
        {
            rSAController.insertKey(name);
            return "\nCreate key: " + name;
        }
        else
        {
            return "\nThis key already exists: " + name;
        }        
    }

    public override bool verifyCommand()
    {
        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 2) 
            && checkTheTypeOfCommand(commandDistributeds[0], "RSACREATE") 
            && checkTheCommandAttribute(commandDistributeds[1], NAME, NAME.Length);
    }
}
