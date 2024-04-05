using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
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

    [Header("Display")]
    public TextMeshProUGUI cardnametext;
    public TextMeshProUGUI powerdescriptiontext;
    public TextMeshProUGUI powernametext;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI dmgtext;
    public Image cardImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void DisplayCardInfo()
    {
        if (cardnametext != null)
        {
            cardnametext.text = cardName;
        }

        if (powernametext != null)
        {
            powernametext.text = powerName;
        }

        if (powerdescriptiontext != null)
        {
            powerdescriptiontext.text = powerDescription;
        }

        if(dmgtext != null)
        {
            dmgtext.text = dmg.ToString();
        }

        if (hptext != null)
        {
            hptext.text = hp.ToString();
        }

        if (cardSprite != null)
        {
            cardImage.sprite = cardSprite;
        }
    }
}
