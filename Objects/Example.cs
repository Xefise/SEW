namespace SEW
{
    public class Example
    {
        private string _InEnglish;
        private string _InRussian;
        private Word _word;

        public string InEnglish
        {
            get { return _InEnglish; }
            set
            {
                _InEnglish = value;
            }
        }
        public string InRussian
        {
            get { return _InRussian; }
            set
            {
                _InRussian = value;
            }
        }
        public Word word
        {
            get { return _word; }
            set
            {
                _word = value;
            }
        }
    }
}
