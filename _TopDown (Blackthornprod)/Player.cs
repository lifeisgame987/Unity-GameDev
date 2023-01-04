using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
  
  [SerializeField] private float speed;
  [SerializeField] private GameObject[] healthUIs;
  [SerializeField] private Sprite fullHeart;
  [SerializeField] private Sprite emptyHeart;
  public int health;
  private Vector2 movement;
  private Rigidbody2D rb;
  private Animator anim;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }
  
  void Update(){
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    movement = movement.normalized * speed;
    
    if(movement != Vector2.zero){
      anim.SetBool("isRunning", true);
    }
    else{
      anim.SetBool("isRunning", false);
    }
  }
  
  void FixedUpdate(){
    rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
  }
  
  public void TakeDamage(int damage){
    health -= damage;
    UpdateHealthUI(health);
    if(health <= 0){
      Destroy(gameObject);
    }
  }
  
  public void ChangeWeapon(Weapon weaponToEquip){
    Destroy(GameObject.FindGameObjectWithTag("Weapon"));
    Instantiate(weaponToEquip, transform.position, Quaternion.identity, transform);
  }
  
  private void UpdateHealthUI(int currentHealth){
    for(int i=0; i<healthUIs.Length; i++){
      if(i < currentHealth){
        healthUIs[i].GetComponent<Image>().sprite = fullHeart;
      }
      else{
        healthUIs[i].GetComponent<Image>().sprite = emptyHeart;
      }
    }
  }
  
  private void Heal(int healAmount){
    if(health + healAmount > 5){
      health = 5;
    }
    else{
      health += healAmount;
    }
    UpdateHealthUI(health);
  }
}