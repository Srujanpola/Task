
using UnityEngine;
using UnityEditor;
using System.IO;


public class CsvToSo 
{

    //static string cardCsvPath = "/Assets/CsvFile/DF-Gods";
    [MenuItem("Create Card/Generate All Cards")]
    public static void GenerateCards() 
    {
        string[] allPaths=File.ReadAllLines("P:\\Documents\\unity3D\\Task\\Assets\\CsvFile\\DF-Gods.csv");

        foreach (string line in allPaths)
        {
            string[] splitData = line.Split(',');

            Card newCard = ScriptableObject.CreateInstance<Card>();
            newCard.cardType = splitData[0];
            newCard.cardName = splitData[1];
            newCard.quantity = int.Parse(splitData[2]);
         
            newCard.hp = int.Parse(splitData[3]);
            newCard.dmg = int.Parse(splitData[4]);
            newCard.powerName = splitData[5];
            Debug.Log(int.Parse(splitData[2]) + " " + newCard.powerName);
            newCard.powerDescription = splitData[6];


            AssetDatabase.CreateAsset(newCard, $"Assets/Cards/{newCard.cardName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
  

}
