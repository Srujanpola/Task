using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Animation : MonoBehaviour
{
    public List<Card> cardsToPlace;
    public Vector3[] cardPositions;
    public float shuffleDuration = 1.0f;
    public float placeDuration = 0.5f;
    public float delayBetweenCards = 0.1f;

    void Start()
    {
        ShuffleCards();
        PlaceCardsWithAnimation();
    }

    void ShuffleCards()
    {
        int n = cardsToPlace.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Card temp = cardsToPlace[k];
            cardsToPlace[k] = cardsToPlace[n];
            cardsToPlace[n] = temp;
        }
    }
    void PlaceCardsWithAnimation()
    {
        for (int i = 0; i < cardsToPlace.Count; i++)
        {
            Card card = cardsToPlace[i];
            Vector3 targetPosition = cardPositions[i];
            card.transform.DOMove(targetPosition, placeDuration).SetEase(Ease.OutQuad).SetDelay(i * delayBetweenCards);
        }
    }


}
