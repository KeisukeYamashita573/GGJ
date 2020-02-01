using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bibe : MonoBehaviour
{
    private OVRHapticsClip hapticsClip = null;
    void Start()
    {
        byte[] sample = new byte[8];
        for (int i = 0; i < sample.Length; i++)
        {
            sample[i] = 128;
        }
        hapticsClip = new OVRHapticsClip(sample, sample.Length);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (this.transform.parent.name.Contains("Left"))
            {
                OVRHaptics.LeftChannel.Mix(hapticsClip);
            }
            else
            {
                OVRHaptics.RightChannel.Mix(hapticsClip);
            }
        }
    }
}
