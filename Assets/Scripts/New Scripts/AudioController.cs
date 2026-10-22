using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource_01;
    public AudioSource audioSource_02;
    public AudioSource audioSource_03;


    public void PlayAudio(int audioNumber)
    {
        if(audioNumber == 1)
        {
            audioSource_01.Play();
            Debug.Log("audio played");
            
        }
        if(audioNumber == 2)
        {
            audioSource_02.Play();
            
        }
        if(audioNumber == 3)
        {
            audioSource_03.Play();
            
        }
    }

}
