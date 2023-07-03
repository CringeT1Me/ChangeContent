using Xunit;
using ChangeContentSpace;
namespace ChangeContentTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            ChangeContentClass change = new ChangeContentClass();
            string min_file = @"F:\�������\ChangeContent\bin\Debug\1.txt",
                   mid_file = @"F:\�������\ChangeContent\bin\Debug\2.txt",
                   max_file = @"F:\�������\ChangeContent\bin\Debug\3.txt",
                   content_min_old = change.ContentReturn(min_file),
                   content_mid_old = change.ContentReturn(mid_file),
                   content_max_old = change.ContentReturn(max_file);
            Assert.NotEqual(content_min_old, content_max_old); //�������� �� �������� ����������� �������� � �������� ������
            change.ChangeContentVoid(min_file, mid_file, max_file);
            string content_min_new = change.ContentReturn(min_file),
                   content_mid_new = change.ContentReturn(mid_file),
                   content_max_new = change.ContentReturn(max_file);
            Assert.Equal(content_min_new, content_max_new); //�������� �� ������������ ���������� �������� � �������� ������
            Assert.Equal(content_mid_new, content_mid_old); //�������� �� �������������� ������ ����� ��������
            Assert.Equal(content_max_new, content_max_old);
        }
    }
}