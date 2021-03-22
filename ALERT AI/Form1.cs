using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Net;
using static ALERT_AI.WeatherClass;
using Newtonsoft.Json;

namespace ALERT_AI
{
    public partial class Alert_AI : Form
    {
        public bool wake = false;
        public string owner = "banish";
        public Alert_AI()
        {
            InitializeComponent();
        }

        SpeechSynthesizer aiSpeech = new SpeechSynthesizer();
        SpeechRecognitionEngine aiRecognise = new SpeechRecognitionEngine();
        PromptBuilder aiPrompt = new PromptBuilder();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Speak_Button.Text = "Activated";
            aiSpeech.SelectVoiceByHints(VoiceGender.Female);
            aiSpeech.Speak("hi, i am alert ai. if you need me, just say \"hey alert\".");
            Choices commandList = new Choices();
            commandList.Add(File.ReadAllLines(@"C:\ALERT AI\commands.txt"));

            Grammar grammarObject = new Grammar(new GrammarBuilder(commandList));

            try
            {
                aiRecognise.RequestRecognizerUpdate();
                aiRecognise.LoadGrammar(grammarObject);
                aiRecognise.SpeechRecognized += aiRecognise_SpeechRecognized;
                aiRecognise.SetInputToDefaultAudioDevice();
                aiRecognise.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {

                return;
            }
            aiPrompt.ClearContent();
            aiSpeech.Speak(aiPrompt);
            
        }

        public void Say(string sentence)
        {
            aiSpeech.SpeakAsync(sentence);
            wake = false;
        }

        private void aiRecognise_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speechSaid = e.Result.Text;
            string apiKey = "4603d9d14eba355f4b70d7802bb16587";

            if (speechSaid == "hey alert" || speechSaid == "hi alert")
            {
                SoundPlayer player = new SoundPlayer(@"C:\ALERT AI\Sounds\WakeUp.wav");
                player.Play();
                wake = true;
                
            }

            if (wake)
            {
                switch (speechSaid)
                {
                    case ("hello"):
                        Say("hi banish");
                        break;

                    case ("how are you"):
                        Say("I am doing pretty good" + owner);
                        break;

                    case ("what is my name"):
                        Say("your name is " + owner);
                        break;

                    case ("open google"):
                        Say("opening google");
                        Process.Start("https://www.google.com");
                        break;

                    case ("close"):
                        Say("closing program");
                        SendKeys.Send("%{F4}");
                        break;

                    case ("exit"):
                        aiSpeech.Speak("closing down banish, thanks for using alert ai");
                        Application.Exit();
                        break;

                    case ("what is the time right now"):
                    Say("the time is" + DateTime.Now.ToString("t"));
                        break;

                    case ("what is the weather today"):
                        HttpWebRequest apiRequest = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=edmonton&appid=" + apiKey + "&units=metric") as HttpWebRequest;
                        string apiResponse = "";
                        using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                        {
                            
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            apiResponse = reader.ReadToEnd();
                        }

                        ResponseWeather rootObject = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
                        Say("Today's weather is " + rootObject.weather[0].main + " and the temperature is " + rootObject.main.temp + " degree Celsius.");
                        break;

                        
                }
            }


        }
    }
}
