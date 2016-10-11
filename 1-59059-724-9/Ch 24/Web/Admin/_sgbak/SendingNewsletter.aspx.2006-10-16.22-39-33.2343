<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendingNewsletter.aspx.cs" Inherits="Admin_SendingNewsletter" %>

<html>
<head id="Head1" runat="server">
    <title>Processing....</title>
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <link href="../Css/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
		    var LoopCounter = 1;
		    var MaxLoop = 5;
		    var IntervalId;
    		
		    function BeginLoad() 
		    {
			    location.href = "<%= Request.QueryString["Page"]%>";
			    IntervalId = window.setInterval("LoopCounter=UpdateProgress(LoopCounter, MaxLoop)", 500);
		    }
    	
		    function EndLoad() 
		    {
			    window.clearInterval(IntervalId);
			    Progress.innerText = "Page Loaded -- Not Transferring";
		    }
    	
		    function UpdateProgress(LoopCounter, MaxLoops)
		    {
			    LoopCounter += 1;
    			
			    if (LoopCounter <= MaxLoops) 
			    {
				    Progress.innerText += ".";
				    return LoopCounter;
			    }
			    else 
			    {
				    Progress.innerText = "";
				    return 1;
			    }
		    }
		</script>
</head>
<body onload="BeginLoad()" onunload="EndLoad()" style="text-align: center" background="../Images/til_1.jpg">
    <form id="form2" runat="server">
        <br />
    
        <table border="0" cellpadding="0" cellspacing="0" width="90%">
            <tr>
                <td style="width: 100%; background-color: #f3e9bf; text-align: center">
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #f3e9bf; text-align: center">
                    <img border="0" height="36" src="../images/logo.jpg" width="159" /><br />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: #f3e9bf; text-align: center">
                    <strong>Administrative Control Panel</strong></td>
            </tr>
            <tr>
                <td style="width: 100%">
                
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center;">
            <div style="background-color: #f3e9bf; width: 100%; text-align: center; height: 205px;">
                <br />
                <br />
                <table align="center" border="0" cellpadding="0" cellspacing="0" height="99%" valign="middle"
                    width="99%">
                    <tr>
                        <td align="center" valign="middle">
                            <font color="red" size="3"><span id="Message">
                                <img src="../Images/pleasewait.gif" /><br />
                                <br />
                                Sending Newsletter
                &nbsp;-- Please Wait <span id="Progress" style="width: 25px; text-align: left">
                                </span>
                                <br />
                                <br />
                                <br />
                                <br />
                            </span></font>
                        </td>
                    </tr>
                </table>
            </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

   