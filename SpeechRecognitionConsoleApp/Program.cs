
using Microsoft.CognitiveServices.Speech;
using System.Drawing;

namespace SpeechRecognitionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;


            Console.WriteLine("\n");
            String welcome = "Welcome to speech recognition";
            String db = "---developed by---";
            //String po = "___Programar___";
            String name = "Md. Monirujjaman";


            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (welcome.Length / 2)) + "}", welcome));

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (db.Length / 2)) + "}", db));

            //Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
            //    (po.Length / 2)) + "}", po));

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (name.Length / 2)) + "}", name));

            Console.ForegroundColor = ConsoleColor.Green;

            String start_line_1 = "****";
            String start_line_2 = "**********";
            String start_line_3 = "**********";
            String start_line_4 = "****";



            Console.WriteLine("\n");

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (start_line_1.Length / 2)) + "}", start_line_1));
            
            
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (start_line_2.Length / 2)) + "}", start_line_2));    
            
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (start_line_3.Length / 2)) + "}", start_line_3));  
            
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) +
                (start_line_4.Length / 2)) + "}", start_line_4));   
            

            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.White;

            Ss().Wait();

            Console.ReadKey();
        }

        private static async Task Ss()
        {

            var config = SpeechConfig.FromSubscription("08cbff7df99a4f13a72a645b1ee53654", "eastasia");
            //var config = SpeechConfig.FromSubscription("08cbff7df99a4f13a72a645b1ee53654", "eastasia");

            using (var recon = new SpeechRecognizer(config))
            {
                recon.Recognizing += Recon_Recognizing;
                recon.Recognized += Recon_Recognized;
                recon.SessionStarted += Recon_SessionStarted;
                recon.SessionStopped += Recon_SessionStopped;

                await recon.StartContinuousRecognitionAsync().ConfigureAwait(false);

                do
                {
                    //Console.WriteLine("Press enter to stop");

                } while (Console.ReadKey().Key!=ConsoleKey.Enter);

                await recon.StopContinuousRecognitionAsync().ConfigureAwait(false);

            }
        }

        private static void Recon_SessionStopped(object? sender, SessionEventArgs e)
        {
            Console.WriteLine("Session ended.");
        }

        private static void Recon_SessionStarted(object? sender, SessionEventArgs e)
        {

            Console.WriteLine("You can start speaking...");

        }

        private static void Recon_Recognized(object? sender, SpeechRecognitionEventArgs e)
        {
            if (e.Result.Reason == ResultReason.RecognizedSpeech)
            {
                Console.WriteLine($"Your speech : {e.Result.Text}");
            }
        }

        private static void Recon_Recognizing(object? sender, SpeechRecognitionEventArgs e)
        {
            //Console.WriteLine($"Recognizing: {e.Result.Text}");
        }
    }

}


