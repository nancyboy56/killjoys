using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pronouns 
{
    private string subject;
    private string objectPronoun;
    private string possessiveDeterminer;
    private string possessivePronoun;
    private string reflexivePronoun;

    public Pronouns()
    {
        subject = "they";
        objectPronoun = "them";
        possessiveDeterminer = "their";
        possessivePronoun = "theirs";
        reflexivePronoun = "theirself";
    }

    public Pronouns(string newSubject, string newObject, string newPossesiveDeterminer, 
        string newPossessivePronoun, string newReflexiePronoun)
    {
        subject = newSubject;
        objectPronoun = newObject;
        possessiveDeterminer = newPossesiveDeterminer;
        possessivePronoun = newPossessivePronoun;
        reflexivePronoun = newReflexiePronoun;
    }
    

    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }

    public string Object
    {
        get { return objectPronoun; }
        set { objectPronoun = value; }
    }

    public string PossessiveDeterminer
    {
        get { return possessiveDeterminer; }
        set { possessiveDeterminer = value; }
    }

    public string PossessivePronoun
    {
        get { return possessivePronoun; }
        set { possessivePronoun = value; }
    }

    public string ReflexivePronoun
    {
        get { return reflexivePronoun; }
        set { reflexivePronoun = value; }
    }




}
