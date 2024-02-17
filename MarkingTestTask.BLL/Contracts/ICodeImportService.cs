
namespace MarkingTestTask.BLL.Contracts
{
    public interface ICodeImportService
    {
        List<string> ImportCodesFromFile(string filename, string gtin);
    }
}
