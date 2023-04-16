namespace Bulutay.QuestionBankApp.Application.Dtos
{
    public class QuestionListWithCategoryLectureUserDto
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public bool IsCorrect { get; set; }
        public CategoryListDto? Category { get; set; }
        public LectureListWithDepartmentDto? Lecture { get; set; }
        public UserListWithoutPasswordDto? User { get; set; }
        public List<OptionListDto>? Options { get; set; }
    }
}
