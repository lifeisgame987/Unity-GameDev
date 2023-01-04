using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public List<Word> words;
  
  private bool hasActiveWord = false;
  private Word activeWord;
  public WordSpawner spawner;
  
  void AddWords(){
    Word word = new Word(WordGenerator.GetRandomWord(), spawner.SpawnWords());
    words.Add(word);
    Debug.Log(word.word);
  }
  
  public void TypeLetter(char letter){
    if(hasActiveWord){
      if(activeWord.GetNextLetter() == letter){
        activeWord.LetterTyped();
      }
    }
    else{
      foreach(Word word in words){
        if(word.GetNextLetter() == letter){
          hasActiveWord = true;
          activeWord = word;
          word.LetterTyped();
          break;
        }
      }
    }
    
    if(hasActiveWord && activeWord.WordTyped()){
      hasActiveWord = false;
      words.Remove(activeWord);
    }
  }
}