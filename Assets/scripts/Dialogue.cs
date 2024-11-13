using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
//isso permite que os objetos dessa classe possam ser 0
public class Dialogue
{
    public string name;
    public Sprite Foto;


    [TextArea (3, 10)]
    public string[] setences;
}
