#New in Unity 5.6

![abc](DevImages/Fish_5ba48e44ee4d6b20c491d028.jpg)

![abc](Examples/Bird-5ba0d373ee4d6b20c491bc23_5ba8c49c015cc616d89dce2d.jpg)

![abc](Examples/Bird-5ba0d373ee4d6b20c491bc24_5ba8c49c015cc616d89dce2e.jpg)

# Last Updated on 26th December 2018.

To find out about the new features, changes and improvements in this version, please see the [5.6 Release Notes](https://unity3d.com/unity/whats-new/unity-5.6.0).

You can also look at [beta release notes](https://unity3d.com/unity/beta#notes) and the [archive](https://unity3d.com/unity/beta/archive) of beta release notes. 


If you are upgrading existing projects from an earlier version to 5.6, read the [Upgrade Guide to 5.6](UpgradeGuide56) for information about how your project may be affected.


![abc](Images/DW5ad9c8419bb67626d83d695f.png)

![abc](Images/DW5a963922d2f2b83b4ce3e9c6.png)


[DW5a96364cb125ec3c70150c47](Examples/DW5a96364cb125ec3c70150c47.cs)

![](https://images.pexels.com/photos/67636/rose-blue-flower-rose-blooms-67636.jpeg)

hi
asdfa
adfasdf




#Using Audio In WebGL

Audio in WebGL is done differently then on all other platforms. On other platforms we use FMOD internally to supply audio playback and mixing. Since the WebGL platform does not support threads, we need to use a different implementation, which is internally based on the Web Audio API, which lets the browser handle audio playback and mixing for us.

Unfortunately, this limits audio functionality in Unity WebGL to supporting only the most basic features. This page will document what is expected to work. Anything not listed here is not currently supported on WebGL.

##AudioSource

Audio sources support basic positional audio playback with pausing and resuming, panning, rolloff, pitch setting, and doppler effect support.

The following AudioSource APIs are supported:

Properties:

    clip
    dopplerLevel
    ignoreListenerPause
    ignoreListenerVolume
    isPlaying
    loop
    maxDistance
    minDistance
    mute
    pitch (Note that only positive values for pitch are supported.)
    playOnAwake
    rolloffMode
    time
    timeSamples
    velocityUpdateMode
    volume

Methods:

    Pause
    Play
    PlayDelayed
    PlayOneShot
    PlayScheduled
    SetScheduledEndTime
    SetScheduledStartTime
    Stop
    UnPause
    PlayClipAtPoint

##AudioListener

All AudioListener APIs are supported.

##AudioClip

Audio clips in WebGL will always be imported in the AAC format, as that is widely supported by different browsers.

The following All AudioClip APIs are supported. APIs are supported:

Properties:

    length
    loadState
    samples

Methods:

    Create. AudioClip.Create is supported partially: it will only work if the streaming parameter is set to false and the complete audio samples can be loaded at the time AudioClip.Create is called. It will then create the clip and load all samples before returning control.
    SetData. AudioClip.SetData is supported partially: it will only work for replacing the entire contents of the AudioClip. The offsetSamples parameter is ignored.

##WWW.audioClip

WWW.audioClip should work in WebGL, if the audio clip is in a format which is natively supported by the browser. See here for a list of supported formats in different browsers.

##Microphone

The Microphone class is not supported in WebGL.
