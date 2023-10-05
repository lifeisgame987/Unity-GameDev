using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour{
  
  [SerializeField] private CardSO _cardSO;
  [SerializeField] private LayerMask _cardLayer;
  [SerializeField] private Collider2D _col;
  public int CardId {get; private set;}
  
  private void Start(){
    CardId = _cardSO.Id;
  }
  
  private void OnEnable(){
    Player.Instance.OnCardSame += Player_OnCardSame;
  }
  
  private void OnDisable(){
    Player.Instance.OnCardSame -= Player_OnCardSame;
  }
  
  private void Player_OnCardSame(Object sender, Player.OnCardSameEventArgs e){
    if(CardId == e.CardId){
      DestroySelf();
    }
  }
  
  private void DestroySelf(){
    Destroy(gameObject);
  }
}