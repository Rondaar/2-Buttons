using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New skin",menuName ="Skins")]
public class Skin : ScriptableObject 
{
    public Color characterColor;
    public Gradient trailCol;
}
