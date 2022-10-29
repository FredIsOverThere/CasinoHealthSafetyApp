<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body>
  <img src="https://media.discordapp.net/attachments/740368945466310736/925947927954882580/264973486_679935953385366_444115336260667617_n.png" />
  <h1>Emmah Assessment</h1>
  <table>
    <tr>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><b>Staff ID:</b></td>
      <td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/StaffID"/></td>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><b>Name:</b></td>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/FirstName"/></td>
      <td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/LastName"/></td>
    </tr> 
    <tr>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><b>Game Assessed On:</b></td>
      <td style="color: Black;text-align:Left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/Game"/></td>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><b>Completed By:</b></td>
      <td style="color: Black;text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/AStaffID"/></td>
      <td style="color: Black;text-align:right; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/AFirstName"/></td>
      <td style="color: Black;text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/ALastName"/></td>
    </tr> 
    <tr>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><b>Date Completed:</b></td>
      <td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/PersonalInformation/DateCompleted"/></td>
      <td style="color: Black; text-align:right; border-collapse: collapse;"><b>Date of next Assessment Due:</b></td>
      <td colspan = "2" style="color: Black; text-align:center; border-collapse: collapse; "><xsl:value-of select="Checklist/Dealer/PersonalInformation/DateReassess"/></td>
    </tr>
</table>

    <table>
	<tr>
		<th style="text-align:left; border-collapse: collapse;">Non-Dealing/Between Hands</th>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question1"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer1"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question2"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer2"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question3"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer3"/></td>
	</tr>

	<tr>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question4"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer4"/></td>
	</tr>
</table>
<table>
	<tr>
		<th style="text-align:left; border-collapse: collapse;">Key areas of concern that may cause Injury</th>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question5"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer5"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question6"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer6"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question7"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer7"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question8"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer8"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question9"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer9"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question10"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer10"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question11"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer11"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question12"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer12"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:left; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question13"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer13"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question14"/></td>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer14"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question15"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:justify; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer15"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:center; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Question16"/></td>
	</tr>
	<tr>
		<td style="color: Black; text-align:justify; border-collapse: collapse;"><xsl:value-of select="Checklist/Dealer/QnA/Answer16"/></td>
	</tr>
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>