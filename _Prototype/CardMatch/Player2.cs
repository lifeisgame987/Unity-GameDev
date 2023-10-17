using UnityEngine;

public class Player : MonoBehaviour{
  
  private Card _firstCard;
  private int _firstCardId;
  
  private Card _secondCard;
  private int _secondCardId;
  
  private bool _canClick = true;
  
  private void Update(){
    if(InputManager.Instance.IsMouseClicked()){
      Vector2 position = InputManager.Instance.GetMousePosition();
      
      float colliderRadius = 0.2f;
      Collider2D collider = Physics2D.OverlapCircle(position, colliderRadius);
      
      if(collider != null && _canClick){
        if(_firstCard == null){
          _firstCard = collider.GetComponent<Card>();
          _firstCardId = _firstCard.CardId;
          _firstCard.OpenCard();
        }
        else{
          _secondCard = collider.GetComponent<Card>();
          _secondCardId = _secondCard.CardId;
          _secondCard.OpenCard();
          
          _canClick = false;
        }
      }
    }
    
    if(_secondCard != null){
      if(_secondCard.IsOpened()){
        if(_firstCardId == _secondCardId){
          // Destroy card
          _firstCard.DestroySelf();
          _secondCard.DestroySelf();
          
          _firstCard = null;
          _secondCard = null;
          
          _canClick = true;
          
          return;
        }
        else{
          // Hide card
          _firstCard.CloseCard();
          _secondCard.CloseCard();
        }
      }
      
      if(_secondCard.IsClosed()){
        _firstCard = null;
        _secondCard = null;
        
        _canClick = true;
      }
    }
  }
}