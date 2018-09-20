using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : CommandKeyCode
{
    public override string action()
    {
        line = "";
        indexBar = 0;
        return AllText + line;
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.Delete;
    }
}
