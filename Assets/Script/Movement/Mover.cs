using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamejam.Core;

namespace Gamejam.Movement
{
    public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    [SerializeField] float timeCooldown = 2f;
    bool isCollide ;
    bool isReset;
    
    
     // Start is called before the first frame update
    void Start()
    {
       isCollide = false;
       isReset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCollide)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                speed = 2f;
            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                speed = 0f;
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            print("true");
            
            isReset = true;
        }

        
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(Vector3.zero),Time.deltaTime*3);

        transform.Translate(Vector3.right*speed*Time.deltaTime);
        

    }

    

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.collider.tag == "Obstacle")
    //     {
    //        speed = 0;
    //        isCollide = true;
    //     }
    //     print("touch");
  
    // }
}
}
