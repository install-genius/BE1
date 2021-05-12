using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audio;
    public GameManagerLogic manager;  
    bool isJump;
    public float JumpPower;
    public int MilkCount;
    
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && !isJump) {
            isJump = true;
            rigid.AddForce(new Vector3(0,JumpPower,0),ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h,0,v);
        rigid.AddForce(vec,ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        { 
            isJump = false;
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Milk")
        {
            MilkCount++;
            other.gameObject.SetActive(false);
            audio.Play();
            manager.GetItem(MilkCount);
        }

        else if (other.name == "GameManager")
        {
            SceneManager.LoadScene("Stage" + manager.Stage.ToString());
        }

        else if (other.tag == "Point")
        {
            if (manager.totalItemcount == MilkCount)
            {
                SceneManager.LoadScene("Stage" + (manager.Stage + 1).ToString());
            }

            else
            {
                SceneManager.LoadScene("Stage" + manager.Stage.ToString());
            }
        }



    }
}
