using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // dunno
public class Dialogue 
{
    // I have no clue why this script exists, I'm guessing it...
    // just defines dialogue as a list of string lines?
    [SerializeField] List<string> lines;
    public List<string> Lines {
        get {return lines;}
    }
}
