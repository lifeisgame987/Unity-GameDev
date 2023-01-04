using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class WordGenerator{
  
  private string[] randomWords = {"norm" , "joke" , "prediction" , "beneficiary" , "shaft" , "equation" , "dictionary" , "closed" , "spend" , "exploit" , "ideology" , "patch" , "pigeon" , "order" , "flatware" , "remind" , "champagne" , "observer" , "settlement" , "noise" , "essential" , "passion" , "inject" , "hit" , "wash" , "gear" , "fantasy" , "beg" , "sweater" , "tail" , "helmet" , "up" , "shape" , "oven" , "vain" , "fence" , "express" , "of" , "obligation" , "stroll" , "snub" , "resignation" , "highway" , "address" , "hypnothize" , "soul" , "veil" , "joy" , "computer" , "quality"};
  
  public static string GetRandomWord(){
    int index = Random.Range(0, randomWords.Length);
    string randomWord = randomWords[index];
    return randomWord;
  }
}