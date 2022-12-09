using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class MusicEvent : UnityEvent<int> { };

public class AudioProcessing : MonoBehaviour
{
    // Start is called before the first frame update
    public float delayAtBeginning = 3;
    public AudioSource audioSource;
    public MusicEvent musicEvent = new MusicEvent();

    public float cutoff0 = 0.25f;
    public float cutoff1 = 1f;
    public float cutoff2 = 2f;
    public float cutoff3 = 3f;

    public float missileThreshold = 4;

    public float frequency = 1;


   // public Coroutine musicCoroutine = null;
    public Coroutine samplingCoroutine = null;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        

    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void StartSamples()
    {
        samplingCoroutine = StartCoroutine(GetSamplesOngoing());


    }

    public void StopSamples()
    {
        StopCoroutine(samplingCoroutine);
    }
    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("Entered gettting sample");
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        float lowAvg = 0;
        float lowMidAvg = 0;
        float midAvg = 0;
        float highAvg = 0;

        //
        for (int i = 1; i < cutoff0 * Mathf.Floor(spectrum.Length/4) - 1; i++)
        {
            lowAvg += spectrum[i];
        }
        //lowAvg = lowAvg / Mathf.Floor(spectrum.Length / 4);
        lowAvg = lowAvg * 10;

        Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(0, lowAvg, 0), Color.blue);

        for (int i = (int) (cutoff0 * Mathf.Floor(spectrum.Length / 4)); i < cutoff1 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            lowMidAvg += spectrum[i];
        }
        //lowMidAvg = lowMidAvg / Mathf.Floor(spectrum.Length / 4);
        lowMidAvg = lowMidAvg * 10;

        Debug.DrawLine(new Vector3(1, 0, 0), new Vector3(1, lowMidAvg, 0), Color.red);

        for (int i = (int) (cutoff1 * Mathf.Floor(spectrum.Length / 4)); i < cutoff2 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            midAvg += spectrum[i];
        }
        //lowAvg = lowAvg / Mathf.Floor(spectrum.Length / 4);
        midAvg = midAvg * 10;

        Debug.DrawLine(new Vector3(2, 0, 0), new Vector3(2, midAvg, 0), Color.green);

        for (int i = (int)(cutoff2 * Mathf.Floor(spectrum.Length / 4)); i < 4 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            highAvg += spectrum[i];
        }
        //lowMidAvg = lowMidAvg / Mathf.Floor(spectrum.Length / 4);
        highAvg = highAvg * 10;

        Debug.DrawLine(new Vector3(3, 0, 0), new Vector3(3, highAvg, 0), Color.cyan);

        Debug.Log((lowAvg, lowMidAvg));*/
    }

    IEnumerator GetSamplesOngoing()
    {
        yield return new WaitForSeconds(delayAtBeginning);

        while (true)
        {
            yield return new WaitForSeconds(frequency);
            GetNextSampleAndVisualize();
        }



    }

    void GetNextSampleAndVisualize()
    {
       // Debug.Log("Entered gettting sample");
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        float lowAvg = 0;
        float lowMidAvg = 0;
        float midAvg = 0;
        float highAvg = 0;

        //
        for (int i = 1; i < cutoff0 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            lowAvg += spectrum[i];
        }

        lowAvg = lowAvg * 10;
        if(lowAvg > missileThreshold)
        {
// musicEvent?.Invoke(0);
        }


        //Debug.DrawLine(new Vector3(0, 0, 0), new Vector3(0, lowAvg, 0), Color.blue);

        for (int i = (int)(cutoff0 * Mathf.Floor(spectrum.Length / 4)); i < cutoff1 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            lowMidAvg += spectrum[i];
        }

        lowMidAvg = lowMidAvg * 10;

        if (lowMidAvg > missileThreshold)
        {
        //    musicEvent?.Invoke(1);
        }


        //Debug.DrawLine(new Vector3(1, 0, 0), new Vector3(1, lowMidAvg, 0), Color.red);

        for (int i = (int)(cutoff1 * Mathf.Floor(spectrum.Length / 4)); i < cutoff2 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            midAvg += spectrum[i];
        }

        midAvg = midAvg * 10;
        if (midAvg > missileThreshold)
        {
          //  musicEvent?.Invoke(2);
        }

        //Debug.DrawLine(new Vector3(2, 0, 0), new Vector3(2, midAvg, 0), Color.green);

        for (int i = (int)(cutoff2 * Mathf.Floor(spectrum.Length / 4)); i < 4 * Mathf.Floor(spectrum.Length / 4) - 1; i++)
        {
            highAvg += spectrum[i];
        }

        highAvg = highAvg * 10;
        if (highAvg > missileThreshold)
        {
        //    musicEvent?.Invoke(3);
        }


        //hack until I decided what I want to do, probably use a dictionary and enum

        if(((lowAvg > lowMidAvg) && (lowAvg > midAvg)) || ((lowAvg > lowMidAvg) && (lowAvg > highAvg)) || ((lowAvg > midAvg) && (lowAvg > highAvg)))
        {
            musicEvent?.Invoke(0);
        }
        if (((lowMidAvg > lowAvg) && (lowMidAvg > midAvg)) || ((lowMidAvg > lowAvg) && (lowMidAvg > highAvg)) || ((lowMidAvg > midAvg) && (lowMidAvg > highAvg)))
        {
            musicEvent?.Invoke(1);
        }
        if (((midAvg > lowMidAvg) && (midAvg > lowAvg)) || ((midAvg > lowMidAvg) && (midAvg > highAvg)) || ((midAvg > lowAvg) && (midAvg > highAvg)))
        {
            musicEvent?.Invoke(2);
        }
        if (((highAvg > lowMidAvg) && (highAvg > midAvg)) || ((highAvg > lowMidAvg) && (highAvg > lowAvg)) || ((highAvg > midAvg) && (highAvg > lowAvg)))
        {
            musicEvent?.Invoke(3);
        }
        //Debug.DrawLine(new Vector3(3, 0, 0), new Vector3(3, highAvg, 0), Color.cyan);

        // Debug.Log((lowAvg, lowMidAvg));


    }
}
