using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour{

  private Card _currentCard;

  private Queue<Card> _cards = new Queue<Card>();
    
  private void Update(){
    if(InputManager.Instance.IsMouseClicked()){
      Vector2 position = InputManager.Instance.GetMousePosition();
      
      float colliderRadius = 0.2f;
      Collider2D collider = Physics2D.OverlapCircle(position, colliderRadius);
      
      if (collider != null){
        _currentCard = collider.GetComponent<Card>();
        
        if (_currentCard.IsClosed()){
          _cards.Enqueue(_currentCard);
          _currentCard.OpenCard();
        }
      }
    }
    
    if(_cards.Count >= 2){
      if(_cards.ElementAt(0).IsOpened() && _cards.ElementAt(1).IsOpened()) { 
        if(_cards.ElementAt(0).CardId == _cards.ElementAt(1).CardId){
          _cards.ElementAt(0).DestroySelf();
          _cards.ElementAt(1).DestroySelf();
          _cards.Dequeue();
          _cards.Dequeue();
        }
        else{
          _cards.ElementAt(0).CloseCard();
          _cards.ElementAt(1).CloseCard();
          _cards.Dequeue();
          _cards.Dequeue();
        }
      }
    }
  }
}