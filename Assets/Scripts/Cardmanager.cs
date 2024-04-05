using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardmanager : MonoBehaviour
{
    public List<CardSO> socards;
    public List<Card> cardprefabs;
    public List<Card> card;

    [SerializeField]
    private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        PopulateData();
    }

    // Update is called once per frame
    
     public void PopulateData()
    {
        Card tempcard = null;
        CardType type = CardType.DEFAULT;
        card.Clear();

        for (int i = 0; i < socards.Count; i++)
        {
            switch(socards[i].cardType)
            {
                case CardType.ROMAN:
                    type = CardType.ROMAN;
                    break;

                case CardType.NORSE:
                    type = CardType.NORSE;
                    break;

                case CardType.JAPANESE:
                    type = CardType.JAPANESE;
                    break;

                case CardType.EGYPTIAN:
                    type = CardType.EGYPTIAN;
                    break;

                case CardType.GREEK:
                    type = CardType.GREEK;
                    break;

                case CardType.CHINESE:
                    type = CardType.CHINESE;
                    break;

                case CardType.INDIAN:
                    type = CardType.INDIAN;
                    break;

                case CardType.SPELL:
                    type = CardType.SPELL;
                    break;

                case CardType.ARTIFACT:
                    type = CardType.ARTIFACT;
                    break;

                default: 
                Debug.LogError("cardtypenotfound");    
                    break;

            }
            if(type!=CardType.DEFAULT)
            {
                int minCount;
                int maxCount;
                minCount = card.Count;
                for(int j =0; j < socards[i].quantity; j++)
                {
                    tempcard = Instantiate(cardprefabs[(int)type], canvasTransform);
                    card.Add(tempcard);
                }
                maxCount = card.Count;
                for(int j = minCount; j<maxCount; j++)
                {
                    card[j].cardAssetName = socards[i].cardAssetName;
                    card[j].cardType = socards[i].cardType;
                    card[j].cardName = socards[i].cardName;
                    card[j].quantity = socards[i].quantity;
                    card[j].hp = socards[i].hp;
                    card[j].dmg = socards[i].dmg;
                    card[j].powerName = socards[i].powerName;
                    card[j].powerDescription = socards[i].powerDescription;
                    card[j].cardSprite = socards[i].cardSprite;

                    card[j].DisplayCardInfo();
                }
               
            }
            else
            {
                Debug.LogError("Card Type Unassigned");
            }
            

            
        }
    }
}
