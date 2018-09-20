using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMessage : Command
{
    public override string action()
    {
        name = getCommandInformation(commandDistributeds[1]);
        if (messageController.getMessage(name) == null)
        {
            return "\nThe message does not exist: " + name;
        }
        else
        {
            messageController.deleteMessage(name);
            return "\nDeleted message: " + name;
        }
    }

    public override bool verifyCommand()
    {
        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 2)
            && checkTheTypeOfCommand(commandDistributeds[0], "MESSAGEDELETE")
            && checkTheCommandAttribute(commandDistributeds[1], NAME, NAME.Length);
    }
}
