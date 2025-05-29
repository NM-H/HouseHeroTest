using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip outHouseMusic;
    public AudioClip firstRoomMusic;
    public AudioClip secondRoomMusic;

    public float fadeDuration = 1.5f;

    private void Awake()
    {
        // Make sure this persists and there's only one MusicManager
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    private void PlayMusicForScene(string sceneName)
    {
        AudioClip newClip = null;

        switch (sceneName)
        {
            case "OutHouse":
                newClip = outHouseMusic;
                break;
            case "FirstRoom":
                newClip = firstRoomMusic;
                break;
            case "SecondRoom":
                newClip = secondRoomMusic;
                break;
        }

        if (newClip != null && audioSource.clip != newClip)
        {
            StartCoroutine(FadeToNewTrack(newClip));
        }
    }

    private IEnumerator FadeToNewTrack(AudioClip newClip)
    {
        if (audioSource.isPlaying)
        {
            // Fade out
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                audioSource.volume = 1 - (t / fadeDuration);
                yield return null;
            }
            audioSource.Stop();
        }

        audioSource.clip = newClip;
        audioSource.Play();

        // Fade in
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = t / fadeDuration;
            yield return null;
        }

        audioSource.volume = 1;
    }
}
