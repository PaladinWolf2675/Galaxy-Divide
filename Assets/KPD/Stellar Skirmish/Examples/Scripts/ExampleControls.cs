using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleControls : MonoBehaviour
{

    public Sprite[] PowerupAssets;
    public SpriteRenderer PowerupIcon;

    public ParticleSystem Explosion;

    private int activePower = 0;

    public void OnSwapPowerupClicked()
    {

        activePower += 1;
        if (activePower >= PowerupAssets.Length)
        {
            activePower = 0;
        }

        PowerupIcon.sprite = PowerupAssets[activePower];

    }

    public void OnBurstClicked()
    {
        if (Explosion.isPlaying)
        {
            Explosion.Stop();
        }
        Explosion.Play();
    }
}
