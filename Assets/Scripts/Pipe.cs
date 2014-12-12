using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour
{
    void Start()
    {
        RandomGeneraterPosition();
    }
         
    public void RandomGeneraterPosition()
    { 
    //how to random a number 
       float pos_y= Random.Range(-0.4f, -0.1f);
       this.transform.localPosition = new Vector3(this.transform.localPosition.x,
           pos_y, this.transform.localPosition.z);

    }

    void OnTriggerExit(Collider other)//关于OnTrigger的事件：OnTriggerEnter OnTriggStay OnTriggerExit
    {
        if (other.tag=="Player")
        {
            //plus scroe
            audio.Play();
            GameManager._intance.score++;
                       
        }
    }

   
    //test code
    void OnGUI()
    {
        
        GUILayout.Label("Score:" + GameManager._intance.score);
    }
}
