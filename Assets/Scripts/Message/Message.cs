using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message {

    public string name;
    public byte[] text;

    public Message(string name, byte[] text)
    {
        this.name = name;
        this.text = text;
    }  
}
