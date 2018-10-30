using ClosedXML.Excel;

namespace Key_Guard_KS
{
    public interface ITableHandle
    {
        XLWorkbook exelDataBase1 { get; set; }
        string User { get; set; }
        string siteNameQueryString1 { get; set; }
        void GetDataFromXL(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey, int needColumnNumber);
        void SetDataToXL(string siteNameFromUserRequest, string cellsRange, bool isUseUniqueKey);
    }
}