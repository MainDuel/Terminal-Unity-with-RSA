using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMessage : Command
{
    public override string action()
    {
        return "\nMessages:" + messageController.getAllMessages();
    }

    public override bool verifyCommand()
    {
        return checkTheTypeOfCommand(commandDistributeds[0], "MESSAGELIST");
    }
}
