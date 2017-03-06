<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h1>Students db</h1>
  <table bgcolor="#E0E0E0" cellspacing="1">
    <tr bgcolor="#EEEEEE">      
      <td><b>Name </b></td>
      <td><b>Sex </b></td>
      <td><b>Birth date </b></td>
      <td><b>Phone </b></td>
      <td><b>Email </b></td>
      <td><b>Course </b></td>
      <td><b>Specialty </b></td>
      <td><b>Faculty number </b></td>
      <td><b>Exams </b></td>
    </tr>
	<xsl:for-each select="/students/student">
      <tr bgcolor="white">
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="sex"/></td>
        <td><xsl:value-of select="birthDate"/></td>
        <td><xsl:value-of select="phone"/></td>
        <td><xsl:value-of select="email"/></td>
        <td><xsl:value-of select="course"/></td>
        <td><xsl:value-of select="specialty"/></td>
        <td><xsl:value-of select="fn"/></td>	
        <xsl:for-each select="/students/student/exams">
            <td><xsl:value-of select="exam"/></td>
        </xsl:for-each>
      </tr>
	</xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>