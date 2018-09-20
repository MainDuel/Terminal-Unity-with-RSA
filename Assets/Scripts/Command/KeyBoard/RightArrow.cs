using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrow : CommandKeyCode
{
    public override string action()
    {
        indexBar++;
        return AllText + line;
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.RightArrow && checkIndexBarKeyCodeRight();
    }

    private bool checkIndexBarKeyCodeRight()
    {
        return indexBar >= 0 && indexBar < line.Length;
    }
}
