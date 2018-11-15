<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterGameBoard.aspx.cs" Inherits="CrownPeakDemo.EnterGameBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" action="Default.aspx">
        <div style="margin:20px;">
            <input type="button" value="Add A Row" onclick="addRow()" />
            <input type="button" value="Submit Game" onclick="_submit()" /><br /><br />
            <div id="rowsDiv">
                <span>Row 1</span><input id="row1" name="row1" type="text" size="20" class="rowdata" /><br />            
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function addRow() {
            var rowdiv = document.getElementById("rowsDiv");
            var newrowcount = (document.getElementById("rowsDiv").childElementCount / 3) + 1;
            var newtext = document.createElement("input");
            newtext.type = "text";
            newtext.id = "row"+newrowcount;
            newtext.name = "rowdata";
            newtext.size = 20;
            newtext.className = "rowdata";
            var newspan = document.createElement("span");
            newspan.textContent = "Row " + newrowcount;
            var newbr = document.createElement("br");
            rowdiv.appendChild(newspan);
            rowdiv.appendChild(newtext);
            rowdiv.appendChild(newbr);
        }

        function _submit() {
            //check length of each input for sameness
            var rows = document.getElementsByClassName("rowdata");
            var datalength = 0;
            var urlparams = "?";
            var foobar = "";
            if (rows.length > 0)
            {
                datalength = rows[0].value.length;
                if (datalength == 0) {
                    alert("Fix your data! No data in the first row!");
                    return;
                }
            }
            else
            {
                alert("Fix your data! No Rows to submit");
                return;
            } 

            for (var i = 0; i < rows.length; i++) {
                if (datalength != rows[i].value.length) {
                    alert("Fix your data! Row" + (i+1));
                    return;
                }                

                for (var j = 0; j < rows[i].value.length; j++) {
                    if (!((rows[i].value[j] == 1) || (rows[i].value[j] == 0) || (rows[i].value[j] == " "))) {
                         
                        alert("Fix your data! Only 1's and 0's are acceptable. Row" + (i + 1));
                        return;
                    }
                    
                }
               urlparams += "&rowdata="+ rows[i].value ;
                
            }
            document.getElementById("form1").action += urlparams.trim(',');
            document.getElementById("form1").submit();
        }
    </script>
</body>
</html>
