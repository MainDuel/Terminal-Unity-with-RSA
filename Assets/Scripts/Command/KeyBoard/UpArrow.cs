using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpArrow : CommandKeyCode
{
    public override string action()
    {
        indexLines--;
        line = lines[indexLines];
        indexBar = line.Length;
        return AllText + line;
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.UpArrow && checkIndexLineKeyCodeUp();
    }

    private bool checkIndexLineKeyCodeUp()
    {
        return indexLines <= lines.Count && indexLines > 0;
    }
}
