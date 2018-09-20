using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController
{
    List<Message> messages = new List<Message>();

    public void deleteMessage(string name)
    {
        Message messageRemoved = null;
        foreach (Message message in messages)
        {
            if (message.name.Equals(name))
                messageRemoved = message;
        }
        messages.Remove(messageRemoved);
    }

    public void insertMessage(string name, byte[] text)
    {
        messages.Add(new Message(name, text));
    }

    public string getAllMessages()
    {
        string messages = "";
        foreach (Message message in this.messages)
        {
            messages += "\n" + message.name;
        }
        return messages;
    }

    public Message getMessage(string name)
    {
        foreach (Message message in this.messages) { 
            if (message.name.Equals(name))
                return message;
        }
        return null;
    }
}
