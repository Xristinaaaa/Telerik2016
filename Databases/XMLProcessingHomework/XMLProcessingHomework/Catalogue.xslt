<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
      
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;</xsl:text>
    <html>
    <body>
      <h2>Catalogue</h2>
      <table border="1">
        <xsl:for-each select="catalogue/artist">        
        <tr bgcolor="#CCCCCC">
          <th align="left">Name</th>
          <th align="left">Albums</th>
        </tr>
        <tr>
          <td><xsl:value-of select="name"/></td>
          <td>
            <xsl:for-each select="album">
                <xsl:value-of select="name"/>
                <xsl:value-of select="year"/>
                <xsl:value-of select="producer"/>
                <xsl:value-of select="price"/>
                <xsl:for-each select="songs/song">
                  <xsl:value-of select="title"/>
                  <xsl:value-of select="duration"/>             
                </xsl:for-each>    
            </xsl:for-each>
          </td>
        </tr>
        </xsl:for-each>
      </table>
    </body>
    </html>
    </xsl:template>
</xsl:stylesheet>
