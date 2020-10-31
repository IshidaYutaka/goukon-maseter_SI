namespace FrostweepGames.Plugins.GoogleCloud.SpeechRecognition
{
    public class Enumerators
    {
        public enum AudioEncoding
        {
            ENCODING_UNSPECIFIED,
            LINEAR16,
            FLAC,
            MULAW,
            AMR,
            AMR_WB
        }

        public enum SpeechRecognitionType
        {
            SYNC,
            ASYNC,
            STREAMING
        }

        public enum LanguageCode
        {
         
            EN_US,
            JA,
        }
    }
}