namespace CarRent.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public int BlogID { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }
    }
}
