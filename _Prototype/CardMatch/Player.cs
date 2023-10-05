using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
  
  public static Player Instance {get; private set;}
  
  public event EventHandler<OnCardInteractEventArgs> OnCardInteract;
  public class OnCardInteractEventArgs : EventArgs{
    public class CardId;
  }
  
  public event EventHandler<OnCardSameEventArgs> OnCardSame;
  public class OnCardSameEventArgs : EventArgs{
    public int CardId;
  }
  
  public event EventHandler<OnCardDifferentEventArgs> OnCardDifferent;
  public class OnCardDifferentEventArgs : EventArgs{
    public int FirstCardId;
    public int SecondCardId;
  }
  
  [SerializeField] private LayerMask _cardLayer;
  
  private GameObject _firstCard;
  private int _currentCardId;
  
  private void Awake(){
    if(Instance != null){
      Destroy(gameObject);
    }
    Instance = this;
  }
  
  private void Update(){
    if(Input.GetMouseButtonDown(0)){
      Vector2 position = InputManager.Instance.GetInputPositiin();
      
      float colRadius = 0.2f
      Collider2D col = Physics2D.OverlapCircle(position, colRadius, _cardLayer);
      
      if(col != null){
        
        _currentCardId = col.GetComponent<Card>().CardId;
        OnCardInteract?.Invoke(this, new OnCardInteractEventArgs{ CardId = _currentCardId});
        
        if(_firstCard == null){
          _firstCard = col.gameObject;
        }
        else{
          int firstCardId = _firstCard.GetComponent<Card>().CardId;
          int secondCardId = _currentCardId;
          if(firstCardId == secondCardId){
            // Destroy
            OnCardSame?.Invoke(this, new OnCardSameEventArgs{ CardId = _currentCardId });
          }
          else{
            // Hide
            OnCardDifferent?.Invoke(this, new OnCardDifferentEventArgs{
              FirstCardId = firstCardId
              SecondCardId = secondCardId
            });
          }
          _firstCard = null;
        }
      }
    }
  }
}