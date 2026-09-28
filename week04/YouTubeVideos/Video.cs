using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
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
                Console.WriteLine($" * {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }
            
            Console.WriteLine("===============================================================================\n");
        }
    }
}
