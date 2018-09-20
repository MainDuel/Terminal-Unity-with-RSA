using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandKeyCode
{
    protected static string AllText = "";
    protected static List<string> lines = new List<string>();
    protected static string user = "Du3l0@Unity:~$ ";
    protected static string line = "";
    protected static int indexBar = 0;
    protected static int indexLines = 0;

    public abstract bool checkKey(KeyCode keycode);
    public abstract string action();

    public CommandKeyCode()
    {
        AllText = user;
    }

    public static string getTextWithBar()
    {
        return AllText + line.Insert(indexBar, "|");
    }
}
