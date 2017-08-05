using UnityEngine;
using System.Collections.Generic;

public class ctrlWR : MonoBehaviour
{
	public static ctrlWR control;      // cheeky self-reference
	public AudioSource audioSource1;                    // our component reference
	public AudioSource audioSource2;                    // our component reference
	public AudioSource audioSource3;                    // our component reference

	void Awake()
	{
		control = this;                          // linking the self-reference
		DontDestroyOnLoad(transform.gameObject); // set to dont destroy
	}
}