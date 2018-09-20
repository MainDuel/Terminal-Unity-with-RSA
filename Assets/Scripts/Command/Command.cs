using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public abstract class Command
{
    protected string THE_KEY_DOES_NOT_EXIST = "\nThe key does not exist: ";
    protected readonly string NAME = "NAME";
    private CompareInfo compare = CultureInfo.InvariantCulture.CompareInfo;
    protected string name;

    protected static RSAController rSAController = new RSAController();
    protected static MessageController messageController = new MessageController();

    protected string[] commandDistributeds;
    public abstract bool verifyCommand();
    public abstract string action();

    public void setCommand(string command)
    {
        commandDistributeds = command.Split('-');
    }
    protected bool checkTheAmountOfCommandProperties(int amount, int amountExpected)
    {
        return amount == amountExpected;
    }

    protected bool checkTheTypeOfCommand(string command, string commandExpected)
    {
        return command.Replace(" ", "").ToUpper().Contains(commandExpected);
    }

    protected bool checkTheCommandAttribute(string command, string commandExpected, int lengthExpected)
    {
        string internship01 = command.Replace(" ", "").ToUpper();
        if (internship01.Length <= lengthExpected + 2)
            return false;
        string internship02 = internship01.Remove(0, lengthExpected);
        return internship01.Contains(commandExpected)
            && internship02[0].ToString().Equals("\"")
            && internship02[internship02.Length - 1].ToString().Equals("\"");
    }

    protected string getCommandInformation(string command)
    {
        string commandClear = clearSpace(command);
        return commandClear.Remove(0, getStringIndex(commandClear, "\"")).Replace("\"", "");
    }

    private string clearSpace(String text)
    {
        int textSize = text.Length - 1;
        while(text[textSize] == ' ')
        {
            text = text.Remove(textSize);
            textSize--;
        }
        return text;
    }

    private int getStringIndex(string text, string target)
    {
        return compare.IndexOf(text, target);
    }

    public static void clearRSAController()
    {
        rSAController = new RSAController();
    }

    public static void clearMessageController()
    {
        messageController  = new MessageController();
    }
}
