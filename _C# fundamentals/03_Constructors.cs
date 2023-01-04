using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Constructors{
  
}

[System.Serializable]
public class Job{
  
  public string jobTitle;
  public string jobDescription;
  public int jobSalary;
  
  public Job(string title, int salary){
    this.jobTitle = title;
    this.jobSalary = salary;
  }
  
  public Job(string title, string description, int salary){
    this.jobTitle = title;
    this.jobDescription = description;
    this.jobSalary = salary;
  }
}



// Another class
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Player : MonoBehaviour{
  
  public Job[] jobs = new Job[2];
  
  void Start(){
    jobs[0] = new Job("Engineer", 100000);
    jobs[1] = new Job("Doctor", "Surgeon", 500000);
  }
  
  void Update(){
    
  }
}