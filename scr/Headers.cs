using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
public class scr1 : MonoBehaviour
{
	public AudioSource audioSourceX; public AudioSource audioSource1; 
	public AudioSource audioSource2; public AudioSource audioSource3; 
	public AudioClip blank; public AudioClip p_01; 
	public AudioClip p_02; public AudioClip p_03; 
	public AudioClip p_04; public AudioClip p_05; 
	public AudioClip p_06; public AudioClip p_07;
	 void Start()
	{
		AudioClipColletion.Add(blank);
		AudioClipColletion.Add(p_01); 
		AudioClipColletion.Add(p_02);
		AudioClipColletion.Add(p_03); 
		AudioClipColletion.Add(p_04);
		AudioClipColletion.Add(p_05); 
		AudioClipColletion.Add(p_06);
		AudioClipColletion.Add(p_07);
		}
}