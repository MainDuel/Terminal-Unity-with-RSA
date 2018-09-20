using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backspace : CommandKeyCode
{
    public override string action()
    {
        indexBar--;
        line = line.Remove(indexBar, 1);
        return AllText + line;
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.Backspace && validateBackspace();
    }

    public bool validateBackspace()
    {
        return indexBar > 0 && indexBar <= line.Length;
    }
}
