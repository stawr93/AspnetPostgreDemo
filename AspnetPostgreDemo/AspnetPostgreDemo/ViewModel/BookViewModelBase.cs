namespace AspnetPostgreDemo.ViewModel
{
    using System.ComponentModel;
    using Data.Models;

    /// <summary>
    /// ������� ������ ��� ������������� ���������� � �����.
    /// � ��� ���������� ��� �������� ����, ������� ����� ���������� ��� ���� �������-�����������. 
    /// </summary>
    public abstract class BookViewModelBase
    {
        /// <summary>
        /// ����������� ������ �� �������� ���������� �������.
        /// ������� ������ � ��������� �� ����������, ������� ���������� <see cref="book"/>.
        /// </summary>
        /// <param name="book">�������� ���������� �������, �� ��������� ������� �������������� ������ �������������.</param>
        protected BookViewModelBase(Book book)
        {
            Title = book.Title;
            PictureUrl = book.PictureUrl;
            Description = book.Description;
            Price = book.Price;
        }

        /// <summary>
        /// ����������� �� ��������� ��� ����������.
        /// ����� ��� ����, ����� ����� ���� ������� ������ ������, ��������, ��� �������� ����� �����.
        /// </summary>
        protected BookViewModelBase()
        {
        }

        /// <summary>
        /// �������� �����.
        /// </summary>
        [DisplayName("��������")] // ���� ������� ������������ ��� ������ �������� ���� 
                                  // ����� � input'�� � ����������� @Html.LabelFor(model => model.Title)
        public string Title { get; set; }

        /// <summary>
        /// ������ �� ��������.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// �������� �����.
        /// </summary>
        [DisplayName("��������")]
        public string Description { get; set; }

        /// <summary>
        /// ��������� �����.
        /// </summary>
        [DisplayName("����")]
        public decimal Price { get; set; }
    }
}