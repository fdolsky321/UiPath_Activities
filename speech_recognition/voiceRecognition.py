import speech_recognition as sr
import pyaudio
import ctypes
import os

MessageBox = ctypes.windll.user32.MessageBoxW

def getSpeech(deviceID=0, filePath=None, inputLanguage="en-us", apiKey=None, username=None, password=None, engine="Google", dynamicEnergyThreshold=True, energyThresholdValue=None, pauseThreshold=None, timeoutSeconds=None, phraseTimeLimit=None):
    # To list all input devices, use the message box below - useful for debugging
    # MessageBox(None, str(sr.Microphone.list_microphone_names()),'Window title',0)
    mic = sr.Microphone(deviceID)
    r = sr.Recognizer()
    r.dynamic_energy_threshold = dynamicEnergyThreshold
    r.energy_threshold = energyThresholdValue
    r.pause_threshold = pauseThreshold
    MessageBox(None, 'Click OK, wait a while to establish recording - like 0.5 seconds','Window title',0)
    with mic as source:
        audio = r.listen(source,timeout=timeoutSeconds,phrase_time_limit=phraseTimeLimit)

    # Based on used engine
    if engine.lower() == "google":
        result = r.recognize_google(audio)
    elif engine.lower() == "googlecloud":
        result = r.recognize_google_cloud(audio,credentials_json=filePath,language=inputLanguage)
    elif engine.lower() == "wit":
        result = r.recognize_wit(audio,apiKey)
    elif engine.lower() == "bing":
        result = r.recognize_bing(audio,apiKey,language=inputLanguage)
    elif engine.lower() == "houndify":
        result = r.recognize_houndify(audio,client_id=username,client_key=password)
    elif engine.lower() == "ibm":
        result = r.recognize_ibm(audio,username=username,password=password,language=inputLanguage)
    elif engine.lower() == "sphinx":
        result = r.recognize_sphinx(audio,language=inputLanguage)
    return str(result)

def getFile(deviceID=0, filePath=None, inputLanguage="en-us", apiKey=None, username=None, password=None, engine="Google", dynamicEnergyThreshold=True, energyThresholdValue=None, pauseThreshold=None, timeoutSeconds=None, phraseTimeLimit=None):
    file = sr.AudioFile(filePath)
    r = sr.Recognizer()
    r.dynamic_energy_threshold = dynamicEnergyThreshold
    r.energy_threshold = energyThresholdValue
    r.pause_threshold = pauseThreshold
    with file as source:
        audio = r.listen(source,timeout=timeoutSeconds,phrase_time_limit=phraseTimeLimit)
    # Based on used engine
    if engine.lower() == "google":
        result = r.recognize_google(audio)
    elif engine.lower() == "googlecloud":
        result = r.recognize_google_cloud(audio, credentials_json=filePath, language=inputLanguage)
    elif engine.lower() == "wit":
        result = r.recognize_wit(audio, apiKey)
    elif engine.lower() == "bing":
        result = r.recognize_bing(audio, apiKey, language=inputLanguage)
    elif engine.lower() == "houndify":
        result = r.recognize_houndify(audio, client_id=username, client_key=password)
    elif engine.lower() == "ibm":
        result = r.recognize_ibm(audio, username=username, password=password, language=inputLanguage)
    elif engine.lower() == "sphinx":
        result = r.recognize_sphinx(audio, language=inputLanguage)
    return str(result)

