using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;        // The gem prefab to instantiate
    public Transform parentTransform;   // The parent transform for the instantiated gems
    public int gemCount = 15;           // Number of gems to instantiate
    public float spawnInterval = 0.03f;  // Interval between each gem instantiation
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
        StartCoroutine(SpawnGems());
    }

    private IEnumerator SpawnGems()
    {
        audioSource.PlayOneShot(spawningAudioClip);
        
        for (int i = 0; i < gemCount; i++)
        {
            Instantiate(gemPrefab, parentTransform);
            yield return new WaitForSeconds(spawnInterval);
        }
        // StartCoroutine(PlayGemEffect());
    }

    private IEnumerator PlayGemEffect()
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(spawnInterval);
            audioSource.PlayOneShot(endAudioClip);
        }
    }
}