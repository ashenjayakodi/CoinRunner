using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip jumpClip;
    public AudioClip coinClip;
    public AudioClip hitClip;
    public AudioClip winClip;

    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayJump() { source.PlayOneShot(jumpClip); }
    public void PlayCoin() { source.PlayOneShot(coinClip); }
    public void PlayHit()  { source.PlayOneShot(hitClip); }
    public void PlayWin()  { source.PlayOneShot(winClip); }
}
