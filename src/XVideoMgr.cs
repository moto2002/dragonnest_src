using System;
using UnityEngine;
using XUtliPoolLib;

public class XVideoMgr : MonoBehaviour, IXInterface, IXVideo
{
	private XVideo _video;

	private AudioSource _audio;

	public bool isPlaying
	{
		get
		{
			return this._video != null && this._video.isPlaying;
		}
	}

	public bool Deprecated
	{
		get;
		set;
	}

	private void Start()
	{
	}

	public void Play(bool loop = false)
	{
		Handheld.PlayFullScreenMovie("CG.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
	}

	public void Stop()
	{
	}
}
