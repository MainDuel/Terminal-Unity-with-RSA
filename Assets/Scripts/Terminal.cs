using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    [SerializeField]
    private Text terminal;

    private bool bar = false;

    private List<CommandKeyCode> keyCodes = new List<CommandKeyCode>();

    private void Start()
    {
        addKeyCode();
        InvokeRepeating("flashBar", 0f, 0.5f);
    }

    private void Update()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                command(keyCode);
            }
        }
    }

    private void command(KeyCode keyCode)
    {
        foreach (CommandKeyCode commandKeyCode in keyCodes)
        {
            if (commandKeyCode.checkKey(keyCode))
            {
                setTerminal(commandKeyCode.action());
                break;
            }
        }
    }
    private void flashBar()
    {
        if (bar)
        {
            replaceTerminal();
            bar = false;
        }
        else
        {
            setTerminal(CommandKeyCode.getTextWithBar());
            bar = true;
        }
    }

    private void replaceTerminal()
    {
        setTerminal(terminal.text.Replace("|", " "));
    }

    private void setTerminal(string text)
    {
        terminal.text = text;
    }

    private void addKeyCode()
    {
        keyCodes.Add(new Enter());
        keyCodes.Add(new Backspace());
        keyCodes.Add(new Delete());
        keyCodes.Add(new UpArrow());
        keyCodes.Add(new DownArrow());
        keyCodes.Add(new LeftArrow());
        keyCodes.Add(new RightArrow());
        keyCodes.Add(new End());
        keyCodes.Add(new Other());
    } 
}
