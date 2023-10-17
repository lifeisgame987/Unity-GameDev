using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{
  
  [SerializeField] private int _noOfUniqueCardsToSpawn;
  
  [Header("Size of this Array must be DOUBLE of _noOfUniqueCardsToSpawn")]
  [SerializeField] private Transform[] _spawnPoints;
  [SerializeField] private List<CardSO> _cardsSO;
  
  private List<int> _cardIndices;
  private int _currentCardIndex;
  
  private List<GameObject> _cardsToSpawn;
  
  private void Awake(){
    _cardIndices = new List<int>();
    _cardsToSpawn = new List<GameObject>();
  }
  
  private void Start(){
    if((_noOfUniqueCardsToSpawn*2) != _spawnPoints.Length){
      Debug.LogError("_noOfUniqueCardsToSpawn doesn't match with _spawnPoints.Length");
      return;
    }
    AddCardIndices();
    AddCardsToSpawn();
    Shuffle(_cardsToSpawn);
    SpawnCards();
  }
  
  private void SpawnCards(){
    for(int i=0; i<_cardsToSpawn.Count; i++){
      Instantiate(_cardsToSpawn[i], _spawnPoints[i].position, Quoternion.identity);
    }
  }
  
  private void AddCardsToSpawn(){
    for(int i=0; i<_cardIndices.Count; i++){
      _cardsToSpawn.Add(_cardsSO[_cardIndices[i]].Prefab);
      _cardsToSpawn.Add(_cardsSO[_cardIndices[i]].Prefab);
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