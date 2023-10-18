using UnityEngine;

public class Player : MonoBehaviour{
  
  private Card _currentCard;
  
  private Card _firstCard;
  private int _firstCardId;
  
  private Card _secondCard;
  private int _secondCardId;
  
  private void Update(){
    if(InputManager.Instance.IsMouseClicked()){
      Vector2 position = InputManager.Instance.GetMousePosition();
      
      float colliderRadius = 0.2f;
      Collider2D collider = Physics2D.OverlapCircle(position, colliderRadius);
      
      if(collider != null){
        
        _currentCard = collider.GetComponent<Card>();
        
        if(_currentCard.IsClosed()){
          if(_firstCard == null){
            _firstCard = _currentCard;
            _firstCardId = _firstCard.CardId;
            _firstCard.OpenCard();
          }
          else{
            _secondCard = _currentCard;
            _secondCardId = _secondCard.CardId;
            _secondCard.OpenCard();
          }
        }
      }
    }
    
    if(_firstCard != null && _secondCard != null){
      if(_firstCard.IsOpened() && _secondCard.IsOpened()){
        if(_firstCardId == _secondCardId){
          _firstCard.DestroySelf();
          _secondCard.DestroySelf();
          RemoveCard();
        }
        else{
          _firstCard.CloseCard();
          _secondCard.CloseCard();
        }
      }
      
      if(_firstCard.IsClosed() && _secondCard.IsClosed()){
        RemoveCard();
      }
    }
  }
  
  private void RemoveCard(){
    _firstCard = null;
    _secondCard = null;
  }
}
