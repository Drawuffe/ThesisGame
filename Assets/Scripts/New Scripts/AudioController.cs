using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource move_Sound;
    public AudioSource place_Sound;
    public AudioSource Rotate_Sound;
    public AudioSource Competion_Sound;


    public void PlayAudio(int audioNumber)
    {
        if(audioNumber == 1)
        {
            move_Sound.Play();
            Debug.Log("audio played");
            
        }
        if(audioNumber == 2)
        {
            place_Sound.Play();
            
        }
        if(audioNumber == 3)
        {
            Rotate_Sound.Play();
            
        }
        if(audioNumber == 4)
        {
            Competion_Sound.Play();
            
        }
    }

}
