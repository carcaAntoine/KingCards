using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{

   public AudioMixer mixer;
   public string volumeName;

   public void SetLevel(float volume)
   {
    mixer.SetFloat(volumeName, Mathf.Log(volume) * 20f);
   }

}
