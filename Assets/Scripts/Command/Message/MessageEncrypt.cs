using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MessageEncrypt : Command
{
    public override string action()
    {
        string text = System.Text.UTF8Encoding.UTF8.GetString(messageController.getMessage(name).text);
        return "\nMessage encrypt: " + text;
    }

    public override bool verifyCommand()
    {
        return checkTheAmountOfCommandProperties(commandDistributeds.Length, 2)
            && checkTheTypeOfCommand(commandDistributeds[0], "MESSAGEENCRYPT")
            && checkTheCommandAttribute(commandDistributeds[1], NAME, NAME.Length);
    }
}
