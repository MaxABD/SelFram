using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumFramework.Framework
{
    public static class HtmlTableExtension
    {
        //Считать таблицу
        private static List<TableDatacollection> ReadTable(IWebElement table)
        {
            //Инициализация таблицы
            var tableDataCollection = new List<TableDatacollection>();

            //Все столбцы из таблицы
            var columns = table.FindElements(By.TagName("th"));

            //Все строки
            var rows = table.FindElements(By.TagName("tr"));

            //Индекс строки
            var rowIndex = 0;

            foreach (var row in rows)
            {
                //Индекс столбца
                var colIndex = 0;

                //Данные ячеек таблицы
                var colDatas = row.FindElements(By.TagName("td"));

                //Сохранять данные, только если они имеют значение в строке
                if (colDatas.Count != 0)
                    foreach (var colValue in colDatas)
                    {
                        tableDataCollection.Add(new TableDatacollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = columns[colIndex].Text != "" ? columns[colIndex].Text : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });
                        //Перейти к следующему столбцу
                        colIndex++;
                    }

                rowIndex++;
            }

            return tableDataCollection;
        }

        //Проверка наличия у элемента управления определенных тегов, таких как input/hyperlink и т.д.
        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue? columnSpecialValue = null;
            if (columnValue.FindElements(By.TagName("a")).Count > 0)
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = ControlType.hyperlink
                };
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = ControlType.input
                };

            return columnSpecialValue;
        }

        //Считать значение ячейки
        private static string ReadCell(List<TableDatacollection> table, string columnName, int rowNumber)
        {
            var data = (from e in table
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();

            return data;
        }

        //Вывод значения ячейки
        public static string OutputCell(this IWebElement element, string columnName, int rowNumber)
        {
            //Считываем таблицу
            var table = ReadTable(element);

            string Output = ReadCell(table, columnName, rowNumber);
            return Output;
        }


        //Действие над ячейкой
        public static void PerformActionOnCell(this IWebElement element, string targetColumnIndex, string refColumnName,
            string refColumnValue, string controlToOperate = null)
        {
            //Считываем таблицу
            var table = ReadTable(element);

            //Выполнить итерации в таблице и получить искомый тип ячейки
            foreach (int rowNumber in GetDynamicRowNumber(table, refColumnName, refColumnValue))
            {
                var cell = (from e in table
                            where e.ColumnName == targetColumnIndex && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                //Если нужно работать с элементами управления
                if (controlToOperate != null && cell != null)
                {
                    IWebElement? elementToClick = null;
                    //Поскольку в зависимости от типа элемента управления, получение текста меняется
                    //Созданы такие типы управления
                    if (cell.ControlType == ControlType.hyperlink)
                        elementToClick = (from c in cell.ElementCollection
                                          where c.Text == controlToOperate
                                          select c).SingleOrDefault();
                    if (cell.ControlType == ControlType.input)
                        elementToClick = (from c in cell.ElementCollection
                                          where c.GetAttribute("value") == controlToOperate
                                          select c).SingleOrDefault();

                    //Доступен только клик
                    elementToClick?.Click();
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            
            }
        }

        //Динамическая строка
        private static IEnumerable GetDynamicRowNumber(List<TableDatacollection> tableCollection, string columnName,
            string columnValue)
        {
            foreach (var table in tableCollection)
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
        }
    }
    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string? ColumnName { get; set; }
        public string? ColumnValue { get; set; }
        public ColumnSpecialValue? ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement>? ElementCollection { get; set; }
        public ControlType? ControlType { get; set; }
    }

    public enum ControlType
    {
        hyperlink,
        input,
        option,
        select
    }
}
