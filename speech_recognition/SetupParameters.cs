using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Activities;
using System.ComponentModel;
using System.Drawing;

namespace SpeechRecognition
{
    public class SetupParameters : CodeActivity
    {
        public enum Engineenum
        {
            Google,
            GoogleCloud,
            Bing,
            Houndify,
            IBM,
            Sphinx,
            Wit
        }
        // ID of the Input Device - Microphone ID - Let it be empty to use the default one
        [Category("Input")]
        public InArgument<Int32> DeviceID {get; set;}

        [Category("Input")]
        public InArgument<string> FilePath { get; set; }

        [Category("Logon")]
        public InArgument<string> APIKey { get; set; }

        [Category("Logon")]
        public InArgument<string> Username { get; set; }

        [Category("Logon")]
        public InArgument<string> Password { get; set; }

        [Category("Options")]
        public Engineenum Engine { get; set; }

        // True by Default, False if you want to set the Threshold Value
        private InArgument<Boolean> threshold = true;
        [Category("Options")]
        public InArgument<Boolean> DynamicEnergyThreshold { get { return this.threshold; } set { this.threshold = value; } }

        // Set up in case you are not using dynamic energy threshold
        // To eliminate Ambient noise, typical values in range (150,3500), silent room -> low number
        private InArgument<Int32> energyThreshold = 300;
        [Category("Options")]
        public InArgument<Int32> EnergyThresholdValue { get {return this.energyThreshold; } set {this.energyThreshold = value; } }

        // Set up in case you are not using dynamic energy threshold
        // Pause between words, as you reach the threshold, recording will stop (seconds)
        private InArgument<double> pauseThresholdValue = 0.8;
        [Category("Options")]
        public InArgument<double> PauseThreshold { get {return this.pauseThresholdValue; } set {this.pauseThresholdValue = value; } }

        // Throw an error, if there is no speech until this timeout (seconds) 
        [Category("Options")]
        public InArgument<double> TimeoutSeconds { get; set; }
        
        // Set up in case you want to limit the time for recording (seconds)
        [Category("Options")]
        public InArgument<double> PhraseTimeLimit { get; set; }

        private InArgument<string> inputLanguageValue = "en-US";
        [Category("Options")]
        public InArgument<string> InputLanguage { get {return this.inputLanguageValue; } set {this.inputLanguageValue = value; } }

        [Category("Output")]
        public OutArgument<IEnumerable<object>> OutputParameters { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var deviceID = (int) DeviceID.Get(context);
            var dynamicEnergyThreshold = (Boolean) DynamicEnergyThreshold.Get(context);
            var energyThresholdValue = (Int32) EnergyThresholdValue.Get(context);
            if (energyThresholdValue <= 0)
                energyThresholdValue = 300;
            var pauseThreshold = PauseThreshold.Get(context);
            if (pauseThreshold <= 0)
                pauseThreshold = 0.8;
            double? timeoutSeconds = TimeoutSeconds.Get(context);
            double? phraseTimeLimit = PhraseTimeLimit.Get(context);
            var inputLanguage = InputLanguage.Get(context);
            if (inputLanguage.Length < 2)
                inputLanguage = "en-US";
            var apiKey = APIKey.Get(context);
            var username = Username.Get(context);
            var password = Password.Get(context);
            var engine = Engine;
            var filePath = FilePath.Get(context);
            IEnumerable<object> inputParameters = new object []{ deviceID, filePath, inputLanguage, apiKey, username, password, engine, dynamicEnergyThreshold, energyThresholdValue, pauseThreshold, timeoutSeconds, phraseTimeLimit};
            OutputParameters.Set(context, inputParameters);
        }
    }
}
