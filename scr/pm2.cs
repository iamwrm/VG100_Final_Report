	int aa, ab, ac;
	aa = nowDev.x >= 0 ? 1 : 0;
	ab = nowDev.y >= 0 ? 1 : 0;
	ac = nowDev.z >= 1 ? 1 : 0;
	int[] WRmap = { 3, 4, 2, 1, 0, 7, 5, 6 };
	if (GUI.Button(new Rect(400, 800, 150, 150), " Start Motion")) {
		RecordingX = 1;
	}
	if (GUI.Button(new Rect(400 + 150, 800, 150 / 2, 150), " Stop")) {
		RecordingX = 0;
	}
	if (RecordingX == 1) {
		if ((nowDev).magnitude > 0.5) {
			if (!audioSourceX.isPlaying) {
				audioSourceX.clip = 
				AudioClipColletion[WRmap[aa + ab * 2 + ac * 4]];
				musicScoreX.Add(WRmap[aa + ab * 2 + ac * 4]);
				audioSourceX.Play();
			}
		}
	}
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