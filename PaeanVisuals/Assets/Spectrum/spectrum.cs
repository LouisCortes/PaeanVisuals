using UnityEngine;
using System.Collections;

public class spectrum : MonoBehaviour {

    public float Spectrum1;
    public float Spectrum2;
    public float Spectrum3;
    public float SpectrumAccumulation1;

    void Start () {
	
	}
	
	
	void Update () {
		
		float[] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		for (int i=0; i<1; i++)
		{
            Spectrum1 = spectrum[256];
            Spectrum2 = spectrum[512]*100000;
            Spectrum3 = spectrum[i];

        }
        SpectrumAccumulation1 += Mathf.Pow(Spectrum3 * 10, 1.25f) * 10;
    }
}