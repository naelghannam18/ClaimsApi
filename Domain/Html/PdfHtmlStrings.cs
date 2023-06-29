namespace Domain.Html;

public static class PdfHtmlStrings
{
    public const string HtmlStart = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        * {
            padding: 10px;
        }
        table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            text-align: left;
            padding: 8px;
            border: 1px solid #ddd;
        }
        th {
            background-color: #f2f2f2;
        }
        .total-row td:first-child {
            text-align: left;
            font-weight: bold;
            padding-left: 10px;
        }
        .total-row td:last-child {
            width: 10%;
        }
    </style>
</head>
<body>
";

    public const string TableStart = @"
    <table>
        <tr>
            <th>Admission Date</th>
            <th>Card Number</th>
            <th>Name</th>
            <th>Hospital</th>
            <th>Medical Case</th>
            <th>Estimated Cost</th>
            <th>Status</th>
        </tr>";

    public const string TableRow = @"
        <tr>
            <th>{0}</th>
            <th>{1}</th>
            <th>{2}</th>
            <th>{3}</th>
            <th>{4}</th>
            <th>{5}$</th>
            <th>{6}</th>
        </tr>";

    public const string TotalRowHtml = @"
        <tr class=""total-row"">
            <td colspan=""6"">Total (Covered + Pending)</td>
            <td>{0}$</td>
        </tr>";

    public const string HtmlEnd = @"
    </table>
</body>
</html>";

}
