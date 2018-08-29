import speech_recognition as sr
import pyaudio
import ctypes
import os
import sys

MessageBox = ctypes.windll.user32.MessageBoxW

def getSpeech(deviceID=0, filePath=None, inputLanguage="en-US", apiKey=None, username=None, password=None, engine=0, dynamicEnergyThreshold=True, energyThresholdValue=300, pauseThreshold=0.8, timeoutSeconds=None, phraseTimeLimit=None):
    # To list all input devices, use the message box below - useful for debugging
    # MessageBox(None, str(sr.Microphone.list_microphone_names()),'Window title',0)
    mic = sr.Microphone(deviceID)
    r = sr.Recognizer()
    r.dynamic_energy_threshold = dynamicEnergyThreshold
    r.energy_threshold = energyThresholdValue
    r.pause_threshold = pauseThreshold
    try:
        if filePath == None:
            with mic as source:
                MessageBox(None, 'Click OK, wait a while to establish recording - like 1 second','Window title',0)
                audio = r.listen(source, timeoutSeconds, phraseTimeLimit)
        else:
            file = sr.AudioFile(filePath)
            with file as source:
                audio = r.listen(source,timeout=timeoutSeconds,phrase_time_limit=phraseTimeLimit)
    except:
        MessageBox(None, "Error1: "+str(sys.exc_info()),'Error Message',0)
    try:
        if engine == 0:
            result = r.recognize_google(audio, language=inputLanguage) 
        elif engine == 1:
            result = r.recognize_google_cloud(audio,credentials_json=filePath,language=inputLanguage)
        elif engine == 2:
            result = r.recognize_bing(audio,apiKey,language=inputLanguage)
        elif engine == 3:
            result = r.recognize_houndify(audio,client_id=username,client_key=password)
        elif engine == 4:
            result = r.recognize_ibm(audio,username=username,password=password,language=inputLanguage)
        elif engine == 5:
            result = r.recognize_sphinx(audio)
        elif engine == 6:
            result = r.recognize_wit(audio,apiKey)
    except:
        MessageBox(None, "Error2: "+str(sys.exc_info()),'Error Message',0)
    return str(result)
