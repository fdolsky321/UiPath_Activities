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
        // ID of the Input Device - Microphone ID - Let it be empty to use the default one
        [Category("Input")]
        public InArgument<Int32> DeviceID {get; set;}

        [Category("Logon")]
        public InArgument<string> APIKey { get; set; }

        [Category("Logon")]
        public InArgument<string> Username { get; set; }

        [Category("Logon")]
        public InArgument<string> Password { get; set; }

        [Category("Options")]
        public InArgument<string> Engine { get; set; }

        // True by Default, False if you want to set the Threshold Value
        [Category("Options")]
        public InArgument<Boolean> DynamicEnergyThreshold { get; set; }

        // Set up in case you are not using dynamic energy threshold
        // To eliminate Ambient noise, typical values in range (150,3500), silent room -> low number
        [Category("Options")]
        public InArgument<Int32> EnergyThresholdValue { get; set; }

        // Set up in case you are not using dynamic energy threshold
        // Pause between words, as you reach the threshold, recording will stop (seconds)
        [Category("Options")]
        public InArgument<double> PauseThreshold { get; set; }
        
        // Throw an error, if there is no speech until this timeout (seconds)
        [Category("Options")]
        public InArgument<double> TimeoutSeconds { get; set; }
        
        // Set up in case you want to limit the time for recording (seconds)
        [Category("Options")]
        public InArgument<double> PhraseTimeLimit { get; set; }

        [Category("Options")]
        public InArgument<string> InputLanguage { get; set; }

        [Category("Output")]
        public OutArgument<IEnumerable<object>> OutputParameters { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var deviceID = (int) DeviceID.Get(context);
            var dynamicEnergyThreshold = (Boolean) DynamicEnergyThreshold.Get(context);
            var energyThresholdValue = (Int32) EnergyThresholdValue.Get(context);
            var pauseThreshold = PauseThreshold.Get(context);
            var timeoutSeconds = TimeoutSeconds.Get(context);
            var phraseTimeLimit = PhraseTimeLimit.Get(context);
            var inputLanguage = InputLanguage.Get(context);
            var apiKey = APIKey.Get(context);
            var username = Username.Get(context);
            var password = Password.Get(context);
            var engine = Engine.Get(context);
            IEnumerable<object> inputParameters = new object []{ deviceID, inputLanguage, apiKey, username, password, engine, dynamicEnergyThreshold, energyThresholdValue, pauseThreshold, timeoutSeconds, phraseTimeLimit};
            OutputParameters.Set(context, inputParameters);
        }
    }
}
