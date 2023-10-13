// Player
using UnityEngine;

public class Player : MonoBehaviour{
  
  [SerializeField] private float _speed;
  [SerializeField] private float _jumpForce;
  
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private LayerMask _groundLayer;
  
  private float _movementX;
  private bool _jumpPressed;
  private bool _isGrounded;
  private bool _canJump;
  
  private void Start(){
    GM_Tutorial.Instance.OnStateChanged += GM_Tutorial_OnStateChanged;
  }
  
  private void Update(){
    _movementX = Input.GetAxisRaw("Horizontal");
    _jumpPressed = Input.GetKeyDown(KeyCode.Space);
    float groundRadius = 2.0f
    _isGrounded = Physics2D.OverlapCircle(_groundCheck, groundRadius, _groundLayer);
  }
  
  private void FixedUpdate(){
    if(GM_Tutorial.Instance.IsAutoMoving()){
      if(_isGrounded)
        _rb.velocity += _speed * Time.fixedDeltaTime;
      return;
    }
    
    _rb.velocity += (_movementX * _speed) * Time.fixedDeltaTime;
    
    if(_canJump && _jumpPressed && _isGrounded){
      _rb.AddForce(Vector2.up * _jumpForce);
    }
  }
  
  private void OnTriggerEnter2D(Collider2D collider){
    BaseTrigger baseTrigger = collider.GetComponent<BaseTrigger>();
    if(baseTrigger != null){
      baseTrigger.OnTrigger();
    }
    
    Coin coin = collider.GetComponent<Coin>();
    if(coin != null){
      coin.OnCollect();
    }
  }
  
  private void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsJumpUpActive()){
      _canJump = true;
    }
  }
  
  private void OnDestroy(){
    GM_Tutorial.Instance.OnStateChanged -= GM_Tutorial_OnStateChanged;
  }
}

// GM_Tutorial
using UnityEngine;

public class GM_Tutorial : MonoBehaviour{
  
  public static GM_Tutorial Instance {get; private set;}
  
  public event EventHandler OnStateChanged;
  
  private GameState _state;
  
  private void Awake(){
    Instance = this;
  }
  
  private void Start(){
    _state = TutorialState.Start;
  }
  
  private void Update(){
    switch(_state){
      case TutorialState.Start:
        _countdownTimer -= Time.deltaTime;
        if(_countdownTimer < 0f){
          _state = TutorialState.AutoMove;
          OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        break;
      case TutorialState.AutoMove:
        break;
      case TutorialState.MoveRight:
        break;
      case TutorialState.MoveLeft:
        break;
      case TutorialState.JumpUp:
        break;
      case TutorialState.JumpDown:
        break;
      case TutorialState.Collect:
        break;
    }
  }
  
  public bool IsAutoMoving(){
    return _state == TutorialState.AutoMove;
  }
  
  public bool IsMoveRightActive(){
    return _state == TutorialState.MoveRight;
  }

  public bool IsMoveLeftActive(){
    return _state == TutorialState.MoveLeft;
  }
  
  public bool IsJumpUpActive(){
    return _state == TutorialState.JumpUp;
  }
  
  public bool IsJumpDownActive(){
    return _state == TutorialState.JumpDown;
  }
  
  public void ChangeState(TutorialState newState){
    if(_state == newState) return;
    _state = newState;
    OnStateChanged?.Invoke(this, EventArgs.Empty);
  }
}
public enum TutorialState{
  Start,
  AutoMove,
  MoveRight,
  MoveLeft,
  JumpUp,
  JumpDown,
  Collect,
}


// BaseTrigger
using UnityEngine;

public class BaseTrigger : MonoBehaviour{
  
  protected void Start(){
    GM_Tutorial.Instance.OnStateChanged += GM_Tutorial_OnStateChanged;
    Hide();
  }
  
  protected virtual void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    Debug.LogError("BaseTrigger.GM_Tutorial_OnStateChanged()");
  }
  
  public virtual void OnTrigger(){
    Debug.LogError("BaseTrigger.OnTrigger()");
  }
  
  protected void Show(){
    gameObject.SetActive(true);
  }
  
  protected void Hide(){
    gameObject.SetActive(false);
  }
  
  protected void OnDestroy(){
    GM_Tutorial.Instance.OnStateChanged -= GM_Tutorial_OnStateChanged;
  }
}


// MoveRight_Trigger
using UnityEngine;

public class MoveRightTrigger : BaseTrigger{
  
  [SerializeField] private TutorialState _nextState; // TutorialState.MoveRight
  
  private override void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsAutoMoving()){
      Show();
    }
  }
  
  public override void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    Hide();
  }
}

// MoveLeft_Trigger
using UnityEngine;

public class MoveLeftTrigger : BaseTrigger{
  
  [SerializeField] private TutorialState _nextState; // TutorialState.MoveLeft
  
  private override void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsMoveRightActive()){
      Show();
    }
  }
  
  public override void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    Hide();
  }
}

// JumpUp_Trigger
using UnityEngine;

public class JumpUpTrigger : BaseTrigger{
  
  [SerializeField] private TutorialState _nextState; // TutorialState.JumpUp
  
  private override void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsMoveLeftActive()){
      Show();
    }
  }
  
  public override void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    Hide();
  }
}

// JumpDown_Trigger
using UnityEngine;

public class JumpDownTrigger : BaseTrigger{
  
  [SerializeField] private TutorialState _nextState; // TutorialState.JumpDown
  
  private override void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsJumpUpActive()){
      Show();
    }
  }
  
  public override void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    Hide();
  }
}

// JumpFinishedTrigger
using UnityEngine;

public class JumpFinishedTrigger : BaseTrigger{
  
  [SerializeField] private TutorialState _nextState; // TutorialState.Collect
  
  private override void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsJumpDownActive()){
      Show();
    }
  }
  
  public override void OnTrigger(){
    GM_Tutorial.Instance.ChangeState(_nextState);
    Hide();
  }
}


// CoinHolder
using UnityEngine;

public class CoinHolder : MonoBehaviour{
  
  [SerializeField] private TutorialState _nextState; // TutorialState.
  
  private void Start(){
    GM_Tutorial.Instance.OnStateChanged += GM_Tutorial_OnStateChanged;
    Coin.OnAnyCoinCollect += Coin_OnAnyCoinCollect;
    Hide();
  }
  
  private void GM_Tutorial_OnStateChanged(Object sender, System.EventArgs e){
    if(GM_Tutorial.Instance.IsCollectActive){
      Show();
    }
  }
  
  private void Coin_OnAnyCoinCollected(Object sender, System.EventArgs e){
    if(transform.childCount <= 0){
      GM_Tutorial.Instance.ChangeState(_nextState);
      Hide();
    }
  }
  
  private void Show(){
    gameObject.SetActive(true);
  }
  
  private void Hide(){
    gameObject.SetActive(false);
  }
}


// Coin
using UnityEngine;

public class Coin : MonoBehaviour{
  
  public static event EventHandler OnAnyCoinCollect;
  // For static fields/events (except class Instance, methods) 
  // it doesn't get cleaned/destroyed/reset on scene changes,
  // so we have to manually clean it in the MainMenu
  public static void ResetStaticData(){
    OnAnyCoinCollect = null;
  }
  
  public void OnCollect(){
    OnAnyCoinCollect?.Invoke(this, EventArgs.Empty);
    DestroySelf();
  }
  
  private void DestroySelf(){
    Destroy(gameObject);
  }
}


// MainMenu -> ResetStaticDataManager
// Cleaner script for static fields/events
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour{
  
  private void Awake(){
    Coin.ResetStaticData();
  }
}
