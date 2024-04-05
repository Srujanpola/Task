
using UnityEngine;
using UnityEditor;
using System.IO;


public class CsvToSo 
{
    const int cardTypeIndex = 0;
    const int cardAssetNameIndex = 1;
    const int cardNameIndex = 2;
    const int cardQuantityIndex = 3;
    const int cardHPIndex = 4;
    const int cardDMGIndex = 5;
    const int powerNameIndex = 6;
    const int powerDescriptionIndex = 7;
    const int cardSpriteIndex = 8;

    //static string cardCsvPath = "/Assets/CsvFile/DF-Gods";
    [MenuItem("Create Card/Generate All Cards")]
    public static void GenerateCards() 
    {
        string[] allPaths=File.ReadAllLines("C:\\Users\\shhiv\\Documents\\Task\\Assets\\Editor\\CsvFile\\DF-Gods.csv");

        foreach (string line in allPaths)
        {
            string[] splitData = line.Split(',');

            CardSO newCard = ScriptableObject.CreateInstance<CardSO>();
            newCard.cardType = (CardType)System.Enum.Parse(typeof(CardType), splitData[cardTypeIndex]);
            newCard.cardAssetName = splitData[cardAssetNameIndex];
            newCard.cardName = splitData[cardNameIndex];
            newCard.quantity = int.Parse(splitData[cardQuantityIndex]);
         
            newCard.hp = int.Parse(splitData[cardHPIndex]);
            newCard.dmg = int.Parse(splitData[cardDMGIndex]);
            newCard.powerName = splitData[powerNameIndex];
            newCard.powerDescription = splitData[powerDescriptionIndex];
            newCard.cardSprite = Resources.Load<Sprite>(splitData[cardSpriteIndex]);


            AssetDatabase.CreateAsset(newCard, $"Assets/Cards/{newCard.cardAssetName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
  

}
