using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CommandInvalid : Command {

    public override string action()
    {
        return "\nCommand Invalid. report [HELP] at terminal";
    }

    public override bool verifyCommand()
    {
        return true;
    }
}
