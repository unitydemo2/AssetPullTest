#Using Audio In WebGL

Audio in WebGL is done differently then on all other platforms. On other platforms we use FMOD internally to supply audio playback and mixing. Since the WebGL platform does not support threads, we need to use a different implementation, which is internally based on the Web Audio API, which lets the browser handle audio playback and mixing for us.

Unfortunately, this limits audio functionality in Unity WebGL to supporting only the most basic features. This page will document what is expected to work. Anything not listed here is not currently supported on WebGL.

##AudioSource

Audio sources support basic positional audio playback with pausing and resuming, panning, rolloff, pitch setting, and doppler effect support. 

The following [`AudioSource`](ScriptRef:AudioSource.html) APIs are supported:

**Properties**

* [`clip`](ScriptRef:AudioSource-clip.html)
* [`dopplerLevel`](ScriptRef:AudioSource-dopplerLevel.html)
* [`ignoreListenerPause`](ScriptRef:AudioSource-ignoreListenerPause.html)
* [`ignoreListenerVolume`](ScriptRef:AudioSource-ignoreListenerVolume.html)
* [`isPlaying`](ScriptRef:AudioSource-isPlaying.html)
* [`loop`](ScriptRef:AudioSource-loop.html)
* [`maxDistance`](ScriptRef:AudioSource-maxDistance.html)
* [`minDistance`](ScriptRef:AudioSource-minDistance.html)
* [`mute`](ScriptRef:AudioSource-mute.html)
* [`pitch`](ScriptRef:AudioSource-pitch.html) (Note that only positive values for pitch are supported.)
* [`playOnAwake`](ScriptRef:AudioSource-playOnAwake.html)
* [`rolloffMode`](ScriptRef:AudioSource-rolloffMode.html)
* [`time`](ScriptRef:AudioSource-time.html)
* [`timeSamples`](ScriptRef:AudioSource-timeSamples.html)
* [`velocityUpdateMode`](ScriptRef:AudioSource-velocityUpdateMode.html)
* [`volume`](ScriptRef:AudioSource-volume.html)

**Methods**

* [`Pause`](ScriptRef:AudioSource.Pause.html)
* [`Play`](ScriptRef:AudioSource.Play.html)
* [`PlayDelayed`](ScriptRef:AudioSource.PlayDelayed.html)
* [`PlayOneShot`](ScriptRef:AudioSource.PlayOneShot.html)
* [`PlayScheduled`](ScriptRef:AudioSource.PlayScheduled.html)
* [`SetScheduledEndTime`](ScriptRef:AudioSource.SetScheduledEndTime.html)
* [`SetScheduledStartTime`](ScriptRef:AudioSource.SetScheduledStartTime.html)
* [`Stop`](ScriptRef:AudioSource.Stop.html)
* [`UnPause`](ScriptRef:AudioSource.UnPause.html)
* [`PlayClipAtPoint`](ScriptRef:AudioSource.PlayClipAtPoint.html)

##AudioListener

All [`AudioListener`](ScriptRef:AudioListener.html) APIs are supported.

##AudioClip

Audio clips in WebGL will always be imported in the AAC format, as that is widely supported by different browsers.

The following [`AudioClip`](ScriptRef:AudioClip.html) APIs are supported:

**Properties**

* [`length`](ScriptRef:AudioClip-length.html)
* [`loadState`](ScriptRef:AudioClip-loadState.html)
* [`samples`](ScriptRef:AudioClip-samples.html)

**Methods**

* [`AudioClip.Create`](ScriptRef:AudioClip.Create.html) is supported partially: it only works if the streaming parameter is set to false and the complete audio samples can be loaded at the time `AudioClip.Create` is called. It then creates the clip and loads all samples before returning control.
* [`AudioClip.SetData`](ScriptRef:AudioClip.SetData.html) is supported partially: it only works for replacing the entire contents of the AudioClip. The `offsetSamples` parameter is ignored.

##SystemInfo.supportsAudio
[`SystemInfo.supportsAudio`](ScriptRef:SystemInfo-supportsAudio.html) is not implemented on WebGL and always returns true.

##WWW.audioClip

[`WWW.audioClip`](ScriptRef:WWW-audioClip.html) should work in WebGL, if the audio clip is in a format which is natively supported by the browser. See [Mozilla's documentation on supported media formats](https://developer.mozilla.org/en-US/docs/Web/HTML/Supported_media_formats) for a list of supported formats in different browsers.

##Microphone

The [`Microphone`](ScriptRef:Microphone.html) class is not supported in WebGL.