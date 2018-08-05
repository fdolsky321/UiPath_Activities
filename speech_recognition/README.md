# Speech Recognition
This activity perform the speech / voice recognition. It can process the voice recorded by your microphone or just process Audiofile with recorded voice such a .wav, aiff, .flac. This activity is mostly using [SpeechRecognition python library](https://pypi.org/project/SpeechRecognition/).

## Prerequisities
- [Python 3](https://www.python.org/downloads/)
- [SpeechRecognition Library](https://pypi.org/project/SpeechRecognition/)
- [PyAudio Library](https://pypi.org/project/PyAudio/)

## Configuration
To be able to use this custom activity in your UiPath Studio, please follow all instruction below.

### [Install Python Activities Pack](https://activities.uipath.com/docs/about-the-python-activities-pack)
The installation of this activity pack is pretty straight forward. You have just to follow [these instructions](https://studio.uipath.com/v2017.1/docs/managing-activities-packages) and find the <b>Python Activities pack</b>.

### Install and Configure Python 3
- Download Python 3.6 (last release, currently 3.6.6) - [Windows x86 embeddable zip file](https://www.python.org/ftp/python/3.6.6/python-3.6.6.exe). Only x86 is compatible with UiPath Studio. For configuration just follow instructions below or use [this tutorial](https://github.com/BurntSushi/nfldb/wiki/Python-&-pip-Windows-installation).
- Open the downloaded `python-3.6.6.exe` file. You can choose `Install Now` with default location OR `Customize installation`. The easiest way is to use `Install Now` option and check the <i>Add Python 3.6 to PATH</i>. Based on this option, you will automatically install and configure all of these:
    --- Python 3 Interpreter to the automatically selected location
    --- Configure Path to Python, so you can use python interpreter across the whole Environment.
    --- Configure [Pip v. 10.0.1](https://en.wikipedia.org/wiki/Pip_(package_manager)) - Python Package manager

### SpeechRecognition Library

### PyAudio Library
