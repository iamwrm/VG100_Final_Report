public static AudioClip ACCombine(params AudioClip[] clips)
{
	if (clips == null || clips.Length == 0){ 
		return null;}
	int length = 0;
	for (int i = 0; i < clips.Length; i++)
	{
		if (clips[i] == null){ 
			continue;}
		length += clips[i].samples * clips[i].channels;
	}