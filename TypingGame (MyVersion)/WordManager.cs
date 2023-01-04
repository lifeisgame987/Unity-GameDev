using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public List<Word> wordList;
  Word activeWord;
  bool hasActiveWord = false;
  public WordDisplay display;
  
  public void AddWordToList(){
    Word wordIns = new Word(WordGenerator.GetRandomWord(), display);
    wordList.Add(wordIns);
  }
  
  public void CheckLetter(char letter){
    if(hasActiveWord){
      if(activeWord.GetLetter() == letter){
        activeWord.LetterTyped();
      }
    }
    else{
      foreach(Word w in wordList){
        if(w.GetLetter() == letter){
          hasActiveWord = true;
          activeWord = w;
          w.LetterTyped();
          break;
        }
      }
    }
    
    if(hasActiveWord && activeWord.WordTyped()){
      hasActiveWord = false;
      RemoveWordFromList(activeWord);
    }
  }
  
  void RemoveWordFromList(Word word){
    wordList.Remove(word);
  }
}