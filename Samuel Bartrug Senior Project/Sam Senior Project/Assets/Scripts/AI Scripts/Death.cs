using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public AudioSource jumpScare;
    public AudioListener listener;
    public Camera cam1;
    public Camera cam2;
    public Animator animator;
    public float waitTime;
    bool itIsTime = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        cam1.enabled = true;
        cam2.enabled = false;
    }

    private void Update()
    {
        if(itIsTime)
        {
            waitTime -= Time.deltaTime;
        }
        if(waitTime < 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        GameObject g = collider.gameObject;
        if (g.CompareTag("Player"))
        {
            animator.SetTrigger("Death");
        }
        cam1.enabled = false;
        cam2.enabled = true;
        
        listener.enabled = true;
        jumpScare.Play();
        itIsTime = true;
        Destroy(g);
        
    }


}
