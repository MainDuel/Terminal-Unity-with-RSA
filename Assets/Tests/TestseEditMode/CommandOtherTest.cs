using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CommandOtherTest {

    [Test]
    public void commandInvalidTest() {
        CommandInvalid commandInvalid = new CommandInvalid();
        commandInvalid.setCommand("commandInvalid");
        Assert.AreEqual(true, commandInvalid.verifyCommand());
        Assert.AreEqual("\nCommand Invalid. report [HELP] at terminal", commandInvalid.action());
    }

    [Test]
    public void commandKeyBoard()
    {
        KeyBoard keyBoard = new KeyBoard();
        keyBoard.setCommand("\\KEY BOARD");
        Assert.AreEqual(true, keyBoard.verifyCommand());
        Assert.AreEqual("\n KEY BOARD: " +
            "\nENTER - Confirm command." +
            "\nBACKSPACE - Delete character." +
            "\nDELETE - Delete line." +
            "\nEND - Clear Terminal." +
            "\nUP ARROW - Returns command confirmed." +
            "\nDOWN ARROW - Returns command confirmed." +
            "\nLEFT ARROW - Navigate the characters." +
            "\nRIGHT ARROW - Navigate the characters.", keyBoard.action());
    }
    [Test]
    public void commandHelp()
    {
        Help help = new Help();
        help.setCommand("\\HELP");
        Assert.AreEqual(true, help.verifyCommand());
        Assert.AreEqual("\n HELP: " +
            "\nRSA CREATE -name \"Key name\"" +
            "\nRSA PUBLIC -name \"Key name\"" +
            "\nRSA PRIVATE -name \"Key name\"" +
            "\nRSA DELETE -name \"Key name\"" +
            "\nRSA LIST" +
            "\n\nMESSAGE LIST" +
            "\nMESSAGE CREATE -KEY \"Key name\" -name \"Message name\" -text \"Message text\" " +
            "\nMESSAGE DELETE -name \"Message name\"" +
            "\nMESSAGE DECRYPTION -key \"Key name\" -name \"Message name\"" +
            "\n\n\\KEY BOARD - Keys available", help.action());
    }
}
