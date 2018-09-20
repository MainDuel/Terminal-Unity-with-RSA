using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CommandMessageTest
{
    public static readonly string START_OF_COMMAND_CREATE = "MESSAGE CREATE -KEY \"";
    public static readonly string START_OF_COMMAND_DELETE = "MESSAGE DELETE -NAME \"";
    public static readonly string START_OF_COMMAND_DECRYPTION = "MESSAGE DECRYPTION -KEY \"";
    public static readonly string MESSAGE_NAME = "MESSAGE";
    public static readonly string MESSAGE_TEXT = "ONCE UPON A TIME TEXT";
    public static readonly string MESSAGE_CREATE_MESSAGE = "\nCreate message: ";
    public static readonly string VOID_NAME = "VOID";
    public static readonly string THE_KEY_DOES_NOT_EXIST = "\nThe key does not exist: ";
    public static readonly string THE_MESSAGE_DOES_NOT_EXIST = "\nThe message does not exist: ";
    public static readonly string DOUBLE_QUOTES = "\"";
    public static readonly string COMMAND_NAME = "\"-NAME \"";
    public static readonly string COMMAND_TEXT = "\"-TEXT \"";

    public CreateMessage createMessage = new CreateMessage();
    public CreateKey createKey = new CreateKey();
    public DeleteMessage deleteMessage = new DeleteMessage();
    public MessageDecryption messageDecryption = new MessageDecryption();

    [TearDown]
    public void GlobalTeardown()
    {
        Command.clearMessageController();
        Command.clearRSAController();
    }

    [Test]
    public void CommandCreateMessage()
    {
        createRSAKey();
        createFirstMessage();
    }

    [Test]
    public void CommandCreateMessageNoKey()
    {
        createMessage.setCommand(START_OF_COMMAND_CREATE + CommandRSATest.KEY_NAME + 
            COMMAND_NAME + MESSAGE_NAME + COMMAND_TEXT + MESSAGE_TEXT + DOUBLE_QUOTES);
        Assert.AreEqual(true, createMessage.verifyCommand());
        Assert.AreEqual((THE_KEY_DOES_NOT_EXIST + CommandRSATest.KEY_NAME), createMessage.action());
    }

    [Test]
    public void CommandCreateMessageThisMessageAlreadyExists()
    {
        CommandCreateMessage();
        createMessage.setCommand(START_OF_COMMAND_CREATE + CommandRSATest.KEY_NAME + 
            COMMAND_NAME + MESSAGE_NAME + COMMAND_TEXT + MESSAGE_TEXT + DOUBLE_QUOTES);
        Assert.AreEqual(true, createMessage.verifyCommand());
        Assert.AreEqual(("\nThis message already exists: " + MESSAGE_NAME), createMessage.action());
    }

    [Test]
    public void CommandDeleteMessage()
    {
        CommandCreateMessage();
        deleteMessage.setCommand(START_OF_COMMAND_DELETE + MESSAGE_NAME + DOUBLE_QUOTES);
        Assert.AreEqual(true, deleteMessage.verifyCommand());
        Assert.AreEqual(("\nDeleted message: " + MESSAGE_NAME), deleteMessage.action());
    }

    [Test]
    public void CommandDeleteMessageDoesNotExist()
    {
        deleteMessage.setCommand(START_OF_COMMAND_DELETE + MESSAGE_NAME + DOUBLE_QUOTES);
        Assert.AreEqual(true, deleteMessage.verifyCommand());
        Assert.AreEqual((THE_MESSAGE_DOES_NOT_EXIST + MESSAGE_NAME), deleteMessage.action());
    }

    [Test]
    public void commandMessageListWithTwoMessage()
    {
        string otherMessageName= "OTHERMESSAGE";
        ListMessage listMessage = new ListMessage();
        CommandCreateMessage();
        createMessage.setCommand(START_OF_COMMAND_CREATE + CommandRSATest.KEY_NAME + 
            COMMAND_NAME + otherMessageName + COMMAND_TEXT + 
            MESSAGE_TEXT + DOUBLE_QUOTES);
        Assert.AreEqual(true, createMessage.verifyCommand());
        Assert.AreEqual((MESSAGE_CREATE_MESSAGE + otherMessageName), createMessage.action());
        listMessage.setCommand("MESSAGE LIST");
        Assert.AreEqual(true, listMessage.verifyCommand());
        Assert.AreEqual(("\nMessages:" + "\n" + MESSAGE_NAME + "\n" + otherMessageName), listMessage.action());
    }

    [Test]
    public void commandMessageDecryption()
    {
        CommandCreateMessage();
        messageDecryption.setCommand(START_OF_COMMAND_DECRYPTION + 
            CommandRSATest.KEY_NAME + COMMAND_NAME + MESSAGE_NAME + DOUBLE_QUOTES);
        Assert.AreEqual(true, messageDecryption.verifyCommand());
        Assert.AreEqual(("\n Message Decryption: " + MESSAGE_NAME + ": " + MESSAGE_TEXT), messageDecryption.action());
    }

    [Test]
    public void commandMessageDecryptionNotKey()
    {
        CommandCreateMessage();
        messageDecryption.setCommand(START_OF_COMMAND_DECRYPTION + VOID_NAME + 
            COMMAND_NAME + MESSAGE_NAME + DOUBLE_QUOTES);
        Assert.AreEqual(true, messageDecryption.verifyCommand());
        Assert.AreEqual((THE_KEY_DOES_NOT_EXIST + VOID_NAME), messageDecryption.action());
    }

    [Test]
    public void commandMessageDecryptionNotMessage()
    {
        CommandCreateMessage();
        messageDecryption.setCommand(START_OF_COMMAND_DECRYPTION + 
            CommandRSATest.KEY_NAME + COMMAND_NAME + VOID_NAME + DOUBLE_QUOTES);
        Assert.AreEqual(true, messageDecryption.verifyCommand());
        Assert.AreEqual((THE_MESSAGE_DOES_NOT_EXIST + VOID_NAME), messageDecryption.action());
    }

    public void createRSAKey()
    {
        createKey.setCommand(CommandRSATest.START_OF_COMMAND_CREATE + 
            CommandRSATest.KEY_NAME + CommandRSATest.END_OF_COMMAND);
        Assert.AreEqual(true, createKey.verifyCommand());
        Assert.AreEqual(CommandRSATest.KEY_CREATION_MESSAGE + 
            CommandRSATest.KEY_NAME, createKey.action());
    }

    public void createFirstMessage()
    {
        createMessage.setCommand(START_OF_COMMAND_CREATE + CommandRSATest.KEY_NAME + 
            COMMAND_NAME + MESSAGE_NAME + COMMAND_TEXT + MESSAGE_TEXT + DOUBLE_QUOTES);
        Assert.AreEqual(true, createMessage.verifyCommand());
        Assert.AreEqual((MESSAGE_CREATE_MESSAGE + MESSAGE_NAME), createMessage.action());
    }
}
