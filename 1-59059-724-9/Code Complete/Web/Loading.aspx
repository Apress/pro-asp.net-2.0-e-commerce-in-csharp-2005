<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Loading.aspx.cs" Inherits="Loading" Title="Untitled Page" %>

<html>
<head id="Head1" runat="server">
    <title>Processing....</title>
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <link href="Css/style.css" type="text/css" rel="stylesheet" />
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
<body onload="BeginLoad()" onunload="EndLoad()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="background-image: url(images/til_1.jpg);">
            <tr>
                <td>&nbsp;</td>
                <td width="490" align="left" valign="top">
                    <table width="490" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10">&nbsp;</td>
                            <td width="470" align="left" valign="top">
                                <table width="470" height="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="164" align="left" valign="top" background="images/top_1.jpg">
                                            <div style="padding-left: 156px; padding-top: 69px"><img src="images/logo.jpg" width="159" height="36" border="0"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="172" align="right" valign="top" background="images/back_1.jpg">
                                            <div style="padding-left: 0px; padding-top: 14px; padding-right: 23px; padding-bottom: 0px">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="100%" align="left" valign="top">
                                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" background="images/rep_3.jpg">
                                                <tr align="left" valign="top">
                                                    <td background="images/rep_left.jpg" style="width: 10px">
                                                        <img src="images/rep_left.jpg" width="10" height="1"></td>
                                                    <td height="100%">
                                                        <table width="450" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr align="left" valign="top">
                                                                <td background="images/rep_line.jpg" bgcolor="#F3E9BF" style="background-repeat: repeat-y;
                                                                    background-position: top left;">
                                                                    &nbsp;<br />
                                                                    <br />
                                                                    <br />
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="99%" height="99%" align="center" valign="middle">
				                                                    <tr>
					                                                    <td align="center" valign="middle">
						                                                    <font color="Red" size="3">
							                                                    <span id="Message">
                                                                                    <img src="Images/pleasewait.gif" /><br />
                                                                                    <br />
                                                                                    Processing Payment&nbsp;-- Please Wait
							                                                    <span id="Progress" style="WIDTH:25px;TEXT-ALIGN:left"></span>
                                                                                    <br />
                                                                                    <br />
                                                                                    <br />
                                                                                    <br />
                                                                                </span>
						                                                    </font>
					                                                    </td>
				                                                    </tr>
			                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="10" background="images/rep_right.jpg"><img src="images/rep_right.jpg" width="10" height="1"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" valign="top" align="center"><img src="images/bottom_1.jpg" width="470" height="23"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td height="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
                        <tr>
                            <td style="height: 100%; background-image: url(images/rep_bot.jpg); background-repeat: repeat-y; background-position: center;"></td>
                        </tr>
                    </table>
                </td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>

