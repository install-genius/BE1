using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        
        rigid = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h,0,v);

        rigid.AddForce(vec,ForceMode.Impulse);

    }
        private void OnTriggerStay(Collider other) 
        {
            if (other.name == "Airborn") {
                rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
            }    
        }
}
