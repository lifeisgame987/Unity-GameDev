using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class RangedEnemy : Enemy{
  
  [SerializeField] private float stopDistance;
  [SerializeField] private Transform shotPoint;
  [SerializeField] private GameObject enemyBullet;
  private Animator anim;;
  
  public override void Start(){
    base.Start();
    anim = GetComponent<Animator>();
  }
  
  void Update(){
    if(player != null){
      if(Vector2.Distance(transform.position, player.position) > stopDistance){
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      }
      
      if(Time.time >= attackTime){
        attackTime = Time.time + timeBetweenAttack;
        anim.SetTrigger("Attack");
      }
    }
  }
  
  public void RangedAttack(){
    Vector2 dir = player.position - shotPoint.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    shotPoint.rotation = rotation;
    
    Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
  }
}