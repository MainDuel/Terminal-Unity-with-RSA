using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownArrow : CommandKeyCode
{
    public override string action()
    {
        indexLines++;
        line = lines[indexLines];
        indexBar = line.Length;
        return AllText + line;
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.DownArrow && checkIndexLineKeyCodeDown();
    }

    private bool checkIndexLineKeyCodeDown()
    {
        return indexLines < lines.Count - 1 && indexLines >= 0;
    }
}
