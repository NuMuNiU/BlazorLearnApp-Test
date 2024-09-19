using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Speech.Synthesis;

namespace BlazorLearnApp.UtilityClass
{
    public static class Speak
    {
        public static void speakAsync(string text)
        {
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            //synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            //synthesizer.Volume = 100;
            //synthesizer.Rate = 1;
            //synthesizer.SpeakAsync(text);
        }
        public static void speakSync(string text)
        {
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            //synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            //synthesizer.Volume = 100;
            //synthesizer.Rate = 1;
            //synthesizer.Speak(text);
        }

    }
}
