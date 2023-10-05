using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{
  
  [SerializeField] private int _noOfUniqueCardsToSpawn;
  [SerializeField, Tooltip("Size of this Array must be DOUBLE of _noOfUniqueCardsToSpawn")] 
  private Transform[] _spawnPoints;
  [SerializeField] private List<GameObject> _cards;
  
  private List<int> _cardIndices;
  private int _currentCardIndex;
  
  private List<GameObject> _cardsToSpawn;
  
  private void Awake(){
    _cardIndices = new List<int>();
    _cardsToSpawn = new List<GameObject>();
  }
  
  private void Start(){
    AddCardIndices();
    AddCardsToSpawn();
    Shuffle(_cardsToSpawn);
    SpawnCards();
  }
  
  private void SpawnCards(){
    for(int i=0; i<_cardsToSpawn.Count; i++){
      Instantiate(_cardsToSpawn[i], _spawnPoints[i]);
    }
  }
  
  private void AddCardsToSpawn(){
    for(int i=0; i<_cardIndices.Count; i++){
      _cardsToSpawn.Add(_cards[_cardIndices[i]]);
      _cardsToSpawn.Add(_cards[_cardIndices[i]]);
    }
  }
  
  private void AddCardIndices(){
    int i=0;
    while(i<_noOfUniqueCardsToSpawn){
      CheckSameCardIndex();
      if(!_cardIndices.Contains(_currentCardIndex)){
        _cardIndices.Add(_currentCardIndex);
        i++;
      }
    }
  }
  
  private void CheckSameCardIndex(){
    int cardIndex = GetRandomIndex(_cards.Count);
    if(_currentCardIndex != cardIndex){
      _currentCardIndex = cardIndex;
      return;
    }
    CheckSameCardIndex();
  }
  
  private int GetRandomIndex(int last){
    return Random.Range(0, last);
  }
  
  private void Shuffle<T>(List<T> inputList){
    for (int i = 0; i < inputList.Count - 1; i++){
      T temp = inputList[i];
      int rand = Random.Range(i, inputList.Count);
      inputList[i] = inputList[rand];
      inputList[rand] = temp;
    }
  }
}