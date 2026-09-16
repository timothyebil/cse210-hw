using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the videos
            List<Video> videosList = new List<Video>();

            // ====================================================================
            // VIDEO 1: Tech Setup
            // ====================================================================
            Video video1 = new Video("Setting Up a 600W Solar Water Pump System", "Timothy Ebil", 720);
            
            video1.AddComment(new Comment("Francis Ocen", "This is exactly the breakdown I needed for my farm setup. Thanks!"));
            video1.AddComment(new Comment("Cynthia Bwiza", "Great explanation on how to match the MPPT charge controller to the pump wattage."));
            video1.AddComment(new Comment("Jackline Akao", "Clear, concise, and highly practical. Keep making these guides!"));
            
            videosList.Add(video1);

            // ====================================================================
            // VIDEO 2: Coding Tutorial
            // ====================================================================
            Video video2 = new Video("Understanding C# Abstraction & Encapsulation", "Code Academy", 450);
            
            video2.AddComment(new Comment("DevUser210", "Blown away by how simple you made classes and objects look. Great video."));
            video2.AddComment(new Comment("Alice_M", "Ah, so that's why we use private member variables instead of public ones!"));
            video2.AddComment(new Comment("BobCoding", "Can you show how to connect this to an external database in the next video?"));
            video2.AddComment(new Comment("StudentCoder", "Perfect timing for my university programming assignment. Saved my grade."));
            
            videosList.Add(video2);

            // ====================================================================
            // VIDEO 3: Hardware Review
            // ====================================================================
            Video video3 = new Video("HP EliteBook G3 Refurbished Tech Review", "Hardware Zone", 580);
            
            video3.AddComment(new Comment("User998", "Still a very capable laptop for software development studies in 2026."));
            video3.AddComment(new Comment("TechFanatic", "The battery life swap tips you gave at the end were super helpful."));
            video3.AddComment(new Comment("Alex_Ug", "Good budget choice for students who need performance without breaking the bank."));
            
            videosList.Add(video3);

            // ====================================================================
            // ITERATE AND DISPLAY ALL VIDEOS AND COMMENTS
            // ====================================================================
            Console.Clear();
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                     YOUTUBE PRODUCT AWARENESS TRACKER SYSTEM                  ");
            Console.WriteLine("===============================================================================\n");

            foreach (Video video in videosList)
            {
                video.DisplayVideoDetails();
            }
        }
    }

    // Represents a comment left on a video
    public class Comment
    {
        private string _commenterName;
        private string _commentText;

        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        public string GetCommenterName()
        {
            return _commenterName;
        }

        public string GetCommentText()
        {
            return _commentText;
        }
    }

    // Represents a YouTube video tracking title, author, length, and comments
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public void DisplayVideoDetails()
        {
            Console.WriteLine($"Video Title : {_title}");
            Console.WriteLine($"Author      : {_author}");
            Console.WriteLine($"Length      : {_lengthInSeconds} seconds");
            Console.WriteLine($"Comments ({GetCommentCount()}) :");
            Console.WriteLine("-------------------------------------------------------------------------------");
            
            foreach (Comment comment in _comments)
            {
                Console.WriteLine($"  * {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }
            
            Console.WriteLine("===============================================================================\n");
        }
    }
}
