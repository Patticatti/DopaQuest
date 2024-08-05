using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;        // The gem prefab to instantiate
    public Transform parentTransform;   // The parent transform for the instantiated gems
    public int gemCount = 15;           // Number of gems to instantiate
    public float spawnInterval = 0.1f;  // Interval between each gem instantiation
    public AudioClip spawningAudioClip;
    public AudioClip endAudioClip;

    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameEventsManager.instance.onGemsCollected += OnGemsCollected;
    }

    private void OnGemsCollected(int gemsCollected)
    {
        gemCount = 10;
        StartCoroutine(SpawnGems());
    }

    private IEnumerator SpawnGems()
    {
        audioSource.clip = spawningAudioClip;
        audioSource.Play();
        for (int i = 0; i < gemCount; i++)
        {
            Instantiate(gemPrefab, parentTransform);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}