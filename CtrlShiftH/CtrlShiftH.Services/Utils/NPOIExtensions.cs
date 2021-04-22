using CtrlShiftH.Data.Enums;
using NPOI.SS.UserModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CtrlShiftH.Services.Utils
{
    public static class NPOIExtensions
    {
        /// <summary>
        /// Tạo border cho 1 cell
        /// </summary>
        /// <param name="style"></param>
        public static void CreateBorderAll(this ICellStyle style)
        {
            style.BorderTop = BorderStyle.Thin;
            style.BorderBottom = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
        }

        /// <summary>
        /// Check row is valid?
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this IRow row)
        {
            return row == null || row.Cells.All(d => d.CellType == CellType.Blank);
        }

        /// <summary>
        /// Check cell is valid?
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this ICell cell)
        {
            return cell == null || cell.CellType == CellType.Blank;
        }

        /// <summary>
        /// check import result is valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidResult(this string input)
        {
            return input.Equals("Âm Tính", StringComparison.OrdinalIgnoreCase)
                    || input.Equals("Dương Tính", StringComparison.OrdinalIgnoreCase)
                    || input.Equals("Chưa Xác Định", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Try Parse a cell value to Datetime if posible
        /// 
        /// </summary>
        /// <param name="cell">NPOI ICell</param>
        /// <returns>DateTime value or throw exception</returns>
        public static DateTime ParseDateTime(this ICell cell)
        {
            try
            {
                //if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                //{
                //    // Vì datetime mà excel trả về thường ở dạng (MM/dd/yyyy hh:mm:ss tt)
                //    var value = cell.DateCellValue;
                //    // đổi vị trí ngày và tháng
                //    var realDate = new DateTime(value.Year, value.Day, value.Month, value.Hour, value.Minute, value.Second);
                //    return realDate;
                //}
                //else
                //{
                // Xóa khoảng trắng ở đầu và cuối chuỗi
                var cellData = cell.ToString().Trim();
                // 3 dòng tiếp theo xóa những khoảng trắng ở giữa chuỗi với độ dài lớn hơn 2
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                var formatedCellData = regex.Replace(cellData, " ");
                // parse chuỗi về DateTime
                return formatedCellData.tryParseDateTime();
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Gender ReasAsGender(this string input)
        {
            try
            {
                if (input.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                {
                    return Gender.Male;
                }
                else if (input.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
                {
                    return Gender.Female;
                }
            }
            catch (Exception)
            {
                throw new Exception($"Cannot read {input} as Gender Type.");
            }
            throw new Exception($"Cannot read {input} as Gender Type.");
        }
    }
}
