using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    public GameObject fractured;
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public static int score = 0;

    private void OnMouseDown()
    {
        GameObject ast = Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        foreach (Transform child in ast.transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Destroy(gameObject); //Destroy the object to stop it getting in the way
        score++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Planet"))
        {
            Time.timeScale = 0f;
            AsteroidSpawner.instance.gameOverUI.SetActive(true);
            print("hit the planet");
        }
    }
}
