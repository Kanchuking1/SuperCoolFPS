using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerDeath : MonoBehaviour
{
    public PostProcessProfile gameMenu;
    public float thresholdForBulletDestruction;
    ColorGrading co;

    float coValue;

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameOver>().playerDead = true;
            FindObjectOfType<TimeManager>().playerdeath = true;
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.GetComponent<AudioSource>().enabled = false;
            collision.gameObject.GetComponent<Bullet>().enabled = false;
            collision.gameObject.GetComponentInChildren<Camera>().transform.DetachChildren();
            Debug.Log("Lock State: " + Cursor.lockState + "\nVisible: " + Cursor.visible);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Lock State: " + Cursor.lockState + "\nVisible: " + Cursor.visible);
            //Debug.Log("Cursor Is Visible Again");
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(gameObject.transform.position.magnitude > thresholdForBulletDestruction)
        {
            Destroy(this.gameObject);
        }
    }
}
