<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxl"
                xmlns:wix="http://schemas.microsoft.com/wix/2006/wi">

  <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes" />
  <xsl:strip-space elements="*" />

  <!-- Get harvest file details -->
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()" />
    </xsl:copy>
  </xsl:template>

  <!-- Match and ignore Web.Config file-->
 <xsl:key name="config-search" match="wix:Component[contains(wix:File/@Source, '$(var.HostFileDir)\Web.config')]" use="@Id" />
  <xsl:template match="wix:Component[key('config-search', @Id)]" />
  <xsl:template match="wix:ComponentRef[key('config-search', @Id)]" />

  <xsl:key name="env-dir-search" match="wix:Directory[@Name='Env']" use="@Id" />
  <xsl:key name="env-file-search" match="wix:Component[ancestor::wix:Directory/@Name='Env']" use="@Id" />
  
  <xsl:template match="wix:Directory[@Name='Env']" />
  <xsl:template match="wix:Component[key('env-dir-search', @Directory)]"/>
  <xsl:template match="wix:ComponentRef[key('env-file-search', @Id)]" />

</xsl:stylesheet>


