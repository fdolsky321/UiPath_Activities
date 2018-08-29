# Speech Recognition
This activity perform the speech / voice recognition. It can process the voice recorded by your microphone or just process Audiofile with recorded voice such a .wav, aiff, .flac. This activity is mostly using [SpeechRecognition python library](https://pypi.org/project/SpeechRecognition/). For this activity, there is provided additional Custom activity for getting input parameters for python script. This custom activity is written in C# and is described below. 

## Table of Contents
- [Requirements](#requirements)
- [Configuration](#configuration)
    - [Import Custom Activity](#import-custom-activity)
    - [Install Python Activities Pack](#nstall-python-activities-pack)
    - [Install and Configure Python 3](#install-and-configure-python-3)
- [Usage](#usage)
    - [Setup Parameters](#setup-parameters)
    - [Run Python script](#run-python-script)
- [Demo](#demo)

---
## Requirements
- [Python 3](https://www.python.org/downloads/)
- [SpeechRecognition Library](https://pypi.org/project/SpeechRecognition/)
- [PyAudio Library](https://pypi.org/project/PyAudio/)
- [Google API Client Library for Python](https://developers.google.com/api-client-library/python/start/installation) - just in case, you want to use Google Cloud engine for speech recognition
- [PocketSphinx](https://pypi.org/project/pocketsphinx/) - just in case, you want to use PocketSphinx as an engine for speech recognition


## Configuration
To be able to use this python script in your UiPath Studio, please follow all instruction below.

### Import Custom Activity
As an additional custom activity, there is an activity to set all parameters for Speech recognition. For handling an input for python script, which is responsible for speech recognition, you can simply use `SetupParameters.cs` activity. The way, how to create a custom activity, you can follow [UiPath instructions](https://activities.uipath.com/docs/creating-a-custom-activity).Firstly, you need to create .dll and then use <b>Nuget Package Explorer</b> to create the nuget package, which will be then imported to UiPath as a Custom Activity. Output of this activity is then used easily as an input for python script. The usage of this custom activity is described [below](#setup-parameters) in Usage section. 


---
### Install Python Activities Pack
The installation of this activity pack is pretty straight forward. You have just to follow [these instructions](https://studio.uipath.com/v2017.1/docs/managing-activities-packages) and find the <b>Python Activities pack</b>. Short info about the existing python activities pack, you can see in [UiPath documentation](https://activities.uipath.com/docs/about-the-python-activities-pack)


---
### Install and Configure Python 3
- Download Python 3.6 (last release, currently 3.6.6) - [Windows x86 embeddable zip file](https://www.python.org/ftp/python/3.6.6/python-3.6.6.exe). Only x86 is compatible with UiPath Studio. For configuration just follow instructions below or use [this tutorial](https://github.com/BurntSushi/nfldb/wiki/Python-&-pip-Windows-installation).
- Open the downloaded `python-3.6.6.exe` file. You can choose `Install Now` with default location OR `Customize installation`. The easiest way is to use `Install Now` option and check the <i>Add Python 3.6 to PATH</i>. Based on this option, you will automatically install and configure all of these.
    - Python 3 Interpreter to the automatically selected location
    - Configure Path to Python, so you can use python interpreter across the whole Environment.
    - Configure [Pip v. 10.0.1](https://en.wikipedia.org/wiki/Pip_(package_manager)) - Python Package manager


---
### Install SpeechRecognition Library
To be able to use SpeechRecognition library, you have to install this library by using Pip. Just open the Command Prompt and run:
`python -m pip install SpeechRecognition`
This will automatically install the up-to-date version of SpeechRecognition library. The whole documentation for this library is [here](https://github.com/Uberi/speech_recognition/blob/master/reference/library-reference.rst). I'm strictly recommend to follow this documentation, as there are many useful information about all functionalities, which are not covered in this documentation.


---
### Install PyAudio Library
To enable more features to this Python script, we are using PyAudio library. Install this library the same way, as SpeechRecognition Library by using command:
`python -m pip install PyAudio`
It will install automatically the up-to-date version of PyAudio library.

---
### Install Google API Client Library
To be able to use Google API Client library, you have to install this library by using Pip. Just open the Command Prompt and run:
`
python -m pip install google-api-python-client
`
This will automatically install the up-to-date version of Google API Client library and you will be able to use Google Cloud for speech recognition. This library requires also API key.

---
### Install PocketSphinx
To be able to use PocketSphinx library, you have to install this library by using Pip. Just open the Command Prompt and run:
`
python -m pip install PocketSphinx
`
This will automatically install the up-to-date version of PocketSphinx library and you will be able to use offline pocketsphinx for speech recognition.

---
## Usage
The whole SpeechRecognition activity consists of two parts. One part is responsible for setting up all necessarily parameters for python script, the second part is the python script, which is responsible for speech recognition. This script can recognize speech recorded from microphone and also the voice in sound files like .wav, .aiff or .flac. In section below, there is tutorial, how to Set up parameters, what these parameters exactly do and whats their impact on final speech recognition.

### Setting Up arguments
For setting up all necessarrily arguments, there is a custom activity provided in this repository. In this Custom Activity, there are these arguments:
<ul>
    <li>Input
        <ul>
            <li>DeviceID</li>
            <li>FilePath</li>
        </ul>
    </li>    
    <li>Logon
        <ul>
            <li>APIKey</li>
            <li>Username</li>
            <li>Password</li>
        </ul>
    </li>
    <li>Options
        <ul>
            <li>DynamicEnergyThreshold</li>
            <li>EnergyThresholdValue</li>
            <li>Engine</li>
            <li>InputLanguage</li>
            <li>PauseThreshold</li>
            <li>PhraseTimeLimit</li>
            <li>TimeoutSeconds</li>
        </ul>
    </li>
    <li>Output
        <ul>
            <li>OutputParameters</li>
        </ul>    
    </li>
</ul>
<br/>
<b>DeviceID <Int32> - Optional</b><br/>
For Speech recognition, where you want to record the voice, you have to specify the ID of input device (microphone). This argument is optional, by default it's 0. Mostly it's good enough to use the default one with index 0. During debugging, you can get the index of all your input devices pretty easily by following python script (for python3):

```python
import speech_recognition as sr
print(sr.Microphone.list_microphone_names())
```

<br/>

`Default value: 0`

<br/>
<b>FilePath <string> - Optional</b><br/>
For Speech recognition, where you want to convert already recorded sound to string, you need to specify the path to that file. You can use absolute and also relative path to that file. All supported input files are listed below:
    
- WAV: must be in PCM/LPCM format
- AIFF
- AIFF-C
- FLAC: must be native FLAC format; OGG-FLAC is not supported

<br/>

`Default value: None`

<br/>
<b>APIKey <string> - Optional</b><br/>

APIKey is the authentication for some engines, which you can use for speech recognition. All speech recognition engines are listed and described in section below - Engine. This argument is optional, because it is dependent on used engine.

<br/>

`Default value: None`

<br/>
<b>Password <string> - Optional</b><br/>
    
The same as for username. There are some engines, which are using basic authentication method - username and password instead of API key. For them, you have to specify also the password.
<br/>

`Default value: None`

<br/>
<b>Username <string> - Optional</b><br/>
    
There are some engines, which are using basic authentication method - username and password instead of API key. For them, you have to specify the username.
<br/>

`Default value: None`

<br/>

<b>DynamicEnergyThreshold <Boolean> - Optional</b><br/>
    
In voice recording, there is important to set up the optimal value, which will eliminate the unwanted noise or background voices. In "normal" conditions, I'm recommending to use this Dynamic Energy Threshold. More details you can see in documentation about the speechrecognition library itself.

<br/>

`Default value: True`

<br/>

<b>EnergyThresholdValue <Int32> - Optional</b><br/>
    
In case, you don't want to use the dynamic threshold for recording your voice, you can specify this threshold. The recommended range is 400-3500. Lower value = lower threshold to start recording voice. In condition with a lot of noice, it's recommended to use higher value. Everything related to that [here](https://github.com/Uberi/speech_recognition/blob/master/reference/library-reference.rst).

<br/>

`Default value: 300`

<br/>

<b>Engine <string> - Optional</b><br/>
There are couple of available engines for speech recognition. For most cases, there is good enough to use default Google Engine. For this engine, you don't need any credentials or API keys. The disadvantage is, that it's maybe not compliant to your company policy, because Google will get all your data. All engines, you can see [here](https://realpython.com/python-speech-recognition/). As in our custom activity, this input is an string, below, you can see the list of available engines in python script.

- Google (no authentication)
- GoogleCloud (APIKey)
- Bing (APIKey)
- Houndify (APIKey)
- IBM (APIKey)
- Sphinx
- Wit (Username, Password)

<br/>

`Default value: Google`

<br/>

<b>InputLanguage <string> - Optional</b><br/>

Some of engines supports to specify the input language for better understanding. Below, I will describe especially Google. The default value is `en-US`, but there are many other languages. All supported languages are mentioned [here](https://cloud.google.com/speech-to-text/docs/languages).  

<br/>

`Default value: en-US`

<br/>

<b>PauseThreshold <double> - Optional</b><br/>

You can specify the delay in seconds, after thet the recording of voice will be stoped and recognized as finished. This limit is not for start of recording (it's the timeout value), but for delay between words.

<br/>

`Default value: 0.8`

<br/>

<b>PhraseTimeLimit <double> - Optional</b><br/>

The phrase_time_limit parameter is the maximum number of seconds that this will allow a phrase to continue before stopping and returning the part of the phrase processed before the time limit was reached. The resulting audio will be the phrase cut off at the time limit. If phrase_timeout is None, there will be no phrase time limit.

<br/>

`Default value: None`

<br/>

<b>TimeoutSeconds <double> - Optional</b><br/>

The timeout parameter is the maximum number of seconds that this will wait for a phrase to start before giving up and throwing an speech_recognition.WaitTimeoutError exception. If timeout is None, there will be no wait timeout.

<br/>

`Default value: None`

<br/>

<b>OutputParameters <IEnumerable><object> - Optional</b>

<br/>



---

## Demo
To demonstrate, how this voice recognition works in UiPath, there are two demo scenarious, which were recorded. The first demo is using input file with a voice, which is recognized and converted to the string. The second demo then use the voice input from microphone and the speech is recognized and converted again to string.

### Python Activity Scope
Now you have all prerequisities for using Python script in UiPath Studio. There needs to be just configured the Python Scope. In this Activity, just put the Path to the Python folder, i.e.: `C:\Python36-32`. The easiest way, how to get the Python location, is to run this command in Command Prompt:
`where python`. Then just remove the last part of the location, which is: `\python.exe`. Now you are able to run the python script in UiPath Studio
