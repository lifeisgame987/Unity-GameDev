using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[System.Serializable]
public class Word{
  
  public string word;
  private int wordIndex;
  private WordDisplay display;
  
  public Word(string _word, WordDisplay _display){
    word = _word;
    wordIndex = 0;
    display = _display;
    // Set word in display
    display.SetWord(word);
  }
  
  public char GetNextLetter(){
    return word[wordIndex];
  }
  
  public void LetterTyped(){
    wordIndex++;
    // Remove letter from display
    display.RemoveLetter();
  }
  
  public bool WordTyped(){
    bool wordTyped = (wordIndex >= word.Length);
    if(wordTyped){
      // Remove word from the display
      display.RemoveWord();
    }
    return wordTyped;
  }
}