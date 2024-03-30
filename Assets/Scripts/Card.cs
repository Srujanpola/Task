using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Cards/CreateCard")]
public class Card : ScriptableObject
{
    public string cardType;
    public string cardName;
    public int quantity;
    public int hp;
    public int dmg;
    public string powerName;
    public string powerDescription;

}
