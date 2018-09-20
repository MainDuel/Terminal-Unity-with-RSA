using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CommandRSATest
{
    public static readonly string KEY_NAME = "KeyTest";
    public static readonly string START_OF_COMMAND_CREATE = "RSA CREATE -NAME \"";
    public static readonly string START_OF_COMMAND_DELETE = "RSA DELETE -NAME \"";
    public static readonly string START_OF_COMMAND_PRIVATE = "RSA PRIVATE -NAME \"";
    public static readonly string START_OF_COMMAND_PUBLIC = "RSA PUBLIC -NAME \"";
    public static readonly string END_OF_COMMAND = "\"";
    public static readonly string KEY_CREATION_MESSAGE = "\nCreate key: ";
    public static readonly string THE_KEY_DOES_NOT_EXIST = "\nThe key does not exist: ";
    public CreateKey createKey = new CreateKey();
    public DeleteKey deleteKey = new DeleteKey();

    [TearDown]
    public void GlobalTeardown()
    {
        Command.clearRSAController();
    }

    [Test]
    public void CommandCreateKey()
    {
        createRSAKey();
    }

    [Test]
    public void CommandAttemptsToCreateKeyWithAlreadyExistingKey()
    {
        createRSAKey();
        createKey.setCommand(START_OF_COMMAND_CREATE + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, createKey.verifyCommand());
        Assert.AreEqual("\nThis key already exists: " + KEY_NAME, createKey.action());
    }

    [Test]
    public void CommanDeleteRsaKey()
    {
        createRSAKey();
        deleteKey.setCommand(START_OF_COMMAND_DELETE + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, deleteKey.verifyCommand());
        Assert.AreEqual("\nDeleted Key: " + KEY_NAME, deleteKey.action());
    }

    [Test]
    public void CommandattemptsToDeleteKeyThatDoesNotExist(){
        deleteKey.setCommand(START_OF_COMMAND_DELETE + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, deleteKey.verifyCommand());
        Assert.AreEqual(THE_KEY_DOES_NOT_EXIST + KEY_NAME, deleteKey.action());
    }

    [Test]
    public void CommandListKeyWithTwoKey()
    {
        string keyName = "KeyOther";
        createRSAKey();
        CreateKey createKey = new CreateKey();
        createKey.setCommand(START_OF_COMMAND_CREATE + keyName + END_OF_COMMAND);
        Assert.AreEqual(true, createKey.verifyCommand());
        Assert.AreEqual(KEY_CREATION_MESSAGE + keyName, createKey.action());

        ListKey listKey = new ListKey();
        listKey.setCommand("RSA LIST");
        Assert.AreEqual(true, listKey.verifyCommand());
        Assert.AreEqual("\nKeys: " + "\n" + KEY_NAME + "\n" + keyName, listKey.action());
    }

    [Test]
    public void commandPrivatekey()
    {
        createRSAKey();
        PrivateKey privateKey = new PrivateKey();
        privateKey.setCommand(START_OF_COMMAND_PRIVATE + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, privateKey.verifyCommand());
        Assert.IsTrue(privateKey.action().Contains("\n Key private: "));
    }

    [Test]
    public void commandPrivatekeyWithoutKey()
    {
        PrivateKey privateKey = new PrivateKey();
        privateKey.setCommand(START_OF_COMMAND_PRIVATE + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, privateKey.verifyCommand());
        Assert.IsTrue(privateKey.action().Contains(THE_KEY_DOES_NOT_EXIST));
    }

    [Test]
    public void commandPublicKey()
    {
        createRSAKey();
        PublicKey privateKey = new PublicKey();
        privateKey.setCommand(START_OF_COMMAND_PUBLIC + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, privateKey.verifyCommand());
        Assert.IsTrue(privateKey.action().Contains("\n Key public: "));
    }

    [Test]
    public void commandPublickeyWithoutKey()
    {
        PublicKey privateKey = new PublicKey();
        privateKey.setCommand(START_OF_COMMAND_PUBLIC + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, privateKey.verifyCommand());
        Assert.IsTrue(privateKey.action().Contains(THE_KEY_DOES_NOT_EXIST));
    }

    public void createRSAKey()
    {
        createKey.setCommand(START_OF_COMMAND_CREATE + KEY_NAME + END_OF_COMMAND);
        Assert.AreEqual(true, createKey.verifyCommand());
        Assert.AreEqual(KEY_CREATION_MESSAGE + KEY_NAME, createKey.action());
    }
}
