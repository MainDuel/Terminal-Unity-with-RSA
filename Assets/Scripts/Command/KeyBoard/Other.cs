using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : CommandKeyCode
{
    public override string action()
    {
        insertChar(readKeyCode());
        return AllText + line;
    }

    private string readKeyCode()
    {
        return Input.inputString;
    }
    private void insertChar(string input)
    {
        if (input.Length > 0)
        {
            line = line.Insert(indexBar, input[0].ToString());
            indexBar++;
        }
    }
    public override bool checkKey(KeyCode keyCode)
    {
        return true;
    }
}
