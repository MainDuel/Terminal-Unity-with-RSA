using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : CommandKeyCode
{
    public override string action()
    {
        AllText = user;
        line = "";
        indexBar = 0;
        return AllText + line;
    }

    public override bool checkKey(KeyCode keycode)
    {
        return keycode == KeyCode.End;
    }
}
