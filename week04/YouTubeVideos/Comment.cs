namespace YouTubeVideos
{
    public class Comment
    {
        public string CommenterName { get; }
        public string CommentText { get; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }
}