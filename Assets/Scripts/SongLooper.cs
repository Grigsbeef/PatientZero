using UnityEngine;

public class SongLooper : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] songs; // Assign exactly 4 songs
    private int index = 0;

    void Start()
    {
        PlayNextSong();
    }

    void PlayNextSong()
    {
        // Play current song
        audioSource.clip = songs[index];
        audioSource.Play();

        // Move to next index (wrap around after 4)
        index = (index + 1) % songs.Length;

        // Schedule the recursive call when this clip ends
        Invoke(nameof(PlayNextSong), audioSource.clip.length);
    }
}
