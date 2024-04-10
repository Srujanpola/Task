using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cardmanager : MonoBehaviour
{
    public List<CardSO> socards;
    public List<Card> cardprefabs;
    public List<Card> card;
    public bool shuffled = false;
    public AudioSource bg;

    [SerializeField]
    private Transform canvasTransform;

    [SerializeField] GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        PopulateData();
        //button.onClick.AddListener(ShuffleAndMoveFirstCard);
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

    public void ShuffleAndMoveFirstCard()
    {
        button.SetActive(false);
        if (shuffled == true)
        {
            for (int i = 0; i < 5; i++)
            {
                StartCoroutine(MoveCardOverTime(card[i], card[i].transform.position, canvasTransform.position,0));
            }
        }       
        card.Shuffle(); // Shuffle the cards
        bg.Play();
        float duration = 1.0f; // Set the duration of the movement
        StartCoroutine(MoveCardOverTime(card[0], card[0].transform.position, new Vector3(320, 180, 0), duration));
        for ( int i = 1; i < 5; i++)
        {
            StartCoroutine(MoveCardOverTime(card[i], card[i].transform.position, new Vector3((i+1)*320, 180, 0), duration));
        }
        shuffled = true;
        Invoke("ActivateCard", 1f);
    }

    private IEnumerator MoveCardOverTime(Card cardObject, Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor based on elapsed time and duration
            float t = elapsedTime / duration;

            // Interpolate the position using Lerp
            cardObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure that the card reaches the target position precisely
        cardObject.transform.position = targetPosition;
    }

    void ActivateCard()
    {
        button.SetActive(true);
    }
}
