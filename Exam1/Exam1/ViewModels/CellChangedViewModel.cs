namespace Exam1.ViewModels
#nullable disable
{
    /// <summary>
    /// Tạo class lưu 2 thuộc tính thay đổi là vị trí và giá trị khi update
    /// </summary>
    public class CellChangedViewModel
    {
        public string CellName { get; set; }
        public object CellValue { get; set; }
    }
}
