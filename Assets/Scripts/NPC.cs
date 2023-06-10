using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Items
{

   public bool assignedGoal { get; set; }
   public bool quest1Done { get; set; }
   public bool quest2Done { get; set; }

   public bool Completed { get; set; }
   [SerializeField] public int CurrentValue { get; set; }
   public int TotalValue { get; set; }

   public string[] npcdialogue;
   public string beanname;

   public GameObject appletextbox;

   public GameObject portal;

   playerInventory inventory;

   enemyChar evilDragon;

   [SerializeField]
   public GameObject enemy;

   [SerializeField]
   public GameObject player;

   public override void interactionPoint()
   {
      questOne();
      if (quest1Done == true){
         questTwo();
      }
      Debug.Log("Interaction NPC");
   }

   public void questOne(){
      if (!assignedGoal && !quest1Done){
         DialogueMech.Instance.NewDialogue(npcdialogue, beanname);
         AssignGoal();

      }
      else if(assignedGoal && !quest1Done){
         checkGoal();
      }
   }

   public void CalculateVal(){

      TotalValue = 3;
      CurrentValue = inventory.appleCollection;
      if (CurrentValue >= TotalValue){
         Completed = true;
      }
   }


    void AssignGoal(){
      assignedGoal = true;

   }

   void checkGoal(){
      CalculateVal();
      if (Completed == true){
         quest1Done = true;
         assignedGoal = false;
         Completed = false;
         enemy.SetActive(true);
         appletextbox.SetActive(false);
      }
      if (!Completed){
         DialogueMech.Instance.NewDialogue(new string[] {"You still haven't done the thing I told you? Get back at it!"}, beanname);
      }
   }

   void Awake(){
      inventory = player.GetComponent<playerInventory>();
      evilDragon = enemy.GetComponent<enemyChar>();

   }

   public void questTwo(){
      if (quest1Done == true){
         if (assignedGoal == false && !quest2Done){
            DialogueMech.Instance.NewDialogue(new string [] {"You got my apples! Thank you fellow Bean! I have one more task for you.","These days, a little evil dragon seems to come and pester me.", "He comes by the boat and tries to eat everything in sight.", "Can you check by the river and teach him a lesson?"}, beanname);
            AssignGoal();
         }
         else if(assignedGoal == true && !quest2Done){
            checkGoal2();
         }

      }
   }

   public void attackDragon(){
      if (evilDragon.enemyKilled == true){
         Completed = true;
      }
   }

   void checkGoal2(){
      if (quest1Done == true){
         attackDragon();
         if (Completed == true){
            quest2Done = true;
            assignedGoal = false;
            Completed = false;
            portal.SetActive(true);
            DialogueMech.Instance.NewDialogue(new string[] {"You just made my life easier. Thank you fellow Bean!", "I hope you found your stay in my village to be an adventerous one.", "Now off you go onto your next adventure!"}, beanname);
         }
         else {
            DialogueMech.Instance.NewDialogue(new string[] {"You still haven't done the thing I told you? Get back at it!"}, beanname);
         }
      }
   }


   

}
