using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSnippetsAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public List<AudioClip> clips = new List<AudioClip>();
    public AudioSource source = null;
    void Start()
    {
        StartCoroutine(PlayRandomClips());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayRandomClips()
    {
        while (true)
        {

                yield return new WaitForSeconds(5);
                foreach (AudioClip clip in clips)
                {
                    source.PlayOneShot(clip);
    
                    
                    yield return new WaitForSeconds(10);

                }
                

            
        }
    }
}
