# Speech Recognition
This activity perform the speech / voice recognition. It can process the voice recorded by your microphone or just process Audiofile with recorded voice such a .wav, aiff, .flac. This activity is mostly using [SpeechRecognition python library](https://pypi.org/project/SpeechRecognition/). For this activity, there is provided additional Custom activity for getting input parameters for python script. This custom activity is written in C# and is described below. 


## Content
- [Prerequisities]
- [Configuration]
    - [Import Custom Activity]
    - [Install Python Activities Pack]

## Prerequisities
- [Python 3](https://www.python.org/downloads/)
- [SpeechRecognition Library](https://pypi.org/project/SpeechRecognition/)
- [PyAudio Library](https://pypi.org/project/PyAudio/)


## Configuration
To be able to use this python script in your UiPath Studio, please follow all instruction below.

### Import Custom Activity
As an additional custom activity, there is an activity to set all parameters for Speech recognition. For handling an input for python script, which is responsible for speech recognition, you can simply use `SetupParameters.cs` activity. The way, how to create a custom activity, you can follow [UiPath instructions](https://activities.uipath.com/docs/creating-a-custom-activity).Firstly, you need to create .dll and then use <b>Nuget Package Explorer</b> to create the nuget package, which will be then imported to UiPath as a Custom Activity. In this Custom Activity, there are these arguments.

Input
    DeviceID<string>
Logon
    APIKey<string>
    Username<string>
    Password<string>
Options
    Engine<string>
    DynamicEnergyThreshold<Boolean>
    EnergyThresholdValue<Int32>
    PauseThreshold<double>
    TimeoutSeconds<double>
    PhraseTimeLimit<double>
    InputLanguage<string>
Output
    OutputArguments<IEnumerable<object>>
<ul>
    <li>Input
        <ul>
            <li>DeviceID</li>
        </ul>
    </li>    
    <li>
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


---
### Install Python Activities Pack
The installation of this activity pack is pretty straight forward. You have just to follow [these instructions](https://studio.uipath.com/v2017.1/docs/managing-activities-packages) and find the <b>Python Activities pack</b>. Short info about the existing python activities pack, you can see in [UiPath documentation](https://activities.uipath.com/docs/about-the-python-activities-pack)


---
### [Install and Configure Python 3](https://www.python.org/)
- Download Python 3.6 (last release, currently 3.6.6) - [Windows x86 embeddable zip file](https://www.python.org/ftp/python/3.6.6/python-3.6.6.exe). Only x86 is compatible with UiPath Studio. For configuration just follow instructions below or use [this tutorial](https://github.com/BurntSushi/nfldb/wiki/Python-&-pip-Windows-installation).
- Open the downloaded `python-3.6.6.exe` file. You can choose `Install Now` with default location OR `Customize installation`. The easiest way is to use `Install Now` option and check the <i>Add Python 3.6 to PATH</i>. Based on this option, you will automatically install and configure all of these.
    - Python 3 Interpreter to the automatically selected location
    - Configure Path to Python, so you can use python interpreter across the whole Environment.
    - Configure [Pip v. 10.0.1](https://en.wikipedia.org/wiki/Pip_(package_manager)) - Python Package manager


---
### [SpeechRecognition Library](https://pypi.org/project/SpeechRecognition/)
To be able to use SpeechRecognition library, you have to install this library by using Pip. Just open the Command Prompt and run:
`python -m pip install SpeechRecognition`
This will automatically install the up-to-date version of SpeechRecognition library.


---
### [PyAudio Library](https://pypi.org/project/PyAudio/)
To enable more features to this Python script, we are using PyAudio library. Install this library the same way, as SpeechRecognition Library by using command:
`python -m pip install PyAudio`
It will install automatically the up-to-date version of PyAudio library.

---
## Python Activity Scope
Now you have all prerequisities for using Python script in UiPath Studio. There needs to be just configured the Python Scope. In this Activity, just put the Path to the Python folder, i.e.: `C:\Python36-32`. The easiest way, how to get the Python location, is to run this command in Command Prompt:
`where python`. Then just remove the last part of the location, which is: `\python.exe`. Now you are able to run the python script in UiPath Studio
