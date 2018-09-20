using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListKey : Command {

    public override string action()
    {
        return "\nKeys: " + rSAController.getAllKeys();
    }

    public override bool verifyCommand()
    {
        return checkTheTypeOfCommand(commandDistributeds[0], "RSALIST");
    }
}
