using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Cards/CreateCard")]
public class CardSO : ScriptableObject
{
    public string cardAssetName;
    public CardType cardType;
    public string cardName;
    public int quantity;
    public int hp;
    public int dmg;
    public string powerName;
    public string powerDescription;
    public Sprite cardSprite;
   

}
public enum CardType
{
    ROMAN,
    NORSE,
    JAPANESE,
    EGYPTIAN,
    GREEK,
    CHINESE,
    INDIAN,
    SPELL,
    ARTIFACT,
    DEFAULT

}
