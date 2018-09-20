using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : Command
{
    public override string action()
    {
        return "\n HELP: " +
            "\nRSA CREATE -name \"Key name\"" +
            "\nRSA PUBLIC -name \"Key name\"" +
            "\nRSA PRIVATE -name \"Key name\"" +
            "\nRSA DELETE -name \"Key name\"" +
            "\nRSA LIST" +
            "\n\nMESSAGE LIST" +
            "\nMESSAGE CREATE -KEY \"Key name\" -name \"Message name\" -text \"Message text\" " +
            "\nMESSAGE DELETE -name \"Message name\"" +
            "\nMESSAGE DECRYPTION -key \"Key name\" -name \"Message name\"" +
            "\n\n\\KEY BOARD - Keys available";
    }

    public override bool verifyCommand()
    {
        return checkTheTypeOfCommand(commandDistributeds[0], "\\HELP");
    }
}
