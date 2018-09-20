using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : CommandKeyCode
{
    private List<Command> commands = new List<Command>();

    public Enter()
    {
        addCommands();
    }

    public override string action()
    { 
        changesBeforeTheCommand();
        foreach (Command command in commands)
        {
            command.setCommand(line);
            if (command.verifyCommand())
            {
                addAllText(command.action());
                break;
            }
        }
        return changesAfterTheCommand();  
    }

    public override bool checkKey(KeyCode keyCode)
    {
        return keyCode == KeyCode.Return;
    }

    private void changesBeforeTheCommand()
    {
        indexBar = 0;
        indexLines = lines.Count + 1;
        lines.Add(line);
        AllText += line;
    }

    private string changesAfterTheCommand()
    {
        AllText += "\n" + user;
        line = "";
        return AllText;
    }

    private void addAllText(string text)
    {
        AllText += text;
    }

    private void addCommands()
    {
        commands.Add(new Help());
        commands.Add(new CreateKey());
        commands.Add(new PublicKey());
        commands.Add(new PrivateKey());
        commands.Add(new ListKey());
        commands.Add(new DeleteKey());
        commands.Add(new CreateMessage());
        commands.Add(new ListMessage());
        commands.Add(new MessageDecryption());
        commands.Add(new DeleteMessage());
        commands.Add(new KeyBoard());
        commands.Add(new CommandInvalid());
    }
}
