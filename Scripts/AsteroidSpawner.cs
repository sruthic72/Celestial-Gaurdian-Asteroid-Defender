using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AsteroidSpawner : MonoBehaviour
{
    public static AsteroidSpawner instance;
    public GameObject asteroidPrefab;
    public int numberOfAsteroids = 10;
    public float minForce = 5f;
    public float maxForce = 10f;
    public TMP_Text textMeshPro;
    public GameObject gameOverUI;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnAsteroids());

    }

    private void Update()
    {
        textMeshPro.text = Fracture.score.ToString();
    }

    private IEnumerator SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            GameObject asteroid = Instantiate(asteroidPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            Rigidbody rb = asteroid.GetComponent<Rigidbody>();
            rb.AddForce(GetRandomForce(), ForceMode.Impulse);
            rb.angularVelocity = Random.insideUnitSphere * 5f; 
            yield return new WaitForSeconds(2f);
        }
        yield return null;
    }

  

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(-10f, 10f); 
        float y = Random.Range(-6f, 13f);  
        float z = Random.Range(-10f, 10f); 
        return new Vector3(x, y, z);
    }

    Vector3 GetRandomForce()
    {
        float force = Random.Range(minForce, maxForce);
        float angleX = Random.Range(0f, 360f);
        float angleY = Random.Range(0f, 360f);
        float angleZ = Random.Range(0f, 360f);

        Vector3 forceVector = new Vector3(Mathf.Cos(angleX * Mathf.Deg2Rad), Mathf.Cos(angleY * Mathf.Deg2Rad), Mathf.Cos(angleZ * Mathf.Deg2Rad));
        return force * forceVector;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
