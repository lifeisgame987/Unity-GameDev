using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardVisuals : MonoBehaviour{
  
  private const string SHOW_CARD = "Show";
  private const string HIDE_CARD = "Hide";
  [SerializeField] private Card _card;
  [SerializeField] private Animator _anim;
  
  private void OnEnable(){
    Player.Instance.OnCardDifferent += Player_OnCardDifferent;
    Player.Instance.OnCardInteract += Player_OnCardInteract;
  }
  
  private void OnDisable(){
    Player.Instance.OnCardDifferent -= Player_OnCardDifferent;
    Player.Instance.OnCardInteract -= Player_OnCardInteract;
  }
  
  private void Player_OnCardInteract(Object sender, Player.OnCardInteractEventArgs e){
      if(_card.CardId == e.CardId){
        Show();
      }
    }
  
  private void Player_OnCardDifferent(Object sender, Player.OnCardDifferentEventArgs e){
    if(_card.CardId == e.FirstCardId){
      Hide();
    }
    if(_card.CardId == e.SecondCardId){
      Hide();
    }
  }
  
  private void Show(){
    // Make sure has exit time
    _anim.SetTrigger(SHOW_CARD);
  }
  
  private void Hide(){
    // Make sure has exit time
    _anim.SetTrigger(Hide_CARD);
  }
}