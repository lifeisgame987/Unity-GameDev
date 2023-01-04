// Player script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Animator anim;
  public Transform attackPoint;
  public float attackRadius = 0.5f;
  public LayerMask enemyLayers;
  public int attackDamage = 20;
  
  public float attackRate = 2f;
  private float nextTimeToAttack = 0f;
  
  void Update(){
    if(Time.time >= nextTimeToAttack){
      if(Input.GetKeyDown(KeyCode.Space)){
        Attack();
        nextTimeToAttack = Time.time + 1f / attackRate;
      }
    }
  }
  
  void Attack(){
    // Attack animation
    anim.SetTrigger("Attack");
    
    // Attack
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint, attackRadius, enemyLayers);
    
    // Damage
    foreach(Collider2D enemy in hitEnemies){
      enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
    }
  }
  
  void OnDrawGizmosSelected(){
    if(attackPoint == null){
      return;
    }
    Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
  }
}



// Enemy script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public int maxHealth = 100;
  private int currentHealth;
  
  void Start(){
    currentHealth = maxHealth;
  }
  
  public void TakeDamage(int damage){
    anim.SetTrigger("Hurt");
    
    currentHealth -= damage;
    if(currentHealth <= 0){
      Die();
    }
  }
  
  void Die(){
    anim.SetBool("isDead", true);
    
    GetComponent<Collider2D>().enabled = false;
    this.enabled = false;
  }
}