using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Video
    {
        private readonly List<Comment> _comments = new();

        public string Title { get; }
        public string Author { get; }
        public int LengthInSeconds { get; }

        public IReadOnlyList<Comment> Comments => _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in _comments)
            {
                Console.WriteLine($"  - {comment.CommenterName}: \"{comment.CommentText}\"");
            }

            Console.WriteLine();
        }
    }
}