using System;
using System.Collections.Generic;

namespace SEW
{
    public class Word
    {
        private long _ID;
        private string _InEnglish;
        private string _InRussian;
        private DateTime _CanBeDisplayedAt;
        private byte _Review;
        private Category _category;
        private string _Transcription;
        private string _Status;
        private List<Example> _Examples;

        public long ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }
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
        public DateTime CanBeDisplayedAt
        {
            get { return _CanBeDisplayedAt; }
            set
            {
                _CanBeDisplayedAt = value;
            }
        }
        public byte Review
        {
            get { return _Review; }
            set
            {
                _Review = value;
            }
        }
        public Category category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
        }
        public string Transcription
        {
            get { return _Transcription; }
            set
            {
                _Transcription = value;
            }
        }
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
            }
        }
        public List<Example> Examples
        {
            get { return _Examples; }
            set
            {
                _Examples = value;
            }
        }
    }
}
