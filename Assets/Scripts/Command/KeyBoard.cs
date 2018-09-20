using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : Command
{
    public override string action()
    {
        return "\n KEY BOARD: " +
            "\nENTER - Confirm command." +
            "\nBACKSPACE - Delete character." +
            "\nDELETE - Delete line." +
            "\nEND - Clear Terminal." +
            "\nUP ARROW - Returns command confirmed." +
            "\nDOWN ARROW - Returns command confirmed." +
            "\nLEFT ARROW - Navigate the characters." +
            "\nRIGHT ARROW - Navigate the characters.";
    }

    public override bool verifyCommand()
    {
        return checkTheTypeOfCommand(commandDistributeds[0], "\\KEYBOARD");
    }
}
