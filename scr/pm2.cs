	if (GUI.Button(new Rect(400 - 50, 800 - 300, 130 + 50, 100), "Play Together")) {
		if ((!audioSource1.isPlaying) && (!audioSource2.isPlaying) 
			&& (!audioSource3.isPlaying)) {
			ctrlWR1.control.audioSource1.Play();
			ctrlWR1.control.audioSource2.Play();
			ctrlWR1.control.audioSource3.Play();
			ctrlWR.control.audioSource1.Play();
			ctrlWR.control.audioSource2.Play();
			ctrlWR.control.audioSource3.Play();
		}
	}
}