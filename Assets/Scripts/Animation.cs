using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public GameObject card;

    private void Start()
    {
        MoveCard();
    }
    public void MoveCard()
    {
        card.GetComponent<RectTransform>().DOAnchorPosX(500f,1f);
        card.GetComponent<Image>().color = Color.cyan;
    }
}
