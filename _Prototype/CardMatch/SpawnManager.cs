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
  
  private bool canSpawn = true;
  
  private void Awake(){
    _cardIndices = new List<int>();
    _cardsToSpawn = new List<GameObject>();
  }
  
  private void Start(){
    if((_noOfUniqueCardsToSpawn*2) != _spawnPoints.Length){
      Debug.LogError("noOfUniqueCardsToSpawn doesn't match with spawnPoints.Length");
      return;
    }
    AddCardIndices();
    AddCardsToSpawn();
    Shuffle(_cardsToSpawn);
    SpawnCards();
  }
  
  private void Update(){
    if(canSpawn && Game_Manager.Instance.IsGameplayState()){
      canSpawn = false;
      ActivateCards();
    }
  }
  
  private void ActivateCards(){
    for(int i=0; i<_cardsToSpawn.Count; i++){
      _cardsToSpawn[i].SetActive(true);
    }
  }
  
  private void SpawnCards(){
    for(int i=0; i<_cardsToSpawn.Count; i++){
      _cardsToSpawn[i].SetActive(false);
      Instantiate(_cardsToSpawn[i], _spawnPoints[i].position, Quaternion.identity);
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