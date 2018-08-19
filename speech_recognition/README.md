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
<b>FilePath <string> - Optional</b><br/>
For Speech recognition, where you want to convert already recorded sound to string, you need to specify the path to that file. You can use absolute and also relative path to that file. 
- WAV: must be in PCM/LPCM format
- AIFF
- AIFF-C
- FLAC: must be native FLAC format; OGG-FLAC is not supported
    
<b>APIKey <string> - Optional</b><br/>

APIKey is the authentication for some engines, which you can use for speech recognition. All speech recognition engines are listed and described in section below - Engine. This argument is optional, because it is dependent on used engine. By default, its `None`.

<br/>
<b>Username <string> - Optional</b><br/>
    
There are some engines, which are using basic authentication method - username and password instead of API key. For them, you have to specify the username. By default, it's `None`.

<br/>
<b>Password <string> - Optional</b><br/>
    
The same as for usernam. There are some engines, which are using basic authentication method - username and password instead of API key. For them, you have to specify also the password. By default, it's `None`.

<br/>
<b>Password <string> - Optional</b><br/>
    
The same as for username. There are some engines, which are using basic authentication method - username and password instead of API key. For them, you have to specify also the password. By default, it's `None`.

---
## Demo
fad

### Python Activity Scope
Now you have all prerequisities for using Python script in UiPath Studio. There needs to be just configured the Python Scope. In this Activity, just put the Path to the Python folder, i.e.: `C:\Python36-32`. The easiest way, how to get the Python location, is to run this command in Command Prompt:
`where python`. Then just remove the last part of the location, which is: `\python.exe`. Now you are able to run the python script in UiPath Studio
