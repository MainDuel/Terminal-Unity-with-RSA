using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrow : CommandKeyCode
{
    public override string action()
    {
        indexBar--;
        return AllText + line;
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.LeftArrow && checkIndexBarKeyCodeLeft();
    }

    private bool checkIndexBarKeyCodeLeft()
    {
        return indexBar > 0 && indexBar <= line.Length;
    }
}
