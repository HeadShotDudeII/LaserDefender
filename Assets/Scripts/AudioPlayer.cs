using System;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("DamageClip")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;
    static AudioPlayer instance;

    private void Awake()
    {
        ManagageAudioPlayer();
    }

    private void ManagageAudioPlayer()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);

    }

    public void PlayDamageClip()
    {
        AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
    }



}
