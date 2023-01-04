using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Summoner : MonoBehaviour{
  
  [SerializeField] private float minX;
  [SerializeField] private float maxX;
  [SerializeField] private float minY;
  [SerializeField] private float maxY;
  [SerializeField] private float speed;
  [SerializeField] private flaot timeBetweenSummon;
  [SerializeField] private Enemy minion;
  [SerializeField] private int damage;
  [SerializeField] private float meleeAttackSpeed;
  private Vector2 targetPosition;
  private Animator anim;
  private float summonTime;
  
  public override void Start(){
    base.Start();
    float randomX = Random.Range(minX, maxX);
    float randomY = Random.Range(minY, maxY);
    targetPosition = new Vector2(randomX, randomY);
    anim = GetComponent<Animator>();
  }
  
  void Update(){
    if(player != null){
      if(Vector2.Distance(transform.position, targetPosition) > .5f){
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        anim.SetBool("isRunning", true);
      }
      else{
        anim.SetBool("isRunning", false);
        if(Time.Time >= summonTime){
          summonTime = Time.time + timeBetweenSummon;
          anim.SetTrigger("summon");
        }
      }
      
      if(Vector2.Distance(transform.position, player.position) < 2.5f){
        if(Time.time >= attackTime){
          StartCoroutine(Attack());
          attackTime = Time.time + timeBetweenAttack;
        }
      }
    }
  }
  
  public void SummonEnemies(){
    Instantiate(minion, transform.position, Quaternion.identity);
  }
  
  IEnumerator Attack(){
    player.GetComponent<Player>().TakeDamage(damage);
    
    Vector2 originalPosition = transform.position;
    Vector2 playerPosition = player.position;
    
    float percent = 0f;
    while(percent <= 1f){
      percent += Time.deltaTime * meleeAttackSpeed;
      float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
      transform.position = Vector2.Lerp(originalPosition, playerPosition, formula);
      yield return null;
    }
  }
}