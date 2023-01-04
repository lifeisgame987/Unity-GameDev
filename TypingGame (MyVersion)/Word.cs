using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[System.Serializable]
public class Word{
  
  public string word;
  int charIndex = 0;
  WordDisplay display;
  
  public Word(string _word, WordDisplay _display){
    word = _word;
    display = _display;
    display.SetWord(word);
  }
  
  public char GetLetter(){
    display.RemoveLetter();
    return word[charIndex];
  }
  
  public void LetterTyped(){
    charIndex++;
  }
  
  public bool WordTyped(){
    bool wordTyped = (charIndex >= word.Length);
    if(wordTyped){
      display.RemoveWord();
    }
    return wordTyped
  }
}