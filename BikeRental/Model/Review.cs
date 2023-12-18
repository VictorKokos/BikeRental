using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BikeRental
{
    public class Review : INotifyPropertyChanged
    {
        private int id;
        private int client_id;
        private int bike_id;
        private string review_header;
        private string review_text;
        private int score;
        private string answer_text;

        [Column("id")]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [Column("client_id")]
        public int ClientId
        {
            get { return client_id; }
            set
            {
                client_id = value;
                OnPropertyChanged("ClientId");
            }
        }

        [Column("bike_id")]
        public int BikeId
        {
            get { return bike_id; }
            set
            {
                bike_id = value;
                OnPropertyChanged("BikeId");
            }
        }

        [Column("review_header")]
        public string ReviewHeader
        {
            get { return review_header; }
            set
            {
                review_header = value;
                OnPropertyChanged("ReviewHeader");
            }
        }

        [Column("review_text")]
        public string ReviewText
        {
            get { return review_text; }
            set
            {
                review_text = value;
                OnPropertyChanged("ReviewText");
            }
        }

        [Column("score")]
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        [Column("answer_text")]
        public string AnswerText
        {
            get { return answer_text; }
            set
            {
                answer_text = value;
                OnPropertyChanged("AnswerText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
