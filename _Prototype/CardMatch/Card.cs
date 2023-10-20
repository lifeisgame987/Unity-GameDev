using UnityEngine;

public class Card : MonoBehaviour{
  
  private const string OPEN_CARD = "IsOpened";
  private const string IS_OPENED = "Opened";
  private const string IS_CLOSED = "Closed";
  
  [SerializeField] private CardSO _cardSO;
  
  public int CardId {get; private set;}
  private Animator _animator;
  
  private bool _isOpened;
  private bool _isClosed;
  
  private void Awake(){
    _animator = GetComponent<Animator>();
  }
  
  private void Start(){
    CardId = _cardSO.Id;
  }
  
  private void Update(){
    _isOpened = _animator.GetCurrentAnimatorStateInfo(0).IsName(IS_OPENED);
    _isClosed = _animator.GetCurrentAnimatorStateInfo(0).IsName(IS_CLOSED);
  }
  
  public void OpenCard(){
    _animator.SetBool(OPEN_CARD, true);
  }
  
  public void CloseCard(){
    _animator.SetBool(OPEN_CARD, false);
  }
  
  public bool IsOpened(){
    return _isOpened;
  }
  
  public bool IsClosed(){
    return _isClosed;
  }
  
  public void DestroySelf(){
    Destroy(gameObject);
  }
}