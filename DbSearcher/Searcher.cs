using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DbSearcher
{
    public sealed class SearchResult
    {
        public long LineNumber { get; }
        public string Line { get; }
        public string FilePath { get; }

        public SearchResult(long lineNumber, string line, string filePath)
        {
            LineNumber = lineNumber;
            Line = line;
            FilePath = filePath;
        }

        public override string ToString() => $"{FilePath}:{LineNumber}: {Line}";
    }

    public static class FileSearcher
    {
        public static IEnumerable<SearchResult> SearchLines(
            string filePath,
            string query,
            bool exactMatch = false,
            bool caseSensitive = false,
            Encoding encoding = null,
            int maxResults = int.MaxValue)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);

            encoding = encoding ?? Encoding.UTF8;
            var comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            using (var sr = new StreamReader(filePath, encoding))
            {
                string line;
                long lineNumber = 0;
                int found = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    if (exactMatch)
                    {
                        if (string.Equals(line.Trim(), query, comparison))
                        {
                            yield return new SearchResult(lineNumber, line, filePath);
                            found++;
                        }
                    }
                    else
                    {
                        if (line.IndexOf(query, comparison) >= 0)
                        {
                            yield return new SearchResult(lineNumber, line, filePath);
                            found++;
                        }
                    }

                    if (found >= maxResults) yield break;
                }
            }
        }
        public static SearchResult FindFirstMatch(
            string filePath,
            string query,
            bool exactMatch = false,
            bool caseSensitive = false,
            Encoding encoding = null)
        {
            foreach (var r in SearchLines(filePath, query, exactMatch, caseSensitive, encoding, 1))
                return r;
            return null;
        }
        public static IEnumerable<SearchResult> SearchCsvByColumn(
            string filePath,
            int columnIndex,
            string query,
            bool exactMatch = false,
            bool caseSensitive = false,
            char delimiter = ',',
            Encoding encoding = null,
            int maxResults = int.MaxValue)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);

            encoding = encoding ?? Encoding.UTF8;
            var comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            using (var sr = new StreamReader(filePath, encoding))
            {
                string line;
                long lineNumber = 0;
                int found = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    var fields = SplitCsvLine(line, delimiter);
                    if (fields.Length > columnIndex)
                    {
                        var field = fields[columnIndex];
                        if (exactMatch)
                        {
                            if (string.Equals(field.Trim(), query, comparison))
                            {
                                yield return new SearchResult(lineNumber, line, filePath);
                                found++;
                            }
                        }
                        else
                        {
                            if (field.IndexOf(query, comparison) >= 0)
                            {
                                yield return new SearchResult(lineNumber, line, filePath);
                                found++;
                            }
                        }
                        if (found >= maxResults) yield break;
                    }
                }
            }
        }

        public static IEnumerable<SearchResult> SearchCsvByColumnName(
            string filePath,
            string columnName,
            string query,
            bool exactMatch = false,
            bool caseSensitive = false,
            char delimiter = ',',
            Encoding encoding = null,
            int maxResults = int.MaxValue)
        {
            if (columnName == null) throw new ArgumentNullException(nameof(columnName));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found", filePath);

            encoding = encoding ?? Encoding.UTF8;
            using (var sr = new StreamReader(filePath, encoding))
            {
                var header = sr.ReadLine();
                if (header == null) yield break;
                var headers = SplitCsvLine(header, delimiter);
                int colIndex = -1;
                for (int i = 0; i < headers.Length; i++)
                {
                    if (string.Equals(headers[i].Trim(), columnName.Trim(), caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
                    {
                        colIndex = i; break;
                    }
                }
                if (colIndex == -1) yield break;

                string line;
                long lineNumber = 1;
                int found = 0;
                var comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    var fields = SplitCsvLine(line, delimiter);
                    if (fields.Length > colIndex)
                    {
                        var field = fields[colIndex];
                        if (exactMatch)
                        {
                            if (string.Equals(field.Trim(), query, comparison))
                            {
                                yield return new SearchResult(lineNumber, line, filePath);
                                found++;
                            }
                        }
                        else
                        {
                            if (field.IndexOf(query, comparison) >= 0)
                            {
                                yield return new SearchResult(lineNumber, line, filePath);
                                found++;
                            }
                        }
                        if (found >= maxResults) yield break;
                    }
                }
            }
        }
        private static string[] SplitCsvLine(string line, char delimiter)
        {
            if (line == null) return new string[0];
            var list = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        sb.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == delimiter && !inQuotes)
                {
                    list.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            list.Add(sb.ToString());
            return list.ToArray();
        }
    }
}